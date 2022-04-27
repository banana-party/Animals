using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Animals.WPF.Services
{
    public class CustomButton : Button
    {
        public Brush RandomBgColor
        {
            get => (Brush)GetValue(RandomBgColorProperty);
            set => SetValue(RandomBgColorProperty, value);
        }

        public static readonly DependencyProperty RandomBgColorProperty =
            DependencyProperty.Register("RandomBgColor", typeof(Brush), typeof(CustomButton),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, SetRandomBg));

        private static void SetRandomBg(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomButton b)
            {
                b.Background = (Brush)e.NewValue;
            }
        }

    }
}
