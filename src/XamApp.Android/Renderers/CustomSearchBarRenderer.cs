using Android.Content;
using Android.Widget;
using AndroidX.Core.Content;
using XamApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SearchBar), typeof(CustomSearchBarRenderer))]
namespace XamApp.Droid.Renderers
{
    public class CustomSearchBarRenderer : SearchBarRenderer
    {
        private Context _context;

        public CustomSearchBarRenderer(Context context) : base(context)
        {
            _context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var linearLayout = (LinearLayout)Control.GetChildAt(0);
                var searchLayout = (LinearLayout)linearLayout.GetChildAt(2);
                searchLayout.Background = ContextCompat.GetDrawable(_context, Resource.Drawable.edittext_rounded_border);
                var searchPlate = (LinearLayout)searchLayout.GetChildAt(1);
                searchPlate.Background = ContextCompat.GetDrawable(_context, Resource.Drawable.edittext_rounded_border);
            }
        }
    }
}
