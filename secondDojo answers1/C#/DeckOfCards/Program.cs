using System;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck newdeck = new Deck ();
            newdeck.ReadDeck();
            newdeck.Deal();
            newdeck.ReadDeck();
            newdeck.Shuffle();
            System.Console.WriteLine("*********");
            // newdeck.Shuffle();
            Player Jason = new Player("Jason");
            Jason.Draw(newdeck);
            Jason.Draw(newdeck);
            Jason.Draw(newdeck);
            Jason.Draw(newdeck);
            Jason.Draw(newdeck);
            foreach (Card card in Jason.Hand)
            {
                System.Console.WriteLine(card.stringVals);
            }
        }
    }
}
