using System;
using System.Collections.Generic;

namespace Cards
{
    public class Player
    {
        string name;
        public List<Card> hand; 

        public Player(string human)
        {
            name = human;
            hand = new List<Card>();
        }
        public Card draw (Deck mydeck)
        {
            Card newcard = mydeck.deal();
            hand.Add(newcard);
            return newcard;
        }
        public Card getridof(int index)
        {
            if(index < 0 || index > hand.Count){
                Console.WriteLine("Incorrect. Try again.");
                return null;
            }
            else{
                Card top = hand[index];
                hand.RemoveAt(index);
                return top;
            }

            }
        }

    }
