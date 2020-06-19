using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace QS.Project.DB
{
	public class ObservableListConvention :
	IHasManyConvention, IHasManyToManyConvention, ICollectionConvention
	{

		// For one-to-many relations
		public void Apply(IOneToManyCollectionInstance instance)
		{

			ApplyObservableListConvention(instance);
		}

		// For many-to-many relations
		public void Apply(IManyToManyCollectionInstance instance)
		{

			ApplyObservableListConvention(instance);
		}

		// For collections of components or simple types
		public void Apply(ICollectionInstance instance)
		{

			ApplyObservableListConvention(instance);
		}

		private void ApplyObservableListConvention(ICollectionInstance instance)
		{

			Type collectionType =
				typeof(ObservableCollectionType<>)
				.MakeGenericType(instance.ChildType);
			instance.CollectionType(collectionType);
		}
	}
}
