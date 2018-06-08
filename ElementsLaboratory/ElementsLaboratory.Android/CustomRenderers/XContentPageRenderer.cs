using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ElementsLaboratory.Controls.XContentPage), typeof(ElementsLaboratory.Droid.CustomRenderers.XContentPageRenderer))]
namespace ElementsLaboratory.Droid.CustomRenderers
{
    public class XContentPageRenderer : PageRenderer
    {
        public XContentPageRenderer(Context context) : base(context)
        { }
    }
}