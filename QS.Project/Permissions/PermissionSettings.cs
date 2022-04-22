﻿using System;
using System.Collections.Generic;
using System.Reflection;
using QS.DomainModel.Entity;
using QS.DomainModel.Entity.EntityPermissions;
using QS.Services;

namespace QS.Permissions
{
	public static class PermissionsSettings
	{
		public static IPermissionService PermissionService { get; set; }

		public static ICurrentPermissionService CurrentPermissionService { get; set; }

		static PermissionsSettings()
		{
			var defaultPermissionService = new DefaultAllowedPermissionService();
			PermissionService = defaultPermissionService;
			CurrentPermissionService = defaultPermissionService;
		}

		#region For EntityPermission

		public static string GetEntityReadValidateResult(Type entityType)
		{
			var aa = entityType.GetCustomAttribute<AppellativeAttribute>();
			string message;
			if(aa == null || String.IsNullOrWhiteSpace(aa.Nominative)) {
				message = $"У вас нет прав для просмотра документов типа: {entityType.Name}";
			} else {
				message = $"У Вас нет прав для просмотра следующих типов документов: {aa.Nominative}";
			}
			return message;
		}

		/// <summary>
		/// Однократное нахождение всех типов помеченных атрибутом <see cref="EntityPermissionAttribute"/>
		/// </summary>
		/// <param name="entitiesFinder">объект который ищет необходимые типы с настройками под конкретный проект</param>
		public static void ConfigureEntityPermissionFinder(IEntitiesWithPermissionFinder entitiesFinder)
		{
			permissionsEntityTypes = entitiesFinder.FindTypes();
		}

		private static IEnumerable<Type> permissionsEntityTypes;

		/// <summary>
		/// Список типов помеченных атрибутом <see cref="EntityPermissionAttribute"/>
		/// </summary>
		/// <value>The permissions entity types.</value>
		public static IEnumerable<Type> PermissionsEntityTypes {
			get {
				if(permissionsEntityTypes == null) {
					return new List<Type>();
				}
				return permissionsEntityTypes;
			}
		}
		#endregion

		#region For PresetPermission

		public static Dictionary<string, PresetUserPermissionSource> PresetPermissions = new Dictionary<string, PresetUserPermissionSource>();

		#endregion
	}

	public class PresetUserPermissionSource
	{
		public string Name { get; private set; }
		public string DisplayName { get; private set; }
		public string Description { get; private set; }

		public PresetUserPermissionSource(string name, string displayName, string description)
		{
			this.Name = name;
			this.DisplayName = displayName;
			this.Description = description;
		}
	}
}
