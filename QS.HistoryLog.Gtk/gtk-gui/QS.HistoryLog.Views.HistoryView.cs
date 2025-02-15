
// This file has been generated by the GUI designer. Do not modify.
namespace QS.HistoryLog.Views
{
	public partial class HistoryView
	{
		private global::Gamma.GtkWidgets.yVBox yvbox1;

		private global::Gamma.GtkWidgets.yVBox yvbox3;

		private global::Gamma.GtkWidgets.yHBox yFilterbox;

		private global::Gamma.GtkWidgets.yTable ytable1;

		private global::Gamma.Widgets.yEnumComboBox ycomboAction;

		private global::QS.Widgets.GtkUI.SpecialListComboBox ycomboEntities;

		private global::QS.Widgets.GtkUI.SpecialListComboBox ycomboFields;

		private global::QS.Widgets.GtkUI.SpecialListComboBox ycomboUsers;

		private global::Gamma.GtkWidgets.yLabel ylabel6;

		private global::Gamma.GtkWidgets.yLabel ylabel7;

		private global::Gamma.GtkWidgets.yLabel ylabel8;

		private global::Gamma.GtkWidgets.yLabel ylabel9;

		private global::Gamma.GtkWidgets.yVBox yvbox4;

		private global::Gamma.GtkWidgets.yVBox yvbox5;

		private global::Gamma.GtkWidgets.yLabel ylabel2;

		private global::Gamma.GtkWidgets.yVBox yvbox6;

		private global::Gamma.GtkWidgets.yTable ytable3;

		private global::Gamma.GtkWidgets.yRadioButton yPeriodMonth;

		private global::Gamma.GtkWidgets.yRadioButton yPeriodThreeMonth;

		private global::Gamma.GtkWidgets.yRadioButton yPeriodToday;

		private global::Gamma.GtkWidgets.yRadioButton yPeriodWeek;

		private global::Gamma.GtkWidgets.yHBox yhbox2;

		private global::QS.Widgets.GtkUI.DatePicker ydateStartperiodpicker;

		private global::QS.Widgets.GtkUI.DatePicker ydateEndperiodpicker;

		private global::Gamma.GtkWidgets.yTable ytable2;

		private global::Gamma.GtkWidgets.yButton ybutton1;

		private global::Gamma.GtkWidgets.yEntry yentryChanged;

		private global::Gamma.GtkWidgets.yEntry yentryId;

		private global::Gamma.GtkWidgets.yEntry yentryName;

		private global::Gamma.GtkWidgets.yLabel ylabel3;

		private global::Gamma.GtkWidgets.yLabel ylabel4;

		private global::Gamma.GtkWidgets.yLabel ylabel5;

		private global::Gamma.GtkWidgets.yButton yFilterbutton;

		private global::Gtk.ScrolledWindow yscrolledwindow;

		private global::Gamma.GtkWidgets.yTreeView ytreeChangesets;

		private global::Gamma.GtkWidgets.yVBox yvbox2;

		private global::Gamma.GtkWidgets.yLabel ylabel1;

		private global::Gamma.GtkWidgets.yVBox yPropertyvbox;

		private global::Gtk.ScrolledWindow scrolledwindow2;

