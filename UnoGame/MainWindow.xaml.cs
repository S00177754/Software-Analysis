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

            //lstBxPlayerCards.ItemsSource = unodeck.players[0].hand;
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
            lstBxPlayerCards.ItemsSource = null;
            lstBxUnoDeck.ItemsSource = null;

            lstBxPlayerCards.ItemsSource = unodeck.players[0].hand;
            lstBxUnoDeck.ItemsSource = unodeck.cards;
        }

        private void BtnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (txBxAddPlayerName.Text != null || txBxAddPlayerName.Text != " ")
            {
                unodeck.players.Add(new Player(true, txBxAddPlayerName.Text));
                ReAssignPlayerList();
            }
        }

        private void BtnRemovePlayer_Click(object sender, RoutedEventArgs e)
        {
            if(lstBxPlayerList.SelectedItem != null)
            {
                unodeck.players.Remove(lstBxPlayerList.SelectedItem as Player);
                ReAssignPlayerList();
            }
        }

        public void ReAssignPlayerList()
        {
            lstBxPlayerList.ItemsSource = null;
            lstBxPlayerList.ItemsSource = unodeck.players;
        }

        private void BtnMakeActive_Click(object sender, RoutedEventArgs e)
        {
            if (lstBxPlayerList.SelectedItem != null)
            {
                (lstBxPlayerList.SelectedItem as Player).Activate();
                ReAssignPlayerList();

                UpdateMoveList();
            }
        }

        private void BtnMakeUnactive_Click(object sender, RoutedEventArgs e)
        {
            if (lstBxPlayerList.SelectedItem != null)
            {
                (lstBxPlayerList.SelectedItem as Player).Unactivate();
                ReAssignPlayerList();

                UpdateMoveList();
            }
        }

        private void UpdateMoveList()
        {
            unodeck.activePlayers = null;
            for (int i = 0; i < unodeck.players.Count; i++)
            {
                if (unodeck.players[i].IsActive == true)
                {
                    unodeck.activePlayers.Add(unodeck.players[i]);
                }
            }
        }

        //Player Options
        private void BtnPlayCard_Click(object sender, RoutedEventArgs e)
        {
            NextTurn();
        }

        private void BtnDrawCard_Click(object sender, RoutedEventArgs e)
        {
            NextTurn();
        }

        private void BtnCallUno_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextTurn()
        {
            int temp = -1;

            for (int i = 0; i < unodeck.activePlayers.Count; i++)
            {
                if (unodeck.activePlayers[i].IsActive == true && unodeck.activePlayers[i].Turn == true)
                {
                    temp = unodeck.activePlayers.IndexOf(unodeck.activePlayers[i]);
                    if((temp + 1) > unodeck.activePlayers.Count)
                    {
                        temp = 0;
                    }
                    unodeck.activePlayers[i].Turn = false;
                }
            }
            unodeck.activePlayers[temp].Turn = true;

            lstBxPlayerCards.ItemsSource = null;
            lstBxPlayerCards.ItemsSource = unodeck.activePlayers[temp].hand;
        }
    }
}
