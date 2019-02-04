using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoGame
{
    public class Player
    {
        //Variables
        public bool IsActive { get; private set; }
        public List<Card> hand;
        public int RemainingCards
        {
            get
            {
                return hand.Count;
            }
        }
        public bool HasCalledUno = false;
        public string Name;

        //Constructor
        public Player(bool isActive,string name)
        {
            IsActive = isActive;
            Name = name;
            hand = new List<Card>();
        }

        //Override
        public override string ToString()
        {
            return string.Format($"{Name} - {RemainingCards}");
        }

        //Methods
        public void ToggleActive()
        {
            IsActive = !IsActive;
        }

        public bool CallPersonalUno()
        {
            if(RemainingCards == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CallUnoOnOtherPlayer(Player other)
        {
            if(other.RemainingCards == 1 && !HasCalledUno)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DrawCard(Card card)
        {
            hand.Add(card);
            Debug.WriteLine("Card Added To hand" +
                card.ToString());
        }
    }
}
