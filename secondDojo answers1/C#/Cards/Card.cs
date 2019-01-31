using System;
using System.Collections.Generic;

namespace Cards
{
    public class Card
    {
    //properties
        public string stringVal { get; set; }
        public string suit { get; set; }
        public int val { get; set; }

    //constructors    
        public Card (string name, string suitType, int value)
        {
            stringVal = name;
            suit = suitType;
            val = value;
        }
    }
}
