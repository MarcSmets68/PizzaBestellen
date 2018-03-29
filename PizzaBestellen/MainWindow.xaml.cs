using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PizzaBestellen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void meer_Click(object sender, RoutedEventArgs e)
        {
            int aantal = Convert.ToInt16(TextHoeveelheid.Content);
            if (aantal < 10)
            {
                aantal++;
                TextHoeveelheid.Content = aantal.ToString();
            }
        }

        private void minder_Click(object sender, RoutedEventArgs e)
        {
            int aantal = Convert.ToInt16(TextHoeveelheid.Content);
            if (aantal > 1)
            {
                aantal--;
                TextHoeveelheid.Content = aantal.ToString();
            }
        }

        private void Bestellen_Click(object sender, RoutedEventArgs e)
        {
            string tekst = " U heeft " + TextHoeveelheid.Content + " ";

            string ingredienten = string.Empty;
            foreach (FrameworkElement kind in boxen.Children)
            {
                if (kind is RadioButton)
                {
                    if (((RadioButton)kind).IsChecked == true)
                        tekst += kind.Name + @" pizza('s) besteld met: ";
                }
                if (kind is CheckBox)
                    if (((CheckBox)kind).IsChecked == true)
                        ingredienten += kind.Name + ", ";
            }
            ingredienten = ingredienten.Substring(0, ingredienten.Length - 2);
            int k = ingredienten.LastIndexOf(",");
            ingredienten = ingredienten.Substring(0, k) + " en " + ingredienten.Substring(k + 2);
            tekst += ingredienten + "\n";
            if (TogglebuttonExtraDikkeKorst.IsChecked == true)
                tekst += " met een extra dikke korst \n";
            if (TogglebuttonExtraKaas.IsChecked == true)
                tekst += " overstrooid met extra kaas";
            BesteldePizza.Content = tekst;
        }
    }
}