		private global::Gamma.GtkWidgets.yTreeView ytreeFieldChange;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget QS.HistoryLog.Views.HistoryView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "QS.HistoryLog.Views.HistoryView";
			// Container child QS.HistoryLog.Views.HistoryView.Gtk.Container+ContainerChild
			this.yvbox1 = new global::Gamma.GtkWidgets.yVBox();
			this.yvbox1.Name = "yvbox1";
			this.yvbox1.Spacing = 6;
			// Container child yvbox1.Gtk.Box+BoxChild
			this.yvbox3 = new global::Gamma.GtkWidgets.yVBox();
			this.yvbox3.Name = "yvbox3";
			this.yvbox3.Spacing = 6;
			// Container child yvbox3.Gtk.Box+BoxChild
			this.yFilterbox = new global::Gamma.GtkWidgets.yHBox();
			this.yFilterbox.Name = "yFilterbox";
			this.yFilterbox.Spacing = 6;
			// Container child yFilterbox.Gtk.Box+BoxChild
			this.ytable1 = new global::Gamma.GtkWidgets.yTable();
			this.ytable1.Name = "ytable1";
			this.ytable1.NRows = ((uint)(4));
			this.ytable1.NColumns = ((uint)(2));
			this.ytable1.RowSpacing = ((uint)(6));
			this.ytable1.ColumnSpacing = ((uint)(6));
			// Container child ytable1.Gtk.Table+TableChild
			this.ycomboAction = new global::Gamma.Widgets.yEnumComboBox();
			this.ycomboAction.Name = "ycomboAction";
			this.ycomboAction.ShowSpecialStateAll = true;
			this.ycomboAction.ShowSpecialStateNot = false;
			this.ycomboAction.UseShortTitle = false;
			this.ycomboAction.DefaultFirst = false;
			this.ytable1.Add(this.ycomboAction);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.ytable1[this.ycomboAction]));
			w1.TopAttach = ((uint)(2));
			w1.BottomAttach = ((uint)(3));
			w1.LeftAttach = ((uint)(1));
			w1.RightAttach = ((uint)(2));
			w1.XOptions = ((global::Gtk.AttachOptions)(4));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable1.Gtk.Table+TableChild
			this.ycomboEntities = new global::QS.Widgets.GtkUI.SpecialListComboBox();
			this.ycomboEntities.Name = "ycomboEntities";
			this.ycomboEntities.AddIfNotExist = false;
			this.ycomboEntities.DefaultFirst = false;
			this.ycomboEntities.ShowSpecialStateAll = true;
			this.ycomboEntities.ShowSpecialStateNot = false;
			this.ytable1.Add(this.ycomboEntities);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.ytable1[this.ycomboEntities]));
			w2.TopAttach = ((uint)(1));
			w2.BottomAttach = ((uint)(2));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable1.Gtk.Table+TableChild
			this.ycomboFields = new global::QS.Widgets.GtkUI.SpecialListComboBox();
			this.ycomboFields.Name = "ycomboFields";
			this.ycomboFields.AddIfNotExist = false;
			this.ycomboFields.DefaultFirst = false;
			this.ycomboFields.ShowSpecialStateAll = true;
			this.ycomboFields.ShowSpecialStateNot = false;
			this.ytable1.Add(this.ycomboFields);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.ytable1[this.ycomboFields]));
			w3.TopAttach = ((uint)(3));
			w3.BottomAttach = ((uint)(4));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable1.Gtk.Table+TableChild
			this.ycomboUsers = new global::QS.Widgets.GtkUI.SpecialListComboBox();
			this.ycomboUsers.Name = "ycomboUsers";
			this.ycomboUsers.AddIfNotExist = false;
			this.ycomboUsers.DefaultFirst = false;
			this.ycomboUsers.ShowSpecialStateAll = true;
			this.ycomboUsers.ShowSpecialStateNot = false;
			this.ytable1.Add(this.ycomboUsers);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.ytable1[this.ycomboUsers]));
			w4.LeftAttach = ((uint)(1));
			w4.RightAttach = ((uint)(2));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable1.Gtk.Table+TableChild
			this.ylabel6 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel6.Name = "ylabel6";
			this.ylabel6.Xalign = 1F;
			this.ylabel6.LabelProp = global::Mono.Unix.Catalog.GetString("Пользователь:");
			this.ytable1.Add(this.ylabel6);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.ytable1[this.ylabel6]));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable1.Gtk.Table+TableChild
			this.ylabel7 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel7.Name = "ylabel7";
			this.ylabel7.Xalign = 1F;
			this.ylabel7.LabelProp = global::Mono.Unix.Catalog.GetString("Объект изменений:");
			this.ytable1.Add(this.ylabel7);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.ytable1[this.ylabel7]));
			w6.TopAttach = ((uint)(1));
			w6.BottomAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable1.Gtk.Table+TableChild
			this.ylabel8 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel8.Name = "ylabel8";
			this.ylabel8.Xalign = 1F;
			this.ylabel8.LabelProp = global::Mono.Unix.Catalog.GetString("Действие с объектом:");
			this.ytable1.Add(this.ylabel8);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.ytable1[this.ylabel8]));
			w7.TopAttach = ((uint)(2));
			w7.BottomAttach = ((uint)(3));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable1.Gtk.Table+TableChild
			this.ylabel9 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel9.Name = "ylabel9";
			this.ylabel9.Xalign = 1F;
			this.ylabel9.LabelProp = global::Mono.Unix.Catalog.GetString("Реквизит объекта:");
			this.ytable1.Add(this.ylabel9);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.ytable1[this.ylabel9]));
			w8.TopAttach = ((uint)(3));
			w8.BottomAttach = ((uint)(4));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			this.yFilterbox.Add(this.ytable1);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.yFilterbox[this.ytable1]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			// Container child yFilterbox.Gtk.Box+BoxChild
			this.yvbox4 = new global::Gamma.GtkWidgets.yVBox();
			this.yvbox4.Name = "yvbox4";
			this.yvbox4.Spacing = 6;
			// Container child yvbox4.Gtk.Box+BoxChild
			this.yvbox5 = new global::Gamma.GtkWidgets.yVBox();
			this.yvbox5.Name = "yvbox5";
			this.yvbox5.Spacing = 6;
			// Container child yvbox5.Gtk.Box+BoxChild
			this.ylabel2 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel2.Name = "ylabel2";
			this.ylabel2.LabelProp = global::Mono.Unix.Catalog.GetString("Выбор периода");
			this.yvbox5.Add(this.ylabel2);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.yvbox5[this.ylabel2]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child yvbox5.Gtk.Box+BoxChild
			this.yvbox6 = new global::Gamma.GtkWidgets.yVBox();
			this.yvbox6.Name = "yvbox6";
			this.yvbox6.Spacing = 6;
			// Container child yvbox6.Gtk.Box+BoxChild
			this.ytable3 = new global::Gamma.GtkWidgets.yTable();
			this.ytable3.Name = "ytable3";
			this.ytable3.NRows = ((uint)(2));
			this.ytable3.NColumns = ((uint)(2));
			this.ytable3.Homogeneous = true;
			this.ytable3.RowSpacing = ((uint)(6));
			this.ytable3.ColumnSpacing = ((uint)(6));
			// Container child ytable3.Gtk.Table+TableChild
			this.yPeriodMonth = new global::Gamma.GtkWidgets.yRadioButton();
			this.yPeriodMonth.CanFocus = true;
			this.yPeriodMonth.Name = "yPeriodMonth";
			this.yPeriodMonth.Label = global::Mono.Unix.Catalog.GetString("За месяц");
			this.yPeriodMonth.DrawIndicator = true;
			this.yPeriodMonth.UseUnderline = true;
			this.yPeriodMonth.Group = new global::GLib.SList(global::System.IntPtr.Zero);
			this.ytable3.Add(this.yPeriodMonth);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.ytable3[this.yPeriodMonth]));
			w11.LeftAttach = ((uint)(1));
			w11.RightAttach = ((uint)(2));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable3.Gtk.Table+TableChild
			this.yPeriodThreeMonth = new global::Gamma.GtkWidgets.yRadioButton();
			this.yPeriodThreeMonth.CanFocus = true;
			this.yPeriodThreeMonth.Name = "yPeriodThreeMonth";
			this.yPeriodThreeMonth.Label = global::Mono.Unix.Catalog.GetString("За 3 месяца");
			this.yPeriodThreeMonth.DrawIndicator = true;
			this.yPeriodThreeMonth.UseUnderline = true;
			this.yPeriodThreeMonth.Group = this.yPeriodMonth.Group;
			this.ytable3.Add(this.yPeriodThreeMonth);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.ytable3[this.yPeriodThreeMonth]));
			w12.TopAttach = ((uint)(1));
			w12.BottomAttach = ((uint)(2));
			w12.LeftAttach = ((uint)(1));
			w12.RightAttach = ((uint)(2));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable3.Gtk.Table+TableChild
			this.yPeriodToday = new global::Gamma.GtkWidgets.yRadioButton();
			this.yPeriodToday.CanFocus = true;
			this.yPeriodToday.Name = "yPeriodToday";
			this.yPeriodToday.Label = global::Mono.Unix.Catalog.GetString("Сегодня");
			this.yPeriodToday.DrawIndicator = true;
			this.yPeriodToday.UseUnderline = true;
			this.yPeriodToday.Group = this.yPeriodMonth.Group;
			this.ytable3.Add(this.yPeriodToday);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.ytable3[this.yPeriodToday]));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable3.Gtk.Table+TableChild
			this.yPeriodWeek = new global::Gamma.GtkWidgets.yRadioButton();
			this.yPeriodWeek.CanFocus = true;
			this.yPeriodWeek.Name = "yPeriodWeek";
			this.yPeriodWeek.Label = global::Mono.Unix.Catalog.GetString("За 7 дней");
			this.yPeriodWeek.DrawIndicator = true;
			this.yPeriodWeek.UseUnderline = true;
			this.yPeriodWeek.Group = this.yPeriodMonth.Group;
			this.ytable3.Add(this.yPeriodWeek);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.ytable3[this.yPeriodWeek]));
			w14.TopAttach = ((uint)(1));
			w14.BottomAttach = ((uint)(2));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			this.yvbox6.Add(this.ytable3);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.yvbox6[this.ytable3]));
			w15.Position = 0;
			w15.Expand = false;
			w15.Fill = false;
			// Container child yvbox6.Gtk.Box+BoxChild
			this.yhbox2 = new global::Gamma.GtkWidgets.yHBox();
			this.yhbox2.Name = "yhbox2";
			this.yhbox2.Spacing = 6;
			// Container child yhbox2.Gtk.Box+BoxChild
			this.ydateStartperiodpicker = new global::QS.Widgets.GtkUI.DatePicker();
			this.ydateStartperiodpicker.Events = ((global::Gdk.EventMask)(256));
			this.ydateStartperiodpicker.Name = "ydateStartperiodpicker";
			this.ydateStartperiodpicker.WithTime = true;
			this.ydateStartperiodpicker.HideCalendarButton = false;
			this.ydateStartperiodpicker.Date = new global::System.DateTime(0);
			this.ydateStartperiodpicker.IsEditable = true;
			this.ydateStartperiodpicker.AutoSeparation = false;
			this.yhbox2.Add(this.ydateStartperiodpicker);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.yhbox2[this.ydateStartperiodpicker]));
			w16.Position = 0;
			// Container child yhbox2.Gtk.Box+BoxChild
			this.ydateEndperiodpicker = new global::QS.Widgets.GtkUI.DatePicker();
			this.ydateEndperiodpicker.Events = ((global::Gdk.EventMask)(256));
			this.ydateEndperiodpicker.Name = "ydateEndperiodpicker";
			this.ydateEndperiodpicker.WithTime = true;
			this.ydateEndperiodpicker.HideCalendarButton = false;
			this.ydateEndperiodpicker.Date = new global::System.DateTime(0);
			this.ydateEndperiodpicker.IsEditable = true;
			this.ydateEndperiodpicker.AutoSeparation = false;
			this.yhbox2.Add(this.ydateEndperiodpicker);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.yhbox2[this.ydateEndperiodpicker]));
			w17.Position = 1;
			this.yvbox6.Add(this.yhbox2);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.yvbox6[this.yhbox2]));
			w18.Position = 1;
			w18.Expand = false;
			w18.Fill = false;
			this.yvbox5.Add(this.yvbox6);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.yvbox5[this.yvbox6]));
			w19.Position = 1;
			w19.Expand = false;
			w19.Fill = false;
			this.yvbox4.Add(this.yvbox5);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.yvbox4[this.yvbox5]));
			w20.Position = 0;
			w20.Expand = false;
			w20.Fill = false;
			this.yFilterbox.Add(this.yvbox4);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.yFilterbox[this.yvbox4]));
			w21.Position = 1;
			w21.Expand = false;
			w21.Fill = false;
			// Container child yFilterbox.Gtk.Box+BoxChild
			this.ytable2 = new global::Gamma.GtkWidgets.yTable();
			this.ytable2.Name = "ytable2";
			this.ytable2.NRows = ((uint)(3));
			this.ytable2.NColumns = ((uint)(3));
			this.ytable2.RowSpacing = ((uint)(6));
			this.ytable2.ColumnSpacing = ((uint)(6));
			// Container child ytable2.Gtk.Table+TableChild
			this.ybutton1 = new global::Gamma.GtkWidgets.yButton();
			this.ybutton1.CanFocus = true;
			this.ybutton1.Name = "ybutton1";
			this.ybutton1.UseUnderline = true;
			global::Gtk.Image w22 = new global::Gtk.Image();
			w22.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-find", global::Gtk.IconSize.Menu);
			this.ybutton1.Image = w22;
			this.ytable2.Add(this.ybutton1);
			global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.ytable2[this.ybutton1]));
			w23.BottomAttach = ((uint)(3));
			w23.LeftAttach = ((uint)(2));
			w23.RightAttach = ((uint)(3));
			w23.XOptions = ((global::Gtk.AttachOptions)(4));
			w23.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable2.Gtk.Table+TableChild
			this.yentryChanged = new global::Gamma.GtkWidgets.yEntry();
			this.yentryChanged.CanFocus = true;
			this.yentryChanged.Name = "yentryChanged";
			this.yentryChanged.IsEditable = true;
			this.yentryChanged.InvisibleChar = '•';
			this.ytable2.Add(this.yentryChanged);
			global::Gtk.Table.TableChild w24 = ((global::Gtk.Table.TableChild)(this.ytable2[this.yentryChanged]));
			w24.TopAttach = ((uint)(2));
			w24.BottomAttach = ((uint)(3));
			w24.LeftAttach = ((uint)(1));
			w24.RightAttach = ((uint)(2));
			w24.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable2.Gtk.Table+TableChild
			this.yentryId = new global::Gamma.GtkWidgets.yEntry();
			this.yentryId.CanFocus = true;
			this.yentryId.Name = "yentryId";
			this.yentryId.IsEditable = true;
			this.yentryId.InvisibleChar = '•';
			this.ytable2.Add(this.yentryId);
			global::Gtk.Table.TableChild w25 = ((global::Gtk.Table.TableChild)(this.ytable2[this.yentryId]));
			w25.TopAttach = ((uint)(1));
			w25.BottomAttach = ((uint)(2));
			w25.LeftAttach = ((uint)(1));
			w25.RightAttach = ((uint)(2));
			w25.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable2.Gtk.Table+TableChild
			this.yentryName = new global::Gamma.GtkWidgets.yEntry();
			this.yentryName.CanFocus = true;
			this.yentryName.Name = "yentryName";
			this.yentryName.IsEditable = true;
			this.yentryName.InvisibleChar = '•';
			this.ytable2.Add(this.yentryName);
			global::Gtk.Table.TableChild w26 = ((global::Gtk.Table.TableChild)(this.ytable2[this.yentryName]));
			w26.LeftAttach = ((uint)(1));
			w26.RightAttach = ((uint)(2));
			w26.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable2.Gtk.Table+TableChild
			this.ylabel3 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel3.Name = "ylabel3";
			this.ylabel3.Xalign = 1F;
			this.ylabel3.LabelProp = global::Mono.Unix.Catalog.GetString("Поиск в имени объекта:");
			this.ytable2.Add(this.ylabel3);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.ytable2[this.ylabel3]));
			w27.XOptions = ((global::Gtk.AttachOptions)(4));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable2.Gtk.Table+TableChild
			this.ylabel4 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel4.Name = "ylabel4";
			this.ylabel4.Xalign = 1F;
			this.ylabel4.LabelProp = global::Mono.Unix.Catalog.GetString("Поиск по коду объекта:");
			this.ytable2.Add(this.ylabel4);
			global::Gtk.Table.TableChild w28 = ((global::Gtk.Table.TableChild)(this.ytable2[this.ylabel4]));
			w28.TopAttach = ((uint)(1));
			w28.BottomAttach = ((uint)(2));
			w28.XOptions = ((global::Gtk.AttachOptions)(4));
			w28.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable2.Gtk.Table+TableChild
			this.ylabel5 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel5.Name = "ylabel5";
			this.ylabel5.Xalign = 1F;
			this.ylabel5.LabelProp = global::Mono.Unix.Catalog.GetString("Поиск в изменениях:");
			this.ytable2.Add(this.ylabel5);
			global::Gtk.Table.TableChild w29 = ((global::Gtk.Table.TableChild)(this.ytable2[this.ylabel5]));
			w29.TopAttach = ((uint)(2));
			w29.BottomAttach = ((uint)(3));
			w29.XOptions = ((global::Gtk.AttachOptions)(4));
			w29.YOptions = ((global::Gtk.AttachOptions)(4));
			this.yFilterbox.Add(this.ytable2);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.yFilterbox[this.ytable2]));
			w30.Position = 2;
			w30.Expand = false;
			w30.Fill = false;
			this.yvbox3.Add(this.yFilterbox);
			global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.yvbox3[this.yFilterbox]));
			w31.Position = 0;
			// Container child yvbox3.Gtk.Box+BoxChild
			this.yFilterbutton = new global::Gamma.GtkWidgets.yButton();
			this.yFilterbutton.CanFocus = true;
			this.yFilterbutton.Name = "yFilterbutton";
			this.yFilterbutton.UseUnderline = true;
			this.yFilterbutton.Label = global::Mono.Unix.Catalog.GetString("Скрыть фильтр");
			this.yvbox3.Add(this.yFilterbutton);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.yvbox3[this.yFilterbutton]));
			w32.Position = 1;
			w32.Expand = false;
			w32.Fill = false;
			this.yvbox1.Add(this.yvbox3);
			global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.yvbox1[this.yvbox3]));
			w33.Position = 0;
			w33.Expand = false;
			w33.Fill = false;
			// Container child yvbox1.Gtk.Box+BoxChild
			this.yscrolledwindow = new global::Gtk.ScrolledWindow();
			this.yscrolledwindow.CanFocus = true;
			this.yscrolledwindow.Name = "yscrolledwindow";
			this.yscrolledwindow.ShadowType = ((global::Gtk.ShadowType)(1));
			this.yscrolledwindow.BorderWidth = ((uint)(3));
			// Container child yscrolledwindow.Gtk.Container+ContainerChild
			this.ytreeChangesets = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeChangesets.CanFocus = true;
			this.ytreeChangesets.Name = "ytreeChangesets";
			this.yscrolledwindow.Add(this.ytreeChangesets);
			this.yvbox1.Add(this.yscrolledwindow);
			global::Gtk.Box.BoxChild w35 = ((global::Gtk.Box.BoxChild)(this.yvbox1[this.yscrolledwindow]));
			w35.Position = 1;
			// Container child yvbox1.Gtk.Box+BoxChild
			this.yvbox2 = new global::Gamma.GtkWidgets.yVBox();
			this.yvbox2.WidthRequest = 0;
			this.yvbox2.HeightRequest = 0;
			this.yvbox2.Name = "yvbox2";
			this.yvbox2.Spacing = 6;
			// Container child yvbox2.Gtk.Box+BoxChild
			this.ylabel1 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel1.Name = "ylabel1";
			this.ylabel1.Xalign = 0F;
			this.ylabel1.LabelProp = global::Mono.Unix.Catalog.GetString("Детали изменений:");
			this.yvbox2.Add(this.ylabel1);
			global::Gtk.Box.BoxChild w36 = ((global::Gtk.Box.BoxChild)(this.yvbox2[this.ylabel1]));
			w36.Position = 0;
			w36.Expand = false;
			w36.Fill = false;
			// Container child yvbox2.Gtk.Box+BoxChild
			this.yPropertyvbox = new global::Gamma.GtkWidgets.yVBox();
			this.yPropertyvbox.Name = "yPropertyvbox";
			this.yPropertyvbox.Spacing = 6;
			// Container child yPropertyvbox.Gtk.Box+BoxChild
			this.scrolledwindow2 = new global::Gtk.ScrolledWindow();
			this.scrolledwindow2.CanFocus = true;
			this.scrolledwindow2.Name = "scrolledwindow2";
			this.scrolledwindow2.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child scrolledwindow2.Gtk.Container+ContainerChild
			this.ytreeFieldChange = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeFieldChange.CanFocus = true;
			this.ytreeFieldChange.Name = "ytreeFieldChange";
			this.scrolledwindow2.Add(this.ytreeFieldChange);
			this.yPropertyvbox.Add(this.scrolledwindow2);
			global::Gtk.Box.BoxChild w38 = ((global::Gtk.Box.BoxChild)(this.yPropertyvbox[this.scrolledwindow2]));
			w38.Position = 0;
			this.yvbox2.Add(this.yPropertyvbox);
			global::Gtk.Box.BoxChild w39 = ((global::Gtk.Box.BoxChild)(this.yvbox2[this.yPropertyvbox]));
			w39.Position = 1;
			this.yvbox1.Add(this.yvbox2);
			global::Gtk.Box.BoxChild w40 = ((global::Gtk.Box.BoxChild)(this.yvbox1[this.yvbox2]));
			w40.Position = 2;
			this.Add(this.yvbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.ycomboUsers.ItemSelected += new global::System.EventHandler<Gamma.Widgets.ItemSelectedEventArgs>(this.OnUpdateChangedEntities);
			this.ycomboFields.ItemSelected += new global::System.EventHandler<Gamma.Widgets.ItemSelectedEventArgs>(this.OnUpdateChangedEntities);
			this.ycomboEntities.ItemSelected += new global::System.EventHandler<Gamma.Widgets.ItemSelectedEventArgs>(this.OnUpdateChangedEntities);
			this.ycomboAction.EnumItemSelected += new global::System.EventHandler<Gamma.Widgets.ItemSelectedEventArgs>(this.OnUpdateChangedEntities);
			this.yPeriodWeek.Toggled += new global::System.EventHandler(this.OnPeriodWeek);
			this.yPeriodToday.Toggled += new global::System.EventHandler(this.OnPeriodToday);
			this.yPeriodThreeMonth.Toggled += new global::System.EventHandler(this.OnPeriodThreeMonth);
			this.yPeriodMonth.Toggled += new global::System.EventHandler(this.OnPeriodMonth);
			this.ydateStartperiodpicker.DateChanged += new global::System.EventHandler(this.OnUpdateChangedEntities);
			this.ydateEndperiodpicker.DateChanged += new global::System.EventHandler(this.OnUpdateChangedEntities);
			this.ybutton1.Clicked += new global::System.EventHandler(this.OnUpdateChangedEntities);
			this.yFilterbutton.Clicked += new global::System.EventHandler(this.OnBtnFilterClicked);
		}
	}
}
