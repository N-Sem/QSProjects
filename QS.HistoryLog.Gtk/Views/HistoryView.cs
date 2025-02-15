﻿using System;
using Gamma.GtkWidgets;
using Gtk;
using QS.HistoryLog.Domain;
using QS.HistoryLog.ViewModels;
using QS.Project.Domain;
using QS.Views.Dialog;

namespace QS.HistoryLog.Views
{
	public partial class HistoryView : DialogViewBase<HistoryViewModel>
	{
		HistoryViewModel viewModel;
		private IDiffFormatter diffFormatter = new PangoDiffFormater();

		public HistoryView(HistoryViewModel viewModel): base(viewModel)
		{
			this.Build();
			this.viewModel = viewModel;
			viewModel.DontRefresh = true;
			yPeriodToday.Active = true;

			ycomboUsers.SetRenderTextFunc<UserBase>(x => x.Name);
			ycomboUsers.Binding.AddSource(viewModel)
				.AddBinding(v => v.Users, w => w.ItemsList)
				.AddBinding(v => v.SelectedUser, w => w.SelectedItem)
				.InitializeFromSource();

			ycomboEntities.SetRenderTextFunc<HistoryObjectDesc>(x => x.DisplayName);
			ycomboEntities.Binding.AddSource(viewModel)
				.AddBinding(v => v.TraceClasses, w => w.ItemsList)
				.AddBinding(v => v.SelectedTraceClass, w => w.SelectedItem)
				.InitializeFromSource();

			ycomboAction.ItemsEnum = typeof(EntityChangeOperation);
			ycomboAction.Binding.AddSource(viewModel)
				.AddBinding(v => v.Operation, w => w.SelectedItemOrNull)
				.InitializeFromSource();

			ycomboFields.SetRenderTextFunc<HistoryFieldDesc>(x => x.DisplayName);
			ycomboFields.Binding.AddSource(viewModel)
				.AddBinding(v => v.TracedProperties, w => w.ItemsList)
				.AddBinding(v => v.SelectedTracedProperties, w => w.SelectedItem)
				.InitializeFromSource();

			ydateStartperiodpicker.Binding.AddSource(viewModel)
				.AddBinding(v => v.PeriodStartDate, w => w.Date)
				.InitializeFromSource();

			ydateEndperiodpicker.Binding.AddSource(viewModel)
				.AddBinding(v => v.PeriodEndDate, w => w.Date)
				.InitializeFromSource();

			yentryName.Binding.AddSource(viewModel)
				.AddBinding(v => v.SearchByName, w => w.Text)
				.InitializeFromSource();

			yentryId.Binding.AddSource(viewModel)
				.AddBinding(v => v.SearchById, w => w.Text)
				.InitializeFromSource();

			yentryChanged.Binding.AddSource(viewModel)
				.AddBinding(v => v.SearchByChanged, w => w.Text)
				.InitializeFromSource();

			ytreeChangesets.ColumnsConfig = ColumnsConfigFactory.Create<ChangedEntity>()
				.AddColumn("Время").AddTextRenderer(x => x.ChangeTimeText)
				.AddColumn("Пользователь").AddTextRenderer(x => x.ChangeSet.UserName)
				.AddColumn("Действие").AddTextRenderer(x => x.OperationText)
				.AddColumn("Тип объекта").AddTextRenderer(x => x.ObjectTitle)
				.AddColumn("Код объекта").AddTextRenderer(x => x.EntityId.ToString())
				.AddColumn("Имя объекта").AddTextRenderer(x => x.EntityTitle)
				.AddColumn("Откуда изменялось").AddTextRenderer(x => x.ChangeSet.ActionName)
				.Finish(); 
			 ytreeChangesets.Binding.AddSource(viewModel)
			  	 .AddFuncBinding(v => v.ChangedEntities, w => w.ItemsDataSource)
			  	 .InitializeFromSource();

			ytreeChangesets.Selection.Changed += OnChangeSetSelectionChanged;
			yscrolledwindow.Vadjustment.ValueChanged += OnScroll;

			viewModel.DontRefresh = false;
			viewModel.UpdateChangedEntities();
			ytreeFieldChange.Binding.AddSource(viewModel)
				.AddBinding(v => v.ChangesSelectedEntity, w => w.ItemsDataSource)
				.InitializeFromSource();

			ytreeFieldChange.ColumnsConfig = ColumnsConfigFactory.Create<FieldChange>()
				.AddColumn("Поле").AddTextRenderer(x => x.FieldTitle)
				.AddColumn("Операция").AddTextRenderer(x => x.TypeText)
				.AddColumn("Новое значение").AddTextRenderer(x => x.NewFormatedDiffText, useMarkup: true)
				.AddColumn("Старое значение").AddTextRenderer(x => x.OldFormatedDiffText, useMarkup: true)
				.Finish();
		}
	
