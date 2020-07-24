﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace QS.Project.VersionControl
{
	public class ApplicationVersionInfo : IApplicationInfo
	{
		public string ProductName => Assembly.GetName().Name;
		public string ProductTitle => Assembly.GetCustomAttribute<AssemblyTitleAttribute>()?.Title;

		public string Modification => Assembly.GetCustomAttribute<AssemblyModificationAttribute>()?.Name;
		public string ModificationTitle => Assembly.GetCustomAttribute<AssemblyModificationAttribute>()?.Title;
		public string[] СompatibleModifications {
			get {
				var modificationAttributes = Assembly.GetCustomAttributes<AssemblyСompatibleModificationAttribute>();
				var list = modificationAttributes.Select(x => x.Name).ToList();
				if (!String.IsNullOrWhiteSpace(Modification) && !list.Contains(Modification))
					list.Add(Modification);
				return list.ToArray();
				}
			}

		public Version Version => Assembly.GetName().Version;

		public string SerialNumber => throw new NotImplementedException();

		public bool IsBeta => Assembly.GetCustomAttribute<AssemblyBetaBuildAttribute>() != null;

		public DateTime BuildDate => System.IO.File.GetLastWriteTime(Assembly.Location);

		#region Внутрение
		private Assembly Assembly => Assembly.GetEntryAssembly();
		#endregion
	}
}
