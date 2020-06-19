using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using NHibernate.Collection.Generic;
using NHibernate.Engine;
using NHibernate.Persister.Collection;

namespace QS.Project.DB
{
	public class PersistentObservableGenericList<T> : PersistentGenericList<T>, INotifyCollectionChanged,
													  INotifyPropertyChanged, IList<T>
	{

		public PersistentObservableGenericList(ISessionImplementor sessionImplementor)
			: base(sessionImplementor)
		{
		}

		public PersistentObservableGenericList(ISessionImplementor sessionImplementor, IList<T> list)
			: base(sessionImplementor, list)
		{
			CaptureEventHandlers(list);
		}

		public PersistentObservableGenericList()
		{
		}

		#region INotifyCollectionChanged implementation

		private NotifyCollectionChangedEventHandler collectionChanged;

		public event NotifyCollectionChangedEventHandler CollectionChanged {
			add {
				Initialize(false);
				collectionChanged += value;
			}
			remove { collectionChanged -= value; }
		}

		#endregion

		#region INotifyPropertyChanged implementation

		private PropertyChangedEventHandler propertyChanged;

		public event PropertyChangedEventHandler PropertyChanged {
			add {
				Initialize(false);
				propertyChanged += value;
			}
			remove { propertyChanged += value; }
		}

		#endregion

		public override void BeforeInitialize(ICollectionPersister persister, int anticipatedSize)
		{
			base.BeforeInitialize(persister, anticipatedSize);
			CaptureEventHandlers(WrappedList);
		}

		private void CaptureEventHandlers(ICollection<T> coll)
		{
			if(coll is INotifyCollectionChanged notificableCollection)
				notificableCollection.CollectionChanged += OnCollectionChanged;

			if(coll is INotifyPropertyChanged propertyNotificableColl)
				propertyNotificableColl.PropertyChanged += OnPropertyChanged;
		}

		private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			propertyChanged?.Invoke(this, e);
		}

		private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			collectionChanged?.Invoke(this, e);
		}
	}
}
