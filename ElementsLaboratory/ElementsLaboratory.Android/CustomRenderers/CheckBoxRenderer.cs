using Android.Content;
using Android.OS;
using ElementsLaboratory.Droid.CustomRenderers;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ElementsLaboratory.Controls.CheckBox), typeof(CheckBoxRenderer))]

namespace ElementsLaboratory.Droid.CustomRenderers
{
    /// <summary>
    /// Class CheckBoxRenderer.
    /// </summary>
    public class CheckBoxRenderer : ViewRenderer<ElementsLaboratory.Controls.CheckBox, Android.Widget.CheckBox>
    {
        private Android.Widget.CheckBox checkBox;

        public CheckBoxRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<ElementsLaboratory.Controls.CheckBox> e)
        {
            base.OnElementChanged(e);
            var model = e.NewElement;
            checkBox = new Android.Widget.CheckBox(Context);
            checkBox.Tag = this;
            CheckboxPropertyChanged(model, null);
            checkBox.SetOnClickListener(new ClickListener(model));
            SetNativeControl(checkBox);
        }
        private void CheckboxPropertyChanged(ElementsLaboratory.Controls.CheckBox model, String propertyName)
        {
            if (propertyName == null || ElementsLaboratory.Controls.CheckBox.IsCheckedProperty.PropertyName == propertyName)
            {
                checkBox.Checked = model.IsChecked;
            }

            if (propertyName == null || ElementsLaboratory.Controls.CheckBox.ColorProperty.PropertyName == propertyName)
            {
                int[][] states = {
                    new int[] { Android.Resource.Attribute.StateEnabled}, // enabled
                    new int[] {Android.Resource.Attribute.StateEnabled}, // disabled
                    new int[] {Android.Resource.Attribute.StateChecked}, // unchecked
                    new int[] { Android.Resource.Attribute.StatePressed}  // pressed
                };
                var checkBoxColor = (int)model.Color.ToAndroid();
                int[] colors = {
                    checkBoxColor,
                    checkBoxColor,
                    checkBoxColor,
                    checkBoxColor
                };
                var myList = new Android.Content.Res.ColorStateList(states, colors);

                // Border color of default XEntry.
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                    checkBox.ButtonTintList = myList;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (checkBox != null)
            {
                base.OnElementPropertyChanged(sender, e);

                CheckboxPropertyChanged((ElementsLaboratory.Controls.CheckBox)sender, e.PropertyName);
            }
        }

        public class ClickListener : Java.Lang.Object, IOnClickListener
        {
            private ElementsLaboratory.Controls.CheckBox _myCheckbox;
            public ClickListener(ElementsLaboratory.Controls.CheckBox myCheckbox)
            {
                this._myCheckbox = myCheckbox;
            }
            public void OnClick(global::Android.Views.View v)
            {
                _myCheckbox.IsChecked = !_myCheckbox.IsChecked;
            }
        }
    }
}