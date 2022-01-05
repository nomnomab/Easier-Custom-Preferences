using System;

namespace Nomnom.EasierCustomPreferences.Editor {
	[AttributeUsage(AttributeTargets.Class)]
	public class PreferencesKeywordAttribute: Attribute {
		public readonly string[] Keywords;

		public PreferencesKeywordAttribute(params string[] keywords) {
			Keywords = keywords;
		}
	}
}