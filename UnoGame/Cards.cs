using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoGame
{
    public class Card
    {
        //Enums by Card Game
        public enum UnoCards { Zero,One,Two,Three,Four,Five,Six,Seven,Eight,Nine,Reverse,Skip,PlusTwo,PlusFour,ChangeColor};
        public enum UnoColors { Red, Yellow, Blue, Green, Black }
        
        //Variables
        public UnoCards Symbol;
        public UnoColors Color;

        //Constructor
        public Card(UnoCards symbol,UnoColors color)
        {
            Color = color;
            Symbol = symbol;
        }

        //Overrides
        public override string ToString()
        {
            return string.Format($"{Color} - {Symbol}");
        }

    }

    public class Deck
    {
        //Enums by Card Game
        public enum CardGame { Uno,Empty };

        //Variables
        public List<Card> cards;
        public int RemainingCards
        {
            get
            {
                return cards.Count;
            }
        }

        public List<Player> players;
        public List<Player> activePlayers;

        //Constructor
        public Deck(CardGame gameType)
        {
            cards = new List<Card>();

            players = new List<Player>();
            activePlayers = new List<Player>();
            
            switch (gameType)
            {
                case 0:
                    GenerateUnoDeck();
                    break;

                default:
                    break;
            }

        }

        //Methods
        public void GenerateUnoDeck()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        cards.Add(new Card((Card.UnoCards)j, (Card.UnoColors)i));
                    }
                }

                cards.Add(new Card(Card.UnoCards.PlusFour,Card.UnoColors.Black));
                cards.Add(new Card(Card.UnoCards.ChangeColor, Card.UnoColors.Black));

            }
        }

        public void ShuffleDeck()
        {
            Random rng = new Random();
            int listSpace = 0;

            Card[] tempList = new Card[cards.Count];

            for (int i = 0; i < cards.Count; i++)
            {
                bool spaceEmpty = true;

                while (spaceEmpty)
                {

                    listSpace = rng.Next(0, cards.Count);

                    if (tempList[listSpace] == null)
                    {
                         Debug.WriteLine("Reordered:" + listSpace);

                        tempList[listSpace] = cards[i];
                        spaceEmpty = false;
                    }
                    else
                    {
                        Debug.WriteLine("TryAgain:" + listSpace);

                        spaceEmpty = true;
                    }
                }
            }

            cards = tempList.ToList();

        }

        public void NewPlayer(string playerName,bool playing)
        {
            players.Add(new Player(playing, playerName));
        }

        public void DealCards(int amountOfCards)
        {
            foreach (var player in players)
            {
                if (player.IsActive)
                {
                    for (int i = 0; i < amountOfCards; i++)
                    {
                        Debug.WriteLine("Drawing");
                        player.DrawCard(cards.First());
                        cards.Remove(cards.First());
                    }
                }
            }
        }
    }
    
}
