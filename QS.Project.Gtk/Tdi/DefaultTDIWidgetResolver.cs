﻿using Gtk;
using QS.Project.Journal;

namespace QS.Tdi
{
	public class DefaultTDIWidgetResolver : ITDIWidgetResolver
	{
		public virtual Widget Resolve(ITdiTab tab)
		{
			if(tab is Widget) {
				return (Widget)tab;
			}

			if(JournalViewFactory.TryCreateView(out Widget widget, tab)) {
				return widget;
			}

			return null;
		}
	}
}
