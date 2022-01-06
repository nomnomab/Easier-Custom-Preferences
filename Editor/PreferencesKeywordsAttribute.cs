using System;

namespace Nomnom.EasierCustomPreferences.Editor {
	[AttributeUsage(AttributeTargets.Class)]
	public class PreferencesKeywordsAttribute: Attribute {
		public readonly string[] Keywords;

		public PreferencesKeywordsAttribute(params string[] keywords) {
			Keywords = keywords;
		}
	}
}