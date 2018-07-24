using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace SettingsRecipe
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get => CrossSettings.Current;
        }

        #region Setting Constants
        private static readonly bool BoolDefault = true;
        private static readonly int NumberDefault = 42;
        private static readonly string TextDefault = string.Empty;
        #endregion

        public static bool Bool
        {
            get => AppSettings.GetValueOrDefault(nameof(Bool), BoolDefault);
            set => AppSettings.AddOrUpdateValue(nameof(Bool), value);
        }
        public static int Number
        {
            get => AppSettings.GetValueOrDefault(nameof(Number), NumberDefault);
            set => AppSettings.AddOrUpdateValue(nameof(Number), value);
        }
        public static string Text
        {
            get => AppSettings.GetValueOrDefault(nameof(Text), TextDefault);
            set => AppSettings.AddOrUpdateValue(nameof(Text), value);
        }
    }
}
