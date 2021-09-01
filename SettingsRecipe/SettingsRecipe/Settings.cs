using System;
using Xamarin.Essentials;

namespace SettingsRecipe
{
    public static class Settings
    {
        private static readonly string TextSettingDefault = "Lorem ipsum";

        public static string TextSetting
        {
            get => Preferences.Get(nameof(TextSetting), TextSettingDefault);
            set
            {
                Preferences.Set(nameof(TextSetting), value);                
            }
        }
    }
}
