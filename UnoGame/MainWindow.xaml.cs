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

namespace UnoGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Deck unodeck;
        

        public MainWindow()
        {
            InitializeComponent();

            unodeck = new Deck(Deck.CardGame.Uno);
            lstBxUnoDeck.ItemsSource = unodeck.cards;

            unodeck.NewPlayer("Me", true);
            unodeck.NewPlayer("Me2", true);
            lstBxPlayerOne.ItemsSource = unodeck.players[0].hand;
            lstBxPlayerTwo.ItemsSource = unodeck.players[1].hand;
        }

        private void BtnShuffle_Click(object sender, RoutedEventArgs e)
        {
            unodeck.ShuffleDeck();
            lstBxUnoDeck.ItemsSource = null;
            lstBxUnoDeck.ItemsSource = unodeck.cards;
        }

        private void BtnDraw_Click(object sender, RoutedEventArgs e)
        {
            unodeck.DealCards(4);
            lstBxPlayerOne.ItemsSource = null;
            lstBxPlayerTwo.ItemsSource = null;
            lstBxUnoDeck.ItemsSource = null;

            lstBxPlayerOne.ItemsSource = unodeck.players[0].hand;
            lstBxPlayerTwo.ItemsSource = unodeck.players[1].hand;
            lstBxUnoDeck.ItemsSource = unodeck.cards;
        }
    }
}
