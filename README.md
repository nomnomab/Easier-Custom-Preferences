# Easier Custom Preferences
Makes adding a custom preferences panel easier.

## Installation
- OpenUPM
	- `openupm add com.nomnom.easier-custom-preferences`
- Package Manager
	- Add through git url `https://github.com/nomnomab/Easier-Custom-Preferences.git`

## Usage
Here is a barebones example of the new usage for a preferences window:
```c#
using Nomnom.EasierCustomPreferences.Editor;
using UnityEditor;

// defines the name of the window, and is used for visual purposes
[PreferencesName("Test")]
public static class TestPanel {
	// creates the provider for Unity to inject a window from
	[SettingsProvider]
	public static SettingsProvider CreateProvider() => CustomPreferences.GetProvider(typeof(TestPanel));

	// gives the panel an object to modify
	public static Settings OnDeserialize() {
		return new Settings {
			Number = EditorPrefs.GetInt("MyInt", 0)
		};
	}

	// applies the new changes to disk
	public static void OnSerialize(Settings obj) {
		EditorPrefs.SetInt("MyInt", obj.Number);
	}

	// draws whatever inside of the preferences window
	public static void OnGUI(string searchContext, Settings obj) {
		obj.Number = EditorGUILayout.IntField("Number", obj.Number);
	}
}

// the storage object used in the window
public class Settings {
	public int Number;
}
```

#### Attributes
- `PreferencesName` - The name and path of the window
- `PreferencesScope` - Determines if the window is shown through the user scope or project scope
- `PreferencesKeywords` - The keywords that will be used for searching