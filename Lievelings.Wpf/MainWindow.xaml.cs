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

namespace Lievelings.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    /*Methoden gebruiken van het return type void met parameters
Maak de volgende methoden die parameters vragen, m.a.w. er wordt een bevel gegeven waarbij er meegegeven wordt waarop de methode zich moet baseren om het bevel uit te voeren.

Methode WijzigBeschikbaarheidTaalKnoppen
Deze methode zorgt ervoor dat er altijd maar één button beschikbaar (enabled) is. De parameter isNlBeschikbaar duidt aan of de btnNL al dan niet beschikbaar is. Voor de btnENG geldt steeds het tegenovergestelde.

De methode wordt gecalled bij het opstarten (btnENG beschikbaar) en bij btnNL_Click en btnENG_Click.

WijzigZichtbaarheid
ToonKnoppen en VerbergKnoppen wordt gereduceerd tot één methode.

Deze methode ontvangt een parameter zichtbaarheid van het type Visibility en zal dus de waarde Visibility.Visible of Visibility.Hidden moeten ontvangen.

Verwijder nadien ToonKnoppen en VerbergKnoppen en pas de calls aan.*/
    public partial class MainWindow : Window
    {
        string stad;
        string beginVanDeZin;

        const string BeginNed = "Je lievelingsstad is ";
        const string BeginEng = "Your favorite city is ";
        const string TitelNed = "Kies je lievelingsstad";
        const string TitelEng = "Choose your favorite city";

        public MainWindow()
        {
            InitializeComponent();
            beginVanDeZin = BeginNed;
        }
        void WijzigBeschikaarheidTaalKnoppen(bool isBtnNederlandsBeschikbaar) {
            btnNl.IsEnabled = isBtnNederlandsBeschikbaar;
            // ! verandert een true in false in dit geval
            btnEn.IsEnabled = !isBtnNederlandsBeschikbaar;
        }

        private void VulLstSteden()
        {
            lstSteden.Items.Add("Antwerpen");
            lstSteden.Items.Add("Brugge");
            lstSteden.Items.Add("Brussel");
            lstSteden.Items.Add("Gent");
            lstSteden.Items.Add("Hasselt");
        }
        void WijzigZichtbaarheidTaalKnoppen(Visibility zichtbaarheid) {

            btnEn.Visibility = zichtbaarheid;
            btnNl.Visibility = zichtbaarheid;
        }
        /*private void VerbergKnoppen()
        {
            btnEn.Visibility = Visibility.Hidden;
            btnNl.Visibility = Visibility.Hidden;
        }
        private void ToonKnoppen()
        {
            btnEn.Visibility = Visibility.Visible;
            btnNl.Visibility = Visibility.Visible;
        }*/

        private void ToonEngelstaligeOpschriften()
        {
            beginVanDeZin = BeginEng;

            lblLievelingsStad.Content = $"{beginVanDeZin}{stad}";

            Title = TitelEng;
        }
        
        private void ToonNederlandstaligeOpschriften()
        {
            beginVanDeZin = BeginNed;

            lblLievelingsStad.Content = $"{beginVanDeZin}{stad}";

            Title = TitelNed;
        }
        
        private void btnEn_Click(object sender, RoutedEventArgs e)
        {
            ToonEngelstaligeOpschriften();
            WijzigBeschikaarheidTaalKnoppen(true);
        }

        private void btnNl_Click(object sender, RoutedEventArgs e)
        {
            ToonNederlandstaligeOpschriften();
            WijzigBeschikaarheidTaalKnoppen(false);
        }
        
        private void lstSteden_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            stad = lstSteden.SelectedItem.ToString();
            lblLievelingsStad.Content = $"{beginVanDeZin}{stad}";

            WijzigZichtbaarheidTaalKnoppen(Visibility.Visible);
        }3

        private void wndMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            VulLstSteden();

            WijzigZichtbaarheidTaalKnoppen(Visibility.Hidden);
            WijzigBeschikaarheidTaalKnoppen(false);

            Title = TitelNed;
        }
    }
}
