﻿using System;
using QS.DomainModel.Entity;
using QS.DomainModel.UoW;
using QS.Navigation;
using QS.Project.Domain;
using QS.Tdi;
using QS.Validation;

namespace QS.ViewModels.Dialog
{
	public class LegacyEntityDialogViewModelBase<TEntity> : EntityDialogViewModelBase<TEntity>, ILegacyViewModel
		where TEntity : class, IDomainObject, new()
	{

		public ITdiTab TdiTab { get; private set; }

		/// <summary>
		/// Внимание!!! Чтобы аргумент ITdiTab myTab заполнялся автоматически в наследующем классе в конструкторе необходимо указывать такое же имя аргумента "myTab"
		/// </summary>
		/// <param name="myTab">Tdi вкладка в которую будет помещена View от создаваемой ViewModel.</param>
		public LegacyEntityDialogViewModelBase(IEntityUoWBuilder uowBuilder, IUnitOfWorkFactory unitOfWorkFactory, ITdiTab myTab, ITdiCompatibilityNavigation navigation, IValidator validator = null) : base(uowBuilder, unitOfWorkFactory, navigation, validator)
		{
			TdiTab = myTab ?? throw new ArgumentNullException(nameof(myTab));
		}
	}
}
