using Nomnom.EasierCustomPreferences.Editor;
using UnityEditor;

[PreferencesName("Test")]
public static class TestPanel {
	[SettingsProvider]
	public static SettingsProvider CreateProvider() => CustomPreferences.GetProvider(typeof(TestPanel));

	public static Settings OnDeserialize() {
		return new Settings {
			Number = EditorPrefs.GetInt("MyInt", 0)
		};
	}

	public static void OnSerialize(Settings obj) {
		EditorPrefs.SetInt("MyInt", obj.Number);
	}

	public static void OnGUI(string searchContext, Settings obj) {
		obj.Number = EditorGUILayout.IntField("Number", obj.Number);
	}
}

public class Settings {
	public int Number;
}