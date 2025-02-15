using System;
using System.ComponentModel;
using QS.DomainModel.Entity;

namespace QS.ViewModels.Control.EEVM
{
	public class EntityEntryViewModel<TEntity> : PropertyChangedBase, IEntityEntryViewModel, IDisposable
		where TEntity : class
	{
		private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

		public EntityEntryViewModel(
			IPropertyBinder<TEntity> binder = null,
			IEntitySelector entitySelector = null,
			IEntityDlgOpener dlgOpener = null,
			IEntityAutocompleteSelector<TEntity> autocompleteSelector = null,
			IEntityAdapter<TEntity> entityAdapter = null
			)
		{
			if(binder != null)
				this.EntityBinder = binder;
			if(entitySelector != null)
				this.EntitySelector = entitySelector;
			if(dlgOpener != null)
				this.DlgOpener = dlgOpener;
			if(autocompleteSelector != null)
				this.AutocompleteSelector = autocompleteSelector;

			if(entityAdapter != null)
				this.EntityAdapter = entityAdapter;
		}

		#region События

		public event EventHandler Changed;
		public event EventHandler ChangedByUser;
		public event EventHandler<AutocompleteUpdatedEventArgs> AutoCompleteListUpdated;

		#endregion

		#region Работа с сущьностью

		private TEntity entity;

		public virtual TEntity Entity {
			get { return entity; }
			set {
				if(entity == value)
					return;

				if(entity is INotifyPropertyChanged notifyPropertyOldEntity)
					notifyPropertyOldEntity.PropertyChanged -= Entity_PropertyChanged;

				entity = value;

				if(entity is INotifyPropertyChanged notifyPropertyNewEntity) {
					notifyPropertyNewEntity.PropertyChanged += Entity_PropertyChanged; ;
				}

				if(EntityBinder != null)
					EntityBinder.PropertyValue = value;

				OnPropertyChanged();
				OnPropertyChanged(nameof(EntityTitle));
				OnPropertyChanged(nameof(SensitiveCleanButton));
				OnPropertyChanged(nameof(SensitiveViewButton));
				Changed?.Invoke(this, EventArgs.Empty);
			}
		}

		object IEntityEntryViewModel.Entity { get => Entity; set => Entity = (TEntity)value; }


		public TEntity1 GetEntity<TEntity1>() where TEntity1 : class
		{
			return Entity as TEntity1;
		}

		private IEntityAdapter<TEntity> entityAdapter;
		public IEntityAdapter<TEntity> EntityAdapter {
			get => entityAdapter; set {
				entityAdapter = value;
				entityAdapter.EntityEntryViewModel = this;
			}
		}

		#endregion

		#region Публичные свойства

		bool isEditable = true;

		public bool IsEditable {
			get { return isEditable; }
			set {
				isEditable = value;
				OnPropertyChanged(nameof(SensitiveSelectButton));
				OnPropertyChanged(nameof(SensitiveCleanButton));
				OnPropertyChanged(nameof(SensitiveAutoCompleteEntry));
			}
		}

		#endregion

		#region Свойства для использования во View

		public string EntityTitle => Entity == null ? null : DomainHelper.GetTitle(Entity);

		public virtual bool SensitiveSelectButton => IsEditable && EntitySelector != null;
		public virtual bool SensitiveCleanButton => IsEditable && Entity != null;
		public virtual bool SensitiveAutoCompleteEntry => IsEditable && AutocompleteSelector != null;
		public virtual bool SensitiveViewButton => DlgOpener != null && Entity != null;
		#endregion

		#region Выбор сущьности основным способом

		private IEntitySelector entitySelector;
		public IEntitySelector EntitySelector {
			get => entitySelector;
			set {
				entitySelector = value;
				EntitySelector.EntitySelected += EntitySelector_EntitySelected;
				OnPropertyChanged(nameof(SensitiveSelectButton));
			}
		}

		/// <summary>
		/// Открывает диалог выбора сущности
		/// </summary>
		public void OpenSelectDialog()
		{
			entitySelector?.OpenSelector();
		}

		void EntitySelector_EntitySelected(object sender, EntitySelectedEventArgs e)
		{
			Entity = EntityAdapter?.GetEntityByNode(e.Entity);
			ChangedByUser?.Invoke(this, e);
		}

		#endregion

		#region Открытие диалога сущьности

		private IEntityDlgOpener dlgOpener;
		public IEntityDlgOpener DlgOpener {
			get => dlgOpener;
			set {
				dlgOpener = value;
				OnPropertyChanged(nameof(SensitiveViewButton));
			}
		}

		public void OpenViewEntity()
		{
			DlgOpener?.OpenEntityDlg(DomainHelper.GetId(Entity));
		}

		#endregion

		#region AutoCompletion

		public int AutocompleteListSize { get; set; }

		private IEntityAutocompleteSelector<TEntity> autocompleteSelector;
		public IEntityAutocompleteSelector<TEntity> AutocompleteSelector {
			get => autocompleteSelector;
			set {
				autocompleteSelector = value;
				OnPropertyChanged(nameof(SensitiveAutoCompleteEntry));
				autocompleteSelector.AutocompleteLoaded += AutocompleteSelector_AutocompleteLoaded;
			}
		}

		public void AutocompleteTextEdited(string searchText)
		{
			var words = searchText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			AutocompleteSelector?.LoadAutocompletion(words, AutocompleteListSize);
		}

		void AutocompleteSelector_AutocompleteLoaded(object sender, AutocompleteUpdatedEventArgs e)
		{
			AutoCompleteListUpdated?.Invoke(this, e);
		}

		public string GetAutocompleteTitle(object node)
		{
			return AutocompleteSelector.GetTitle(node);
		}

		public void AutocompleteSelectNode(object node)
		{
			Entity = EntityAdapter?.GetEntityByNode(node);
			ChangedByUser?.Invoke(this, EventArgs.Empty);
		}

		#endregion

		#region Обработка событий

		void Entity_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged(nameof(EntityTitle));
		}

		#endregion

		#region Команды View

		public void CleanEntity()
		{
			Entity = null;
			ChangedByUser?.Invoke(this, EventArgs.Empty);
		}

		#endregion

		#region Entity binding

		IPropertyBinder<TEntity> entityBinder;

		public IPropertyBinder<TEntity> EntityBinder {
			get => entityBinder;
			set {
				if(EntityBinder != null)
					EntityBinder.Changed -= EntityBinder_Changed;
				entityBinder = value;
				if(EntityBinder != null) {
					Entity = entityBinder.PropertyValue;
					entityBinder.Changed += EntityBinder_Changed;
				}
			}
		}

		void EntityBinder_Changed(object sender, EventArgs e)
		{
			Entity = entityBinder.PropertyValue;
		}

		#endregion

		public void Dispose()
		{
			if(entity is INotifyPropertyChanged notifyPropertyChanged) {
				notifyPropertyChanged.PropertyChanged -= Entity_PropertyChanged;
			}

			if(EntitySelector is IDisposable esd)
				esd.Dispose();
			if(AutocompleteSelector is IDisposable asd)
				asd.Dispose();
			if(EntityBinder is IDisposable ebd)
				ebd.Dispose();
			if(DlgOpener is IDisposable dod)
				dod.Dispose();
			if(EntityAdapter is IDisposable ead)
				ead.Dispose();
		}
	}
}
