using System.Collections.Generic;
namespace DeckOfCards
{

    public class Card
    {
    //properties
        public string stringVals { get; set; }
        public string suits { get; set; }
        public int val { get; set; }

    //constructors    
        public Card (string name, string suitType, int value)
        {
            stringVals = name;
            suits = suitType;
            val = value;
        }
    }
}
