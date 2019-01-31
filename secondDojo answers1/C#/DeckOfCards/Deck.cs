using System;
using System.Collections.Generic;
namespace DeckOfCards
{
    public class Deck
    {
        List<string> stringVals = new List<string> {"ace", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "jack", "queen", "king"};
        
        List<string> suits = new List<string>  {"spades", "diamonds", "clubs", "hearts"};

        public List <Card> Cards = new List <Card> ();
        public Deck()
        {
            foreach (string suit in suits)
            {
                int numVal = 1;
                foreach (string stringVal in stringVals)
                {
                    Card newcard = new Card (stringVal, suit, numVal);
                    Cards.Add(newcard);
                    numVal++;
                }
            }
        }
    public void ReadDeck()
    {   
        foreach (Card card in Cards)
        {
            System.Console.WriteLine ($"{card.stringVals} of {card.suits}");
        }
    }


    public Card Deal()
    {
        Card dealtcard = Cards[0];
        Cards.Remove(dealtcard);
        return dealtcard;
    }

    public void Shuffle ()
    {
        Random rand = new Random ();
        for (int i = 0; i < Cards.Count; i++)
        {
            int newIdx = rand.Next(Cards.Count);
            Card temp = Cards[i];
            Cards[i] = Cards[newIdx];
            Cards[newIdx] = temp;

        }
    }
    }
}