﻿using System.Windows.Input;
using Xamarin.Forms;

namespace ElementsLaboratory.Controls
{
    public class SearchPage : ContentPage
    {
        public static readonly BindableProperty SearchPlaceHolderTextProperty = 
            BindableProperty.Create(nameof(SearchPlaceHolderText), typeof(string), typeof(SearchPage), string.Empty);

        public static readonly BindableProperty SearchTextProperty = 
            BindableProperty.Create(nameof(SearchText), typeof(string), typeof(SearchPage), string.Empty);

        public static readonly BindableProperty SearchCommandProperty = 
            BindableProperty.Create(nameof(SearchCommand), typeof(ICommand), typeof(SearchPage));

        public string SearchPlaceHolderText
        {
            get => (string)GetValue(SearchPlaceHolderTextProperty);
            set => SetValue(SearchPlaceHolderTextProperty, value);
        }

        public string SearchText
        {
            get => (string)GetValue(SearchTextProperty);
            set => SetValue(SearchTextProperty, value);
        }

        public ICommand SearchCommand
        {
            get => (ICommand)GetValue(SearchCommandProperty);
            set => SetValue(SearchCommandProperty, value);
        }
    }
}