		protected void OnPeriodToday(object o, EventArgs args)
		{
			if(yPeriodToday.Active) {
				ydateStartperiodpicker.Date = DateTime.Today;
				ydateEndperiodpicker.Date = ydateStartperiodpicker.Date.AddDays(1).AddTicks(-1);
			}
		}
		protected void OnPeriodWeek(object o, EventArgs args)
		{
			if(yPeriodWeek.Active) {
				ydateEndperiodpicker.Date = DateTime.Today.AddDays(1).AddTicks(-1);
				ydateStartperiodpicker.Date = ydateEndperiodpicker.Date.AddDays(-8).AddTicks(1);
			}
		}
		protected void OnPeriodMonth(object o, EventArgs args)
		{
			if(yPeriodMonth.Active) {
				ydateEndperiodpicker.Date = DateTime.Today.AddDays(1).AddTicks(-1);
				ydateStartperiodpicker.Date = ydateEndperiodpicker.Date.AddMonths(-1).AddDays(-1).AddTicks(1);
			}
		}
		protected void OnPeriodThreeMonth(object o, EventArgs args)
		{
			if(yPeriodThreeMonth.Active) {
				ydateEndperiodpicker.Date = DateTime.Today.AddDays(1).AddTicks(-1);
				ydateStartperiodpicker.Date = ydateEndperiodpicker.Date.AddMonths(-3).AddDays(-1).AddTicks(1);
			}
		}
		protected void OnBtnFilterClicked(object sender, EventArgs e)
		{
			yFilterbox.Visible = !yFilterbox.Visible;
			yFilterbutton.Label = yFilterbox.Visible ? "Скрыть фильтр" : "Показать фильтр";
			ytreeChangesets.YTreeModel.EmitModelChanged();
		}
		void OnChangeSetSelectionChanged(object sender, EventArgs e)
		{
			ViewModel.SelectedEntity = (ChangedEntity)ytreeChangesets.GetSelectedObject();
			if(ViewModel.SelectedEntity != null)
				foreach (var fieldChange in ViewModel.SelectedEntity.Changes)
				{
					fieldChange.DiffFormatter = diffFormatter;
				}
			ytreeFieldChange.ItemsDataSource =viewModel.ChangesSelectedEntity;
		}
		protected void OnUpdateChangedEntities(object sender, EventArgs e)
		{
			viewModel.UpdateChangedEntities();
			ytreeChangesets.ItemsDataSource = viewModel.ChangedEntities;
			ytreeChangesets.YTreeModel.EmitModelChanged();
		}
		protected void OnScroll(object sender, EventArgs e)
		{
			if(ytreeChangesets.Vadjustment.Value + ytreeChangesets.Vadjustment.PageSize < ytreeChangesets.Vadjustment.Upper)
				return;

			if(!viewModel.HasUnloaded)
				return;
			
			var lastPos = ytreeChangesets.Vadjustment.Value;
			viewModel.UpdateChangedEntities(true);
			Application.Invoke(delegate(object o, EventArgs args) {
				ytreeChangesets.ItemsDataSource = viewModel.ChangedEntities;
				ytreeChangesets.Vadjustment.Value = lastPos;
			} );
		}
	}
}
