using System;

namespace Nomnom.EasierCustomPreferences.Editor {
	[AttributeUsage(AttributeTargets.Class)]
	public class PreferencesNameAttribute: Attribute {
		public readonly string Name;

		public PreferencesNameAttribute(string name) {
			Name = name;
		}
	}
}