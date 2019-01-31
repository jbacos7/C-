using System;
using System.Collections.Generic;

namespace Cards
{
    public class Deck
    {
        public List<Card> cards;
        public Deck ()
        {
            reset ();
            shuffle ();
        }
        public Deck reset ()
        {
            cards = new List<Card>();
            string[] stringVal = {"ace", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "jack", "queen", "king"};
            string[] suit = {"spades", "diamonds", "clubs", "hearts"};

            foreach (string x in suit)
            {
                for (int i = 0; i < stringVal.Length; i ++){
                    Card newcard = new Card (stringVal[i], x, i + 1);
                    cards.Add(newcard);
                }
            }
            return this;
        }
        public Deck shuffle ()
        {
            int unshuff = cards.Count;
            Card lastcard;
            int randomIndex;
            Random rand = new Random ();
            while (unshuff > 0)
            {
                randomIndex = rand.Next(0,52);
                lastcard = cards[--unshuff];
                cards[unshuff] = cards [randomIndex];
                cards[randomIndex] = lastcard;
            }
            return this;
        }
        public Card deal()
        {
            if (cards.Count > 0){
            Card top = cards[0];
            cards.RemoveAt(0);
            return top;
            }
            else{
                reset();
                return deal();
            }
            
        }
    }
}
