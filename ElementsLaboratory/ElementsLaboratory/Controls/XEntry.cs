using Xamarin.Forms;

namespace ElementsLaboratory.Controls
{
    /// <summary>
    /// Contains properties that the entry class lacks. The operation and behavior of the properties 
    /// depend on whether the CustomModeEnabled property is active or not.
    /// </summary>
    /// <remarks>
    /// - Shared properties of the different states of CustomModeEnabled property:
    ///     - BorderColor.
    ///     - InternalPadding.
    ///     - BorderColorFocused.
    ///     
    /// - Specific properties of CustomModelEnabled == true:
    ///     - BoxEdgeSize.
    ///     - BoxBorderRadius.
    /// 
    /// - Specific properties of CustomModelEnabled != true:
    ///     - BorderColor.
    ///     - InternalPadding.
    ///     - BorderColorFocused.
    /// </remarks>
    public class XEntry : Entry
    {
        #region Bindable properties
        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create("BorderColor", typeof(Color), typeof(XEntry), default(Color));

        public static readonly BindableProperty BoxEdgeSizeProperty =
            BindableProperty.Create("BoxEdgeSize", typeof(int), typeof(XEntry), 1);

        public static readonly BindableProperty BorderRadiusProperty =
            BindableProperty.Create("BoxBorderRadius", typeof(float), typeof(XEntry), default(float));

        public static readonly BindableProperty InternalPaddingProperty =
            BindableProperty.Create("InternalPadding", typeof(int), typeof(XEntry), default(int));

        public static readonly BindableProperty BoxStyleEnabledProperty =
            BindableProperty.Create("BoxStyleEnabled", typeof(bool), typeof(XEntry), false);

        public static readonly BindableProperty BorderColorFucusedProperty =
            BindableProperty.Create("BorderColorFocused", typeof(Color), typeof(XEntry), default(Color));
        #endregion

        #region Implementing Bindable Properties.
        /// <summary>
        /// (Shared) Define the border color.
        /// </summary>
        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        /// <summary>
        /// If this property is active, properties that different of BorderColor will be applied
        /// </summary>
        public bool BoxStyleEnabled
        {
            get => (bool)GetValue(BoxStyleEnabledProperty);
            set => SetValue(BoxStyleEnabledProperty, value);
        }

        /// <summary>
        /// (CustomModeEnabled) Define the edge size of border.
        /// </summary>
        public int BoxEdgeSize
        {
            get => (int)GetValue(BoxEdgeSizeProperty);
            set => SetValue(BoxEdgeSizeProperty, value);
        }

        /// <summary>
        /// (CustomModeEnabled) Define the border radius.
        /// </summary>
        public float BoxBorderRadius
        {
            get => (float)GetValue(BorderRadiusProperty);
            set => SetValue(BorderRadiusProperty, value);
        }

        /// <summary>
        /// (Shared) Define space between inside text and the border of Entry.
        /// </summary>
        public int InternalPadding
        {
            get => (int)GetValue(InternalPaddingProperty);
            set => SetValue(InternalPaddingProperty, value);
        }

        /// <summary>
        /// (Shared) Define the border color when the Entry is focused.
        /// </summary>
        public Color BorderColorFocused
        {
            get => (Color)GetValue(BorderColorFucusedProperty);
            set => SetValue(BorderColorFucusedProperty, value);
        }

        #endregion
    }
}
