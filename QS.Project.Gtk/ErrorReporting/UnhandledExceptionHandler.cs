﻿using System;
using System.Collections.Generic;
using System.Threading;
using Gtk;
using QS.Dialog;
using QS.Project.Domain;
using QS.Project.Versioning;

namespace QS.ErrorReporting
{
	/// <summary>
	/// Делегат для перехвата и отдельной обработки некоторых ошибок.
	/// Метод должен возвращать true, если ошибку он обработал сам 
	/// и ее больше не надо передавать вниз по списку зарегистрированных обработчиков,
	/// вплоть до стандартного диалога отправки отчета об ошибке.
	/// </summary>
	public delegate bool CustomErrorHandler(Exception exception, IApplicationInfo application, UserBase user, IInteractiveMessage interactiveMessage);

	/// <summary>
	/// Класс помогает сформировать отправку отчета о падении программы.
	/// Для работы необходимо предварительно сконфигурировать модуль
	/// GtkGuiDispatcher.GuiThread - указать поток Gui, нужно для корректной обработки эксепшенов в других потоках.
	/// ApplicationInfo - Передать класс возвращающий информация о программе
	/// InteractiveMessage - Класс позволяющий обработчикам выдать сообщение пользователю.
	/// Опционально:
	/// User - Текущий пользователь
	/// RequestEmail = true - требовать ввод E-mail
	/// RequestDescription = true - требовать ввода описания
	/// </summary>
	public static class UnhandledExceptionHandler
	{
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

		#region Внешние настройки модуля

		public static IApplicationInfo ApplicationInfo;
		public static IDataBaseInfo DataBaseInfo;
		public static IInteractiveMessage InteractiveMessage;
		public static UserBase User;
		public static IErrorReportingSettings ErrorReportingSettings;

		/// <summary>
		/// В список можно добавить собственные обработчики ошибкок. Внимание! Порядок добавления обрабочиков важен,
		/// так как если ошибку обработает первый обработчик ко второму она уже не попадет.
		/// </summary>
		public static readonly List<CustomErrorHandler> CustomErrorHandlers = new List<CustomErrorHandler>();

		#endregion

		private static ErrorMsgDlg currentCrashDlg;

		public static void SubscribeToUnhadledExceptions(IErrorReportingSettings errorReportingSettings)
		{
			ErrorReportingSettings = errorReportingSettings ?? throw new ArgumentNullException(nameof(errorReportingSettings));

			AppDomain.CurrentDomain.UnhandledException += delegate (object sender, UnhandledExceptionEventArgs e) {
				logger.Fatal((Exception)e.ExceptionObject, "Поймано необработаное исключение в Application Domain.");
				ErrorMessage((Exception)e.ExceptionObject);
			};
			GLib.ExceptionManager.UnhandledException += delegate (GLib.UnhandledExceptionArgs a) {
				logger.Fatal((Exception)a.ExceptionObject, "Поймано необработаное исключение в GTK.");
				ErrorMessage((Exception)a.ExceptionObject);
			};
		}

		public static void ErrorMessage(Exception ex)
		{
			if(GtkGuiDispatcher.GuiThread == Thread.CurrentThread) {
				RealErrorMessage(ex);
			}
			else {
				logger.Debug("From Another Thread");
				Application.Invoke(delegate {
					RealErrorMessage(ex);
				});
			}
		}

		private static void RealErrorMessage(Exception exception)
		{
			foreach(var handler in CustomErrorHandlers) {
				try {
					if(handler(exception, ApplicationInfo, User, InteractiveMessage)) {
						return;
					}
				}
				catch(Exception ex) {
					logger.Error(ex, "Ошибка в CustomErrorHandler");
				}
			}

			if(currentCrashDlg != null) {
				logger.Debug("Добавляем исключение в уже созданное окно.");
				currentCrashDlg.AddAnotherException(exception);
			}
			else {
				logger.Debug("Создание окна отправки отчета о падении.");
				currentCrashDlg = new ErrorMsgDlg(exception, ApplicationInfo, User, ErrorReportingSettings, DataBaseInfo);
				currentCrashDlg.Run();
				currentCrashDlg.Destroy();
				currentCrashDlg = null;
				logger.Debug("Окно отправки отчета, уничтожено.");
			}
		}
	}
}
