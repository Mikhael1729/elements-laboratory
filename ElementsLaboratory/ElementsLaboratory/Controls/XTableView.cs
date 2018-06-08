using Xamarin.Forms;

namespace ElementsLaboratory.Controls
{
    public class XTableView : TableView
    {
        public static readonly BindableProperty GroupHeaderColorProperty =
            BindableProperty.Create("GroupHeaderColor", typeof(Color), typeof(XTableView), Color.Black);

        public static readonly BindableProperty SeperatorVisibleProperty =
            BindableProperty.Create("SeperatorVisible", typeof(SeparatorVisibility), typeof(XTableView), SeparatorVisibility.Default);

        public SeparatorVisibility SeperatorVisible
        {
            get { return (SeparatorVisibility)GetValue(SeperatorVisibleProperty); }
            set { SetValue(SeperatorVisibleProperty, value); }
        }

        public Color GroupHeaderColor
        {
            get => (Color)GetValue(GroupHeaderColorProperty);
            set => SetValue(GroupHeaderColorProperty, value);
        }
    }
}