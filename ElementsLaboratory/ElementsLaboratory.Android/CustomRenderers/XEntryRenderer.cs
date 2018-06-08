using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Util;
using ElementsLaboratory.Controls;
using PersonalizingViews.Droid.CustomRenderers;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(XEntry), typeof(XEntryRenderer))]
namespace PersonalizingViews.Droid.CustomRenderers
{
    public class XEntryRenderer : EntryRenderer
    {
        public XEntryRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null)
                return;

            XEntry element = (XEntry)e.NewElement;

            ApplySharedStyles(element);

            if (!element.BoxStyleEnabled && Control != null)
                ApplyStylesAndBehaviorsFromStandardMode(element);
            else if (element.BoxStyleEnabled && Control != null)
                ApplyStylesAndBehaviorsFromBoxStyle(element);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }

        private void ApplySharedStyles(XEntry element)
        {
            this.Control.Hint = element.Placeholder;

            //// Cursor Color (this is not bindable property. Is only internally changed). 
            //IntPtr IntPtrtextViewClass = JNIEnv.FindClass(typeof(TextView));
            //IntPtr mCursorDrawableResProperty =
            //       JNIEnv.GetFieldID(IntPtrtextViewClass, "mCursorDrawableRes", "I");

            //// replace 0 with a Resource.Drawable.my_cursor 
            //JNIEnv.SetField(Control.Handle, mCursorDrawableResProperty, 0);

            // Text alignment.
            if (element.HorizontalTextAlignment == Xamarin.Forms.TextAlignment.Center)
                Control.Gravity = Android.Views.GravityFlags.CenterHorizontal;
            else if (element.HorizontalTextAlignment == Xamarin.Forms.TextAlignment.Start)
                Control.Gravity = Android.Views.GravityFlags.Start;
            else if (element.HorizontalTextAlignment == Xamarin.Forms.TextAlignment.End)
                Control.Gravity = Android.Views.GravityFlags.End;
        }

        private void ApplyStylesAndBehaviorsFromBoxStyle(XEntry element)
        {
            // Internal Padding
            Control.SetPadding(element.InternalPadding, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);

            // Applying initial styles.
            SetUnfocusedBoxStyles(element);

            element.Unfocused += (sender, evt) => { SetUnfocusedBoxStyles(element); };
            element.Focused += (sender, evt) => { SetFocusedBoxStyles(element); };
        }

        private void ApplyStylesAndBehaviorsFromStandardMode(XEntry element)
        {
            // Internal Padding.
            if (element.InternalPadding != default(int))
            {
                var internalPaddingInPx = ConvertToPx(element.InternalPadding);
                Control.SetPadding(internalPaddingInPx, internalPaddingInPx, internalPaddingInPx, internalPaddingInPx);
            }

            // Border color.
            ChangeColor(element.BorderColor.ToAndroid());

            // Border color focused and unfocused.
            element.Unfocused += (sender, evt) => { ChangeColor(element.BorderColor.ToAndroid()); };
            element.Focused += (sender, evt) => { ChangeColor(element.BorderColorFocused.ToAndroid()); };
        }

        private void SetUnfocusedBoxStyles(XEntry element)
        {
            if (Control != null)
            {
                var gradientDrawable = new GradientDrawable();

                // Border Radius.
                var borderRadiusPx = ConvertToPx(Convert.ToInt32(element.BoxBorderRadius));
                gradientDrawable.SetCornerRadius(borderRadiusPx);

                // Border Color.
                var edgeSizePx = ConvertToPx(element.BoxEdgeSize);
                gradientDrawable.SetStroke(edgeSizePx, element.BorderColor.ToAndroid());

                Control.SetBackground(gradientDrawable);
            }
        }

        private void SetFocusedBoxStyles(XEntry element)
        {
            if (Control != null)
            {
                var gd = new GradientDrawable();

                // Border Radius.
                var borderRadiusPx = ConvertToPx(Convert.ToInt32(element.BoxBorderRadius));
                gd.SetCornerRadius(borderRadiusPx);

                // Border Color.
                var edgeSizePx = ConvertToPx(element.BoxEdgeSize);
                gd.SetStroke(edgeSizePx, element.BorderColorFocused.ToAndroid());

                // Appliying styles.
                Control.SetBackground(gd);
            }
        }

        private void ChangeColor(Android.Graphics.Color color)
        {
            if (Control != null)
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop && color != (default(Xamarin.Forms.Color)).ToAndroid())
                    Control.BackgroundTintList = ColorStateList.ValueOf(color);
                if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop && color != (default(Xamarin.Forms.Color)).ToAndroid())
                    Control.Background.SetColorFilter(color, PorterDuff.Mode.SrcAtop);
            }
        }

        private int ConvertToPx(int dp)
        {
            var px = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, dp, Context.Resources.DisplayMetrics);
            return px;
        }
    }
}