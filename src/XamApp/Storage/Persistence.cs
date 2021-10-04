using Xamarin.Essentials;

namespace XamApp.Storage
{
    public static class Persistence
    {
        #region Persistence Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        #endregion

        public static string GeneralSettings
        {
            get { return Preferences.Get(SettingsKey, SettingsDefault); }
            set { Preferences.Set(SettingsKey, value); }
        }
    }
}
