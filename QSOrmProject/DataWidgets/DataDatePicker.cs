﻿using System;
using System.ComponentModel;
using Gtk.DataBindings;
using System.Data.Bindings;

namespace QSOrmProject
{
	[ToolboxItem (true)]
	[Obsolete("Используйте аналог yDatePicker на Gamma Binding, этот виджет не будет поддерживаться и будет удален просле 14.09.2016.")]
	[Category ("Databound Widgets")]
	[Description ("Adaptable Entry Widget")]
	[GtkWidgetFactoryProvider ("string", "DefaultFactoryCreate")]
	[GtkTypeWidgetFactoryProvider ("stringhandler", "DefaultFactoryCreate", typeof(string))]
	public class DataDatePicker : QSWidgetLib.DatePicker, IAdaptableControl, ICustomDataEvents, IPostableControl
	{
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

		public static IAdaptableControl DefaultFactoryCreate (FactoryInvocationArgs aArgs)
		{
			IAdaptableControl wdg;
			if (aArgs.State == PropertyDefinition.ReadOnly)
				wdg = new DataLabel();
			else
				wdg = new DataEntry();
			wdg.Mappings = aArgs.PropertyName;
			return (wdg);
		}

		private ControlAdaptor adaptor = null;

		/// <summary>
		/// Resolves ControlAdaptor in read-only mode
		/// </summary>
		[Browsable (false), Category ("Data Binding")]
		public ControlAdaptor Adaptor {
			get { return (adaptor); }
		}

		/// <summary>
		/// Defines if DataSource is inherited fom parent controls or not
		/// </summary>
		[Category ("Data Binding"), Description ("Inherited Data Source")]
		public bool InheritedDataSource {
			get { return (adaptor.InheritedDataSource); }
			set { adaptor.InheritedDataSource = value; }
		}

		/// <summary>
		/// DataSource object control is connected to
		/// </summary>
		[Browsable (false), Category ("Data Binding")]
		public object DataSource {
			get { return (adaptor.DataSource); }
			set { adaptor.DataSource = value; }
		}

		/// <summary>
		/// Link to Mappings in connected Adaptor 
		/// </summary>
		[Category ("Data Binding"), Description ("Data mappings")]
		public string Mappings { 
			get { return (adaptor.Mappings); }
			set { adaptor.Mappings = value; }
		}

		/// <summary>
		/// Defines if DataSource is inherited fom parent controls or not
		/// </summary>
		[Category ("Data Binding"), Description ("Inherited Data Source")]
		public bool InheritedBoundaryDataSource {
			get { return (adaptor.InheritedBoundaryDataSource); }
			set { adaptor.InheritedBoundaryDataSource = value; }
		}

		/// <summary>
		/// DataSource object control is connected to
		/// </summary>
		[Browsable (false), Category ("Data Binding")]
		public IObserveable BoundaryDataSource {
			get { return (adaptor.BoundaryDataSource); }
			set { adaptor.BoundaryDataSource = value; }
		}

		/// <summary>
		/// Link to Mappings in connected Adaptor 
		/// </summary>
		[Category ("Data Binding"), Description ("Data Mappings")]
		public string BoundaryMappings { 
			get { return (adaptor.BoundaryMappings); }
			set { adaptor.BoundaryMappings = value; }
		}

		/// <summary>
		/// Overrides basic Get data behaviour
		///
		/// Assigning this avoids any value transfer between object and data
		/// Basic assigning in DateCalendar for example is
		///    	Date = (DateTime) Adaptor.Value;
		/// where Date is the DateCalendar property and Adaptor.Value is direct
		/// reference to the mapped property
		///
		///     public delegate void UserGetDataEvent (ControlAdaptor Adaptor);
		/// </summary>
		public event CustomGetDataEvent CustomGetData {
			add { adaptor.CustomGetData += value; }
			remove { adaptor.CustomGetData -= value; }
		}

		/// <summary>
		/// Overrides basic Post data behaviour
		///
		/// Assigning this avoids any value transfer between object and data
		/// Basic assigning in DateCalendar for example is
		///    	adaptor.Value = Date;
		/// where Date is the DateCalendar property and Adaptor.Value is direct
		/// reference to the mapped property
		///
		///     public delegate void UserPostDataEvent (ControlAdaptor Adaptor);
		/// </summary>
		public event CustomPostDataEvent CustomPostData {
			add { adaptor.CustomPostData += value; }
			remove { adaptor.CustomPostData -= value; }
		}

		/// <summary>
		/// Calls ControlAdaptors method to transfer data, so it can be wrapped
		/// into widget specific things and all checkups
		/// </summary>
		/// <param name="aSender">
		/// Sender object <see cref="System.Object"/>
		/// </param>
		public void CallAdaptorGetData (object aSender)
		{
			Adaptor.InvokeAdapteeDataChange (this, aSender);
		}

		/// <summary>
		/// Notification method activated from Adaptor 
		/// </summary>
		/// <param name="aSender">
		/// Object that made change <see cref="System.Object"/>
		/// </param>
		public virtual void GetDataFromDataSource (object aSender)
		{
			logger.Debug ("Get {0} From DataSource", adaptor.Value);
			adaptor.DataChanged = false;
			if (adaptor.Value is DateTime)
				Date = (DateTime)adaptor.Value;
			else
				Date = default(DateTime);
		}

		/// <summary>
		/// Updates parent object to DataSource object
		/// </summary>
		public virtual void PutDataToDataSource (object aSender)
		{
			adaptor.DataChanged = false;
			if (adaptor.Value != null && (DateTime)adaptor.Value != Date)
				adaptor.Value = Date;
		}
			
		/// <summary>
		/// Overrides OnChanged to put data in DataSource if needed
		/// </summary>
		protected void OnChange(object sender, EventArgs e)
		{
			adaptor.DemandInstantPost();
		}
			
		/// <summary>
		/// Creates Widget 
		/// </summary>
		public DataDatePicker()
			: base()
		{
			this.DateChanged += OnChange;
			adaptor = new GtkControlAdaptor (this, true);
		}

		/// <summary>
		/// Creates Widget 
		/// </summary>
		/// <param name="aMappings">
		/// Mappings with this widget <see cref="System.String"/>
		/// </param>
		public DataDatePicker (string aMappings)
			: base()
		{
			this.DateChanged += OnChange;
			adaptor = new GtkControlAdaptor (this, true, aMappings);
		}

		/// <summary>
		/// Creates Widget 
		/// </summary>
		/// <param name="aDataSource">
		/// DataSource connected to this widget <see cref="System.Object"/>
		/// </param>
		/// <param name="aMappings">
		/// Mappings with this widget <see cref="System.String"/>
		/// </param>
		public DataDatePicker (object aDataSource, string aMappings)
			: base()
		{
			this.DateChanged += OnChange;
			adaptor = new GtkControlAdaptor (this, true, aDataSource, aMappings);
		}
	}
}

