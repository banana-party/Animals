using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Animals.WPF.Views;

namespace Animals.WPF.Services
{
    public class CustomButton : Button
    {
        //public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
        //"Text",
        //typeof(string),
        //typeof(TextBlock),
        //new FrameworkPropertyMetadata(
        //    string.Empty,
        //FrameworkPropertyMetadataOptions.AffectsMeasure |
        //FrameworkPropertyMetadataOptions.AffectsRender,
        //new PropertyChangedCallback(OnTextChanged),
        //new CoerceValueCallback(CoerceText)));
        public Brush RandomBgColor
        {
            get => (Brush)GetValue(RandomBgColorProperty);
            set => SetValue(RandomBgColorProperty, value);
        }

        // Using a DependencyProperty as the backing store for RandomBgColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RandomBgColorProperty =
            DependencyProperty.Register("RandomBgColor", typeof(Brush), typeof(CustomButton),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(SetRandomBg)));

        private static void SetRandomBg(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomButton b)
            {
                b.Background = (Brush)e.NewValue;
            }
        }

    }
}
