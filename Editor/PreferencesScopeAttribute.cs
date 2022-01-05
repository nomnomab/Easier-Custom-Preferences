using System;
using UnityEditor;

namespace Nomnom.EasierCustomPreferences.Editor {
	[AttributeUsage(AttributeTargets.Class)]
	public class PreferencesScopeAttribute: Attribute {
		public readonly SettingsScope Scope;

		public PreferencesScopeAttribute(SettingsScope scope) {
			Scope = scope;
		}
	}
}