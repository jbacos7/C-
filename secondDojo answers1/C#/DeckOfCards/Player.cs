using System.Collections.Generic;
namespace DeckOfCards
{
    public class Player
    {
        public string Name { get; set; }
        public List <Card> Hand = new List<Card>();

        public Player (string name)
        {
            Name = name;
        }
        public Card Draw (Deck cardDeck)
        {
            Card drawn = cardDeck.Deal();
            Hand.Add(drawn);
            return drawn;

        }
    }
}