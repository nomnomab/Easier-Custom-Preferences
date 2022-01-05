using UnityEditor;

namespace Nomnom.EasierCustomPreferences.Editor {
	[PreferencesName("Test")]
	public static class TestPanel {
		[SettingsProvider]
		public static SettingsProvider CreateProvider() => CustomPreferences.GetProvider(typeof(TestPanel));

		public static Settings OnDeserialize() => new Settings();

		public static void OnSerialize(Settings obj) {
			// set editor prefs
		}

		public static void OnGUI(string searchContext, Settings obj) {
 			EditorGUILayout.LabelField(obj.Number.ToString());
		}
	}

	public class Settings {
		public int Number;
	}
}