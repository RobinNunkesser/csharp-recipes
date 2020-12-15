using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ContentViewRecipe
{
    public partial class MyView : ContentView
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string),
                typeof(MyView), string.Empty);

        public static readonly BindableProperty EntryTextProperty =
            BindableProperty.Create(nameof(EntryText), typeof(string),
                typeof(MyView), string.Empty, BindingMode.TwoWay);

        public MyView()
        {
            InitializeComponent();
            ItemNrEntry.TextChanged += (sender, args) =>
                EntryText = ItemNrEntry.Text;
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string EntryText
        {
            get => (string)GetValue(EntryTextProperty);
            set => SetValue(EntryTextProperty, value);
        }


        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == null) return;

            if (propertyName == TitleProperty.PropertyName)
                TitleLabel.Text = Title;
            if (propertyName == EntryTextProperty.PropertyName)
                ItemNrEntry.Text = EntryText;
        }
    }
}
