using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;

namespace XamApp.Localization
{
    // You exclude the 'Extension' suffix when using in XAML
    public static class TranslateExtension
    {
        private const string ResourceId = "XamApp.Localization.Resources.AppResource";

        private static readonly Lazy<ResourceManager> ResMgr = new Lazy<ResourceManager>(
            () => new ResourceManager(ResourceId, IntrospectionExtensions.GetTypeInfo(typeof(TranslateExtension)).Assembly));

        public static string Translate(this string text)
        {
            CultureInfo ci = null;

            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {
                ci = DependencyService.Get<ILocale>().GetCurrentCultureInfo();
            }
            else
            {
                ci = CultureInfo.CurrentUICulture;
            }

            if (text == null)
                return string.Empty;

            var translation = ResMgr.Value.GetString(text, ci);
            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException(string.Format(
                    "Key '{0}' was not found in resources '{1}' for culture '{2}'.",
                    text, ResourceId, ci.Name), "Text");
#else
				translation = text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
            }

            return translation;
        }
    }
}
