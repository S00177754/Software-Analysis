using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        private string Status { get; set; }
        public bool Turn { get; set; } = false;

        //Constructor
        public Player(bool isActive,string name)
        {
            IsActive = isActive;
            if (isActive)
                Status = "Playing";
            else
                Status = "Not Playing";

            Name = name;
            hand = new List<Card>();
        }

        //Override
        public override string ToString()
        {
            return string.Format($"{Name} - {RemainingCards} - {Status}");
        }

        //Methods
        public void Activate()
        {
            IsActive = true;
            Status = "Playing";
        }
        public void Unactivate()
        {
            IsActive = false;
            Status = "Not Playing";
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
                MessageBox.Show("Selected player has more than 1 card or has called Uno already.");
                return false;
            }
        }

        public void DrawCard(Card card)
        {
            hand.Add(card);
            Debug.WriteLine("Card Added To hand" +
                card.ToString());
        }

        public void ClearHand()
        {
            hand = new List<Card>();
        }
    }
}
