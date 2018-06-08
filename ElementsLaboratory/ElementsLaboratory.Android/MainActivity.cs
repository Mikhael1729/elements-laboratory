using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;

namespace ElementsLaboratory.Droid
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static Android.Support.V7.Widget.Toolbar Toolbar { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            //Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            //if (toolbar != null)
            //    SetSupportActionBar(toolbar);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            //LoadApplication(UXDivers.Gorilla.Droid.Player.CreateApplication(
            //    this,
            //    new UXDivers.Gorilla.Config("Good Gorilla")
            //      // Register Grial Shared assembly
            //      .RegisterAssemblyFromType<ElementsLaboratory.Controls.BottomBarPage>()
            //      .RegisterAssemblyFromType<ElementsLaboratory.Controls.CheckBox>()
            //      .RegisterAssemblyFromType<ElementsLaboratory.Controls.XButton>()
            //      .RegisterAssemblyFromType<ElementsLaboratory.Controls.XContentPage>()
            //      .RegisterAssemblyFromType<ElementsLaboratory.Controls.XEditor>()
            //      .RegisterAssemblyFromType<ElementsLaboratory.Controls.XEntry>()
            //      .RegisterAssemblyFromType<ElementsLaboratory.Controls.XTableView>()
            //      .RegisterAssemblyFromType<Refractored.FabControl.FloatingActionButtonView>()
            //      .RegisterAssemblyFromType<Views.MainPage>()
            //      .RegisterAssemblyFromType<Views.ExperimentsPage>()
            //      .RegisterAssemblyFromType<Xfx.XfxEntry>()
            //));

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                Window.SetStatusBarColor((Xamarin.Forms.Color.FromHex("#363636")).ToAndroid());
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            Toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            return base.OnCreateOptionsMenu(menu);
        }
    }
}

