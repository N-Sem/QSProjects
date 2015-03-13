
// This file has been generated by the GUI designer. Do not modify.
namespace QSHistoryLog {
	public partial class HistoryView {
		private global::Gtk.VBox vbox2;
		
		private global::Gtk.Table table1;
		
		private global::QSOrmProject.EnumComboBox comboAction;
		
		private global::Gtk.DataBindings.DataSpecComboBox comboProperty;
		
		private global::Gtk.ComboBox comboUsers;
		
		private global::Gtk.DataBindings.DataSpecComboBox datacomboObject;
		
		private global::Gtk.HBox hbox4;
		
		private global::Gtk.Entry entrySearch;
		
		private global::Gtk.Button buttonSearch;
		
		private global::Gtk.Label label3;
		
		private global::Gtk.Label label4;
		
		private global::Gtk.Label label5;
		
		private global::Gtk.Label label6;
		
		private global::Gtk.Label label8;
		
		private global::QSWidgetLib.SelectPeriod selectperiod;
		
		private global::Gtk.VPaned vpaned1;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gtk.DataBindings.DataTreeView datatreeChangesets;
		
		private global::Gtk.VBox vbox3;
		
		private global::Gtk.Label label7;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow1;
		
		private global::Gtk.DataBindings.DataTreeView datatreeChanges;
		
