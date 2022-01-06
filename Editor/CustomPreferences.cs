using System;
using System.Reflection;
using UnityEditor;

namespace Nomnom.EasierCustomPreferences.Editor {
	public static class CustomPreferences {
		public static SettingsProvider GetProvider(Type type, bool autoSerialize = true) {
			PreferencesNameAttribute nameAttribute =
				(PreferencesNameAttribute) type.GetCustomAttribute(typeof(PreferencesNameAttribute));
			PreferencesScopeAttribute scopeAttribute =
				(PreferencesScopeAttribute) type.GetCustomAttribute(typeof(PreferencesScopeAttribute));
			PreferencesKeywordsAttribute keywordsAttribute =
				(PreferencesKeywordsAttribute) type.GetCustomAttribute(typeof(PreferencesKeywordsAttribute));

			if (nameAttribute == null) {
				throw new Exception("A preference window is missing a PreferencesNameAttribute");
			}

			MethodInfo onGUIFunc = type.GetMethod("OnGUI");
			MethodInfo onDeserializeFunc = type.GetMethod("OnDeserialize");
			MethodInfo onSerializeFunc = type.GetMethod("OnSerialize");

			if (onDeserializeFunc == null) {
				throw new Exception("A preference window is missing an OnDeserialize method");
			}

			if (onSerializeFunc == null) {
				throw new Exception("A preference window is missing an OnSerialize method");
			}
			
			if (onGUIFunc == null) {
				throw new Exception("A preference window is missing an OnGUI method");
			}
			
			object obj = onDeserializeFunc.Invoke(null, null);

			ParameterInfo[] parameters = onGUIFunc.GetParameters();
			if (parameters.Length != 2 || parameters[0].ParameterType != typeof(string) || parameters[1].ParameterType != obj.GetType()) {
				throw new Exception("A preference window is missing a valid OnGUI method");
			}

			string path = string.IsNullOrEmpty(nameAttribute.Path)
				? nameAttribute.Name
				: $"{nameAttribute.Path}/{nameAttribute.Name}";
			SettingsProvider settingsProvider = new SettingsProvider(
				$"Preferences/{path}",
				scopeAttribute?.Scope ?? SettingsScope.User
			) {
				label = nameAttribute.Name,
				guiHandler = ctx => {
					if (autoSerialize) {
						EditorGUI.BeginChangeCheck();
					}

					onGUIFunc.Invoke(null, new[] {ctx, obj});

					if (autoSerialize) {
						if (EditorGUI.EndChangeCheck()) {
							onSerializeFunc.Invoke(null, new[] {obj});
						}
					}
				},
				keywords = keywordsAttribute?.Keywords ?? Array.Empty<string>()
			};

			return settingsProvider;
		}
	}
}