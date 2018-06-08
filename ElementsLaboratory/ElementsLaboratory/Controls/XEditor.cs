using Xamarin.Forms;

namespace ElementsLaboratory.Controls
{
    public class XEditor : Editor
    {
        public static readonly BindableProperty MaxLinesProperty =
            BindableProperty.CreateAttached("MaxLines", typeof(int), typeof(int), 1);

        public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create("Placeholder", typeof(string), typeof(XEditor), default(string));

        public static readonly BindableProperty BorderColorProperty =
           BindableProperty.Create("BorderColor", typeof(Color), typeof(XEditor), default(Color));

        public static readonly BindableProperty InternalPaddingProperty =
           BindableProperty.Create("InternalPadding", typeof(int), typeof(XEditor), default(int));

        public static readonly BindableProperty HorizontalTextAlignmentProperty =
           BindableProperty.Create("HorizontalTextAlignment", typeof(TextAlignment), typeof(XEditor), TextAlignment.Start);

        public static readonly BindableProperty BorderColorFocusedProperty =
            BindableProperty.Create("BorderColorFocused", typeof(Color), typeof(XEditor), default(Color));

        public static readonly BindableProperty PlaceholderColorProperty =
            BindableProperty.Create("PlaceholderColor", typeof(Color), typeof(XEditor), Color.Gray);

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public int MaxLines
        {
            get => (int)GetValue(MaxLinesProperty);
            set => SetValue(MaxLinesProperty, value);
        }

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        public Color BorderColorFocused
        {
            get => (Color)GetValue(BorderColorFocusedProperty);
            set => SetValue(BorderColorFocusedProperty, value);
        }

        public int InternalPadding
        {
            get => (int)GetValue(InternalPaddingProperty);
            set => SetValue(InternalPaddingProperty, value);
        }

        public Color PlaceholderColor
        {
            get => (Color)GetValue(PlaceholderColorProperty);
            set => SetValue(PlaceholderColorProperty, value);
        }

        public TextAlignment HorizontalTextAlignment
        {
            get => (TextAlignment)GetValue(HorizontalTextAlignmentProperty);
            set => SetValue(HorizontalTextAlignmentProperty, value);
        }

        public XEditor()
        {
            TextChanged += OnTextChanged;
        }

        ~XEditor()
        {
            TextChanged -= OnTextChanged;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            InvalidateMeasure();
        }
    }
}
