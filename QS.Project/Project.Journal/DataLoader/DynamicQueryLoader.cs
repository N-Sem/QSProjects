﻿using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Impl;
using QS.DomainModel.Entity;
using QS.DomainModel.UoW;

namespace QS.Project.Journal.DataLoader
{
	public class DynamicQueryLoader<TRoot, TNode> : IQueryLoader<TNode>, IPieceReader<TNode>, IEntityQueryLoader
		where TRoot : class, IDomainObject
		where TNode : class
	{
		private readonly Func<IUnitOfWork, bool, IQueryOver<TRoot>> queryFunc;
		private readonly IUnitOfWorkFactory unitOfWorkFactory;
		private readonly Func<IUnitOfWork, int> _itemsCountFunction;

		/// <param name="queryFunc">Функция получения запроса, имеет параметры: 
		/// uow - для которого создается запрос 
		/// isCounting - указание является ли запрос подсчетом количества строк </param>
		/// <param name="unitOfWorkFactory">Unit of work factory.</param>
		/// <param name="itemsCountFunction">Кастомная функция подсчёта кол-ва элементов</param>
		public DynamicQueryLoader(Func<IUnitOfWork, bool, IQueryOver<TRoot>> queryFunc, IUnitOfWorkFactory unitOfWorkFactory, Func<IUnitOfWork, int> itemsCountFunction = null)
		{
			this.queryFunc = queryFunc ?? throw new ArgumentNullException(nameof(queryFunc));
			this.unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
			_itemsCountFunction = itemsCountFunction;
			HasUnloadedItems = true;
			LoadedItems = new List<TNode>();
		}

		protected DynamicQueryLoader(IUnitOfWorkFactory unitOfWorkFactory) {
			this.unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
			HasUnloadedItems = true;
			LoadedItems = new List<TNode>();
		}

		#region IQueryLoader implementation

		public virtual bool HasUnloadedItems { get; protected set; }

		public virtual int? TotalItemsCount { get; protected set; }

		public virtual int LoadedItemsCount => LoadedItems.Count;

		public virtual List<TNode> LoadedItems { get; protected set; }

		public virtual int GetTotalItemsCount()
		{
			using (var uow = unitOfWorkFactory.CreateWithoutRoot()) {
				if(_itemsCountFunction != null)
				{
					return _itemsCountFunction.Invoke(uow);
				}

				var query = queryFunc.Invoke(uow, true);
				if(query == null)
					return 0;

				return query.ClearOrders().RowCount();
			}
		}

		public virtual void LoadPage(int? pageSize = null)
		{
			//Не подгружаем следующую страницу если из предыдущих данных еще не прочитана целая страница.
			if(pageSize.HasValue && (LoadedItemsCount - ReadedItemsCount) >= pageSize)
				return;

			using (var uow = unitOfWorkFactory.CreateWithoutRoot()) {
				var workQuery = queryFunc.Invoke(uow, false);
				if(workQuery == null) {
					HasUnloadedItems = false;
					return;
				}

				if (workQuery.UnderlyingCriteria is CriteriaImpl criteriaImpl && criteriaImpl.Session != uow.Session)
					throw new InvalidOperationException(
						"Метод создания запроса должен использовать переданный ему uow");
				
				if (pageSize.HasValue) {
					var resultItems = workQuery.Skip(LoadedItemsCount).Take(pageSize.Value).List<TNode>();

					HasUnloadedItems = resultItems.Count == pageSize;

					LoadedItems.AddRange(resultItems);
				}
				else {
					LoadedItems = workQuery.List<TNode>().ToList();
					HasUnloadedItems = false;
				}
			}
		}

		public virtual void Reset()
		{
			LoadedItems.Clear();
			ReadedItemsCount = 0;
			HasUnloadedItems = true;
		}

		#endregion IEntityLoader implementation

		#region PieceReader

		public virtual int ReadedItemsCount { get; protected set; }

		public virtual TNode NextUnreadedNode()
		{
			if (ReadedItemsCount >= LoadedItems.Count)
				return null;
			return LoadedItems[ReadedItemsCount];
		}

		public virtual TNode TakeNextUnreadedNode()
		{
			var item = NextUnreadedNode();
			ReadedItemsCount++;
			return item;
		}

		public virtual IList<TNode> TakeAllUnreadedNodes()
		{
			var readedCount = ReadedItemsCount;
			ReadedItemsCount = LoadedItems.Count;
			return LoadedItems.Skip(readedCount).ToList();
		}

		public virtual TNode GetNode(int entityId, IUnitOfWork uow)
		{
			var query = (queryFunc.Invoke(uow, false) as IQueryOver<TRoot, TRoot>);
			return query.Where(x => x.Id == entityId)
						.Take(1).List<TNode>().FirstOrDefault();
		}

		#endregion

		#region IEntityQueryLoader

		public virtual Type EntityType => typeof(TRoot);

		#endregion
	}
}
