using System;

namespace Nomnom.EasierCustomPreferences.Editor {
	[AttributeUsage(AttributeTargets.Class)]
	public class PreferencesNameAttribute: Attribute {
		public readonly string Name;
		public readonly string Path;

		public PreferencesNameAttribute(string name) {
			Name = name;
			Path = string.Empty;
		}

		public PreferencesNameAttribute(string name, string path) {
			Name = name;
			Path = path;
		}
	}
}