using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfViews.Vinho
{
    /// <summary>
    /// Interação lógica para ucRatingStar.xam
    /// </summary>
    public partial class ucRatingStar : UserControl
    {
        public ucRatingStar()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty RatingValueProperty = DependencyProperty.Register(
            "RatingValue",
            typeof(Int32),
            typeof(ucRatingStar),
            new PropertyMetadata(0, new PropertyChangedCallback(RatingValueChanged)));

        public Int32 RatingValue
        {
            get
            {

                return (Int32)GetValue(RatingValueProperty);
            }
            set
            {
                if (value < 0)
                {
                    SetValue(RatingValueProperty, 0);
                }
                else if (value > 5)
                {
                    SetValue(RatingValueProperty, 5);
                }
                else
                {
                    SetValue(RatingValueProperty, value);
                }
            }
        }

        private static void RatingValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void RatingButtonClickEventHandler(Object sender, RoutedEventArgs e)
        {
            ToggleButton button = sender as ToggleButton;
            RatingValue = Int32.Parse((String)button.Tag);
        }
    }

}