		protected virtual void Build() {
			global::Stetic.Gui.Initialize(this);
			// Widget QSHistoryLog.HistoryView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "QSHistoryLog.HistoryView";
			// Container child QSHistoryLog.HistoryView.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table(((uint)(5)), ((uint)(3)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.comboAction = new global::QSOrmProject.EnumComboBox();
			this.comboAction.Name = "comboAction";
			this.comboAction.ShowSpecialStateAll = true;
			this.comboAction.ShowSpecialStateNot = false;
			this.table1.Add(this.comboAction);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table1[this.comboAction]));
			w1.TopAttach = ((uint)(3));
			w1.BottomAttach = ((uint)(4));
			w1.LeftAttach = ((uint)(1));
			w1.RightAttach = ((uint)(2));
			w1.XOptions = ((global::Gtk.AttachOptions)(4));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.comboProperty = new global::Gtk.DataBindings.DataSpecComboBox();
			this.comboProperty.Name = "comboProperty";
			this.comboProperty.ColumnMappings = "DisplayName";
			this.comboProperty.InheritedDataSource = false;
			this.comboProperty.InheritedBoundaryDataSource = false;
			this.comboProperty.ShowSpecialStateAll = true;
			this.comboProperty.ShowSpecialStateNot = false;
			this.table1.Add(this.comboProperty);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1[this.comboProperty]));
			w2.TopAttach = ((uint)(1));
			w2.BottomAttach = ((uint)(2));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.comboUsers = new global::Gtk.ComboBox();
			this.comboUsers.Name = "comboUsers";
			this.table1.Add(this.comboUsers);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1[this.comboUsers]));
			w3.TopAttach = ((uint)(2));
			w3.BottomAttach = ((uint)(3));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.datacomboObject = new global::Gtk.DataBindings.DataSpecComboBox();
			this.datacomboObject.Name = "datacomboObject";
			this.datacomboObject.ColumnMappings = "DisplayName";
			this.datacomboObject.InheritedDataSource = false;
			this.datacomboObject.InheritedBoundaryDataSource = false;
			this.datacomboObject.ShowSpecialStateAll = true;
			this.datacomboObject.ShowSpecialStateNot = false;
			this.table1.Add(this.datacomboObject);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1[this.datacomboObject]));
			w4.LeftAttach = ((uint)(1));
			w4.RightAttach = ((uint)(2));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.entrySearch = new global::Gtk.Entry();
			this.entrySearch.CanFocus = true;
			this.entrySearch.Name = "entrySearch";
			this.entrySearch.IsEditable = true;
			this.entrySearch.InvisibleChar = '●';
			this.hbox4.Add(this.entrySearch);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.entrySearch]));
			w5.Position = 0;
			// Container child hbox4.Gtk.Box+BoxChild
			this.buttonSearch = new global::Gtk.Button();
			this.buttonSearch.CanFocus = true;
			this.buttonSearch.Name = "buttonSearch";
			this.buttonSearch.UseUnderline = true;
			global::Gtk.Image w6 = new global::Gtk.Image();
			w6.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-find", global::Gtk.IconSize.Menu);
			this.buttonSearch.Image = w6;
			this.hbox4.Add(this.buttonSearch);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.buttonSearch]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			this.table1.Add(this.hbox4);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1[this.hbox4]));
			w8.TopAttach = ((uint)(4));
			w8.BottomAttach = ((uint)(5));
			w8.LeftAttach = ((uint)(1));
			w8.RightAttach = ((uint)(2));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Пользователь:");
			this.table1.Add(this.label3);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1[this.label3]));
			w9.TopAttach = ((uint)(2));
			w9.BottomAttach = ((uint)(3));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Действие:");
			this.table1.Add(this.label4);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1[this.label4]));
			w10.TopAttach = ((uint)(3));
			w10.BottomAttach = ((uint)(4));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Поиск по изменениям:");
			this.table1.Add(this.label5);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1[this.label5]));
			w11.TopAttach = ((uint)(4));
			w11.BottomAttach = ((uint)(5));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label6 = new global::Gtk.Label();
			this.label6.Name = "label6";
			this.label6.Xalign = 1F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString("Объект изменений:");
			this.table1.Add(this.label6);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table1[this.label6]));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label8 = new global::Gtk.Label();
			this.label8.Name = "label8";
			this.label8.Xalign = 1F;
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString("Реквизит:");
			this.table1.Add(this.label8);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1[this.label8]));
			w13.TopAttach = ((uint)(1));
			w13.BottomAttach = ((uint)(2));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.selectperiod = new global::QSWidgetLib.SelectPeriod();
			this.selectperiod.Events = ((global::Gdk.EventMask)(256));
			this.selectperiod.Name = "selectperiod";
			this.selectperiod.DateBegin = new global::System.DateTime(0);
			this.selectperiod.DateEnd = new global::System.DateTime(0);
			this.selectperiod.AutoDateSeparation = true;
			this.selectperiod.ShowToday = true;
			this.selectperiod.ShowWeek = true;
			this.selectperiod.ShowMonth = true;
			this.selectperiod.Show3Month = true;
			this.selectperiod.Show6Month = false;
			this.selectperiod.ShowYear = false;
			this.selectperiod.ShowAllTime = false;
			this.selectperiod.ShowCurWeek = false;
			this.selectperiod.ShowCurMonth = false;
			this.selectperiod.ShowCurQuarter = false;
			this.selectperiod.ShowCurYear = false;
			this.table1.Add(this.selectperiod);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table1[this.selectperiod]));
			w14.TopAttach = ((uint)(1));
			w14.BottomAttach = ((uint)(5));
			w14.LeftAttach = ((uint)(2));
			w14.RightAttach = ((uint)(3));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox2.Add(this.table1);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.table1]));
			w15.Position = 0;
			w15.Expand = false;
			w15.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.vpaned1 = new global::Gtk.VPaned();
			this.vpaned1.CanFocus = true;
			this.vpaned1.Name = "vpaned1";
			this.vpaned1.Position = 203;
			// Container child vpaned1.Gtk.Paned+PanedChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.datatreeChangesets = new global::Gtk.DataBindings.DataTreeView();
			this.datatreeChangesets.CanFocus = true;
			this.datatreeChangesets.Name = "datatreeChangesets";
			this.datatreeChangesets.CursorPointsEveryType = false;
			this.datatreeChangesets.InheritedDataSource = false;
			this.datatreeChangesets.InheritedBoundaryDataSource = false;
			this.datatreeChangesets.InheritedDataSource = false;
			this.datatreeChangesets.InheritedBoundaryDataSource = false;
			this.datatreeChangesets.ColumnMappings = "{QSHistoryLog.HistoryChangeSet} ChangeTimeText[Время]; UserName[Пользователь]; ObjectTitle[Объект]; OperationText[Действие]";
			this.GtkScrolledWindow.Add(this.datatreeChangesets);
			this.vpaned1.Add(this.GtkScrolledWindow);
			global::Gtk.Paned.PanedChild w17 = ((global::Gtk.Paned.PanedChild)(this.vpaned1[this.GtkScrolledWindow]));
			w17.Resize = false;
			w17.Shrink = false;
			// Container child vpaned1.Gtk.Paned+PanedChild
			this.vbox3 = new global::Gtk.VBox();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.label7 = new global::Gtk.Label();
			this.label7.Name = "label7";
			this.label7.Xalign = 0F;
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString("Детали изменений:");
			this.vbox3.Add(this.label7);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.label7]));
			w18.Position = 0;
			w18.Expand = false;
			w18.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.datatreeChanges = new global::Gtk.DataBindings.DataTreeView();
			this.datatreeChanges.CanFocus = true;
			this.datatreeChanges.Name = "datatreeChanges";
			this.datatreeChanges.CursorPointsEveryType = false;
			this.datatreeChanges.InheritedDataSource = false;
			this.datatreeChanges.Mappings = "";
			this.datatreeChanges.InheritedBoundaryDataSource = false;
			this.datatreeChanges.BoundaryMappings = "";
			this.datatreeChanges.InheritedDataSource = false;
			this.datatreeChanges.Mappings = "";
			this.datatreeChanges.InheritedBoundaryDataSource = false;
			this.datatreeChanges.BoundaryMappings = "";
			this.datatreeChanges.ColumnMappings = "{QSHistoryLog.FieldChange} FieldName[Поле]; TypeText[Операция]; NewPangoText[Новое значение]; OldPangoText[Старое значение]";
			this.GtkScrolledWindow1.Add(this.datatreeChanges);
			this.vbox3.Add(this.GtkScrolledWindow1);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.GtkScrolledWindow1]));
			w20.Position = 1;
			this.vpaned1.Add(this.vbox3);
			global::Gtk.Paned.PanedChild w21 = ((global::Gtk.Paned.PanedChild)(this.vpaned1[this.vbox3]));
			w21.Resize = false;
			w21.Shrink = false;
			this.vbox2.Add(this.vpaned1);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.vpaned1]));
			w22.Position = 1;
			this.Add(this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll();
			}
			this.Hide();
			this.selectperiod.DatesChanged += new global::System.EventHandler(this.OnSelectperiodDatesChanged);
			this.entrySearch.Activated += new global::System.EventHandler(this.OnEntrySearchActivated);
			this.buttonSearch.Clicked += new global::System.EventHandler(this.OnButtonSearchClicked);
			this.datacomboObject.ItemSelected += new global::System.EventHandler<QSOrmProject.EnumItemClickedEventArgs>(this.OnDatacomboObjectItemSelected);
			this.comboUsers.Changed += new global::System.EventHandler(this.OnComboUsersChanged);
			this.comboProperty.ItemSelected += new global::System.EventHandler<QSOrmProject.EnumItemClickedEventArgs>(this.OnComboPropertyItemSelected);
			this.comboAction.EnumItemSelected += new global::System.EventHandler<QSOrmProject.EnumItemClickedEventArgs>(this.OnComboActionEnumItemSelected);
			this.datatreeChangesets.CursorChanged += new global::System.EventHandler(this.OnDatatreeChangesetsCursorChanged);
		}
	}
}
