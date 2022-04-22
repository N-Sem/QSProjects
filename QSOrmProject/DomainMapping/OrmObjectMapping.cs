﻿using System;
using System.Linq;
using QS.DomainModel.Config;
using QS.Tdi;
using QSOrmProject.UpdateNotification;
using QSProjectsLib;

namespace QSOrmProject.DomainMapping
{
	public class OrmObjectMapping<TEntity> : IOrmObjectMapping, IEntityConfig
	{
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

		public Type ObjectClass {
			get {
				return typeof(TEntity);
			}
		}

		Type dialogClass;

		public Type DialogClass {
			get {
				return dialogClass;
			}
		}

		private Type refFilterClass;

		public Type RefFilterClass {
			get {
				return refFilterClass;
			}
		}

		private bool? defaultUseSlider;

		public bool? DefaultUseSlider
		{
			get
			{
				return defaultUseSlider;
			}
		}

		public string EditPermisionName { get; set;}

		private TableView<TEntity> tableView;

		public ITableView TableView {
			get {
				return tableView;
			}
		}

		public bool SimpleDialog
		{
			get
			{
				return (DialogClass == null);
			}
		}

		public Func<TEntity[], Gtk.Menu> GetPopupMenuFunc { get; set;}

		public bool PopupMenuExist { get{ return GetPopupMenuFunc != null; }}

		public Type EntityClass => typeof(TEntity);

		private OrmObjectMapping()
		{
			
		}

		public Gtk.Menu GetPopupMenu(object[] selected)
		{
			if (GetPopupMenuFunc == null)
				return null;

			return GetPopupMenuFunc(selected.Cast<TEntity>().ToArray());
		}

		public ITdiDialog CreateDialog(params object[] parameters)
		{
			return OrmMain.CreateObjectDialog(EntityClass, parameters);
		}

		#region Механизм уведомлений об изменениях объекта

		object eventSetLock = new Object();

		event EventHandler<OrmObjectUpdatedEventArgs> objectUpdated;

		[Obsolete("Используйте новый механизм уведомлений об изменениях сущностей QS.DomainModel.NotifyChange.NotifyConfiguration.Instance.{Подписка}.")]
		public event EventHandler<OrmObjectUpdatedEventArgs> ObjectUpdated {
			add {
				lock(eventSetLock) {
					objectUpdated += value;
					logger.Debug("Подписка ObjectUpdated на обновления {0} оформлена. {1}", ObjectClass, SubscribersCountText(objectUpdated?.GetInvocationList().Length ?? 0));
				}
			}

			remove {
				lock(eventSetLock) {
					objectUpdated -= value;
					logger.Debug("Кто-то отписался от события ObjectUpdated для объекта {0}. {1}", ObjectClass, SubscribersCountText(objectUpdated?.GetInvocationList().Length ?? 0));
				}
			}
		}

		event EventHandler<OrmObjectUpdatedGenericEventArgs<TEntity>> objectUpdatedGeneric;

		[Obsolete("Используйте новый механизм уведомлений об изменениях сущностей QS.DomainModel.NotifyChange.NotifyConfiguration.Instance.{Подписка}.")]
		public event EventHandler<OrmObjectUpdatedGenericEventArgs<TEntity>> ObjectUpdatedGeneric {
			add {
				lock(eventSetLock) {
					objectUpdatedGeneric += value;
					logger.Debug("Подписка ObjectUpdatedGeneric на обновления {0} оформлена. {1}", ObjectClass, SubscribersCountText(objectUpdatedGeneric?.GetInvocationList().Length ?? 0));
				}
			}

			remove {
				lock(eventSetLock) {
					objectUpdatedGeneric -= value;
					logger.Debug("Кто-то отписался от события ObjectUpdatedGeneric для объекта {0}. {1}", ObjectClass, SubscribersCountText(objectUpdatedGeneric?.GetInvocationList().Length ?? 0));
				}
			}
		}

		public void RaiseObjectUpdated(params object[] updatedSubjects)
		{
			objectUpdatedGeneric?.Invoke(this, new OrmObjectUpdatedGenericEventArgs<TEntity>(updatedSubjects.Cast<TEntity>().ToArray()));
			objectUpdated?.Invoke(this, new OrmObjectUpdatedEventArgs(updatedSubjects));
		}

		private string SubscribersCountText(int count)
		{
			return RusNumber.FormatCase(count, "Всего {0} подписчик.", "Всего {0} подписчика.", "Всего {0} подписчиков.");
		}

#endregion

		#region FluentConfig

		public static OrmObjectMapping<TEntity> Create()
		{
			return new OrmObjectMapping<TEntity> ();
		}

		/// <summary>
		/// Указываем диалог по умолчанию, для открытия сущности
		/// </summary>
		public OrmObjectMapping<TEntity> Dialog<TDialog>()
		{
			this.dialogClass = typeof(TDialog);
			return this;
		}

		/// <summary>
		/// Указываем диалог по умолчанию, для открытия сущности
		/// </summary>
		public OrmObjectMapping<TEntity> Dialog(Type dialogClass)
		{
			this.dialogClass = dialogClass;
			return this;
		}

		/// <summary>
		/// Указываем журнал по умолчанию, для выбора сущностей.
		/// </summary>
		public OrmObjectMapping<TEntity> JournalFilter<TFilter>()
		{
			this.refFilterClass = typeof(TFilter);
			return this;
		}

		/// <summary>
		/// Указываем журнал по умолчанию, для выбора сущностей.
		/// </summary>
		public OrmObjectMapping<TEntity> JournalFilter(Type filterClass)
		{
			this.refFilterClass = filterClass;
			return this;
		}

		/// <summary>
		/// Устанавливаем необходимые права для редактирования сущности.
		/// </summary>
		public OrmObjectMapping<TEntity> EditPermision(string permisionName)
		{
			this.EditPermisionName = permisionName;
			return this;
		}

		/// <summary>
		/// Добавляем в контекстное меню, которое будет отображаться в журнале сущностей.
		/// </summary>
		public OrmObjectMapping<TEntity> PopupMenu(Func<TEntity[], Gtk.Menu> getMenuFunc)
		{
			this.GetPopupMenuFunc = getMenuFunc;
			return this;
		}

		/// <summary>
		/// Устанавливаем будет ли использоваться слайдер для журналов сущности.
		/// </summary>
		public OrmObjectMapping<TEntity> UseSlider(bool? useSlider)
		{
			this.defaultUseSlider = useSlider;
			return this;
		}

		/// <summary>
		/// Создаем простое представление в табличном виде.
		/// </summary>
		public TableView<TEntity> DefaultTableView()
		{
			tableView = new TableView<TEntity> (this);
			return tableView;
		}

		#endregion
	}
}