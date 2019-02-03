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

        //Constructor
        public Deck(CardGame gameType)
        {
            cards = new List<Card>();

            switch (gameType)
            {
                case 0:
                    GenerateUnoDeck();
                    ShuffleDeck();
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
            


        }
    }
    
}
