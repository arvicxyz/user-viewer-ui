using System;
using System.Globalization;
using System.Threading;
using Foundation;
using XamApp.iOS.Localization;
using XamApp.Localization;
using Xamarin.Forms;

[assembly: Dependency(typeof(Locale))]
namespace XamApp.iOS.Localization
{
    public class Locale : ILocale
    {
        public void SetLocale(CultureInfo ci)
        {
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        public CultureInfo GetCurrentCultureInfo()
        {
            var netLanguage = "en";
            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                netLanguage = IosToDotnetLanguage(pref);
            }

            // TODO: This gets called a lot - try/catch can be expensive so consider caching or something
            CultureInfo ci = null;

            try
            {
                ci = new CultureInfo(netLanguage);
            }
            catch (CultureNotFoundException e1)
            {
                // iOS locale not valid .NET culture (eg. "en-ES" : English in Spain)
                // Fallback to first characters, in this case "en"
                try
                {
                    var fallback = ToDotnetFallbackLanguage(new PlatformCulture(netLanguage));
                    Console.WriteLine(netLanguage + " failed, trying " + fallback + " (" + e1.Message + ")");
                    ci = new CultureInfo(fallback);
                }
                catch (CultureNotFoundException e2)
                {
                    // iOS language not valid .NET culture, falling back to English
                    Console.WriteLine(netLanguage + " couldn't be set, using 'en' (" + e2.Message + ")");
                    ci = new CultureInfo("en");
                }
            }

            return ci;
        }

        private string IosToDotnetLanguage(string iosLanguage)
        {
            Console.WriteLine("iOS Language: " + iosLanguage);
            var netLanguage = iosLanguage;

            // Certain languages need to be converted to CultureInfo equivalent
            switch (iosLanguage)
            {
                case "ms-MY":   // "Malaysian (Malaysia)" not supported .NET culture
                case "ms-SG":   // "Malaysian (Singapore)" not supported .NET culture
                    netLanguage = "ms"; // Closest supported
                    break;
                case "gsw-CH":  // "Schwiizertüütsch (Swiss German)" not supported .NET culture
                    netLanguage = "de-CH"; // Closest supported
                    break;
                    // Add more application-specific cases here (if required)
                    // ONLY use cultures that have been tested and known to work
            }

            Console.WriteLine(".NET Language/Locale: " + netLanguage);
            return netLanguage;
        }

        private string ToDotnetFallbackLanguage(PlatformCulture platCulture)
        {
            Console.WriteLine(".NET Fallback Language: " + platCulture.LanguageCode);
            var netLanguage = platCulture.LanguageCode; // Use the first part of the identifier (two chars, usually)

            switch (platCulture.LanguageCode)
            {
                case "pt":
                    netLanguage = "pt-PT"; // Fallback to Portuguese (Portugal)
                    break;
                case "gsw":
                    netLanguage = "de-CH"; // Equivalent to German (Switzerland) for this app
                    break;
                    // Add more application-specific cases here (if required)
                    // ONLY use cultures that have been tested and known to work
            }

            Console.WriteLine(".NET Fallback Language/Locale: " + netLanguage + " (application-specific)");
            return netLanguage;
        }
    }
}
