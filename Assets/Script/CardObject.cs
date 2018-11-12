using System.Collections.Generic;

namespace CardObjects {

    public class CardObject
    {

        public int value { get; set; }
        public string face { get; set; }

    }

    // type. 1 = total. 2 = contains ace. 3 = pair.
    public class CreateDeck
    {
        public static List<CardObject> createDeck()
        {
            List<CardObject> deckList = new List<CardObject>
        {

            new CardObject() {value = 1, face = "Ace"},
            new CardObject() {value = 1, face = "Ace"},
            new CardObject() {value = 1, face = "Ace"},
            new CardObject() {value = 1, face = "Ace"},
            new CardObject() {value = 2, face = "2"},
            new CardObject() {value = 2, face = "2"},
            new CardObject() {value = 2, face = "2"},
            new CardObject() {value = 2, face = "2"},
            new CardObject() {value = 3, face = "3"},
            new CardObject() {value = 3, face = "3"},
            new CardObject() {value = 3, face = "3"},
            new CardObject() {value = 3, face = "3"},
            new CardObject() {value = 4, face = "4"},
            new CardObject() {value = 4, face = "4"},
            new CardObject() {value = 4, face = "4"},
            new CardObject() {value = 4, face = "4"},
            new CardObject() {value = 5, face = "5"},
            new CardObject() {value = 5, face = "5"},
            new CardObject() {value = 5, face = "5"},
            new CardObject() {value = 5, face = "5"},
            new CardObject() {value = 6, face = "6"},
            new CardObject() {value = 6, face = "6"},
            new CardObject() {value = 6, face = "6"},
            new CardObject() {value = 6, face = "6"},
            new CardObject() {value = 7, face = "7"},
            new CardObject() {value = 7, face = "7"},
            new CardObject() {value = 7, face = "7"},
            new CardObject() {value = 7, face = "7"},
            new CardObject() {value = 8, face = "8"},
            new CardObject() {value = 8, face = "8"},
            new CardObject() {value = 8, face = "8"},
            new CardObject() {value = 8, face = "8"},
            new CardObject() {value = 9, face = "9"},
            new CardObject() {value = 9, face = "9"},
            new CardObject() {value = 9, face = "9"},
            new CardObject() {value = 9, face = "9"},
            new CardObject() {value = 10, face = "10"},
            new CardObject() {value = 10, face = "10"},
            new CardObject() {value = 10, face = "10"},
            new CardObject() {value = 10, face = "10"},
            new CardObject() {value = 10, face = "Jack"},
            new CardObject() {value = 10, face = "Jack"},
            new CardObject() {value = 10, face = "Jack"},
            new CardObject() {value = 10, face = "Jack"},
            new CardObject() {value = 10, face = "Queen"},
            new CardObject() {value = 10, face = "Queen"},
            new CardObject() {value = 10, face = "Queen"},
            new CardObject() {value = 10, face = "Queen"},
            new CardObject() {value = 10, face = "King"},
            new CardObject() {value = 10, face = "King"},
            new CardObject() {value = 10, face = "King"},
            new CardObject() {value = 10, face = "King"},
        };

            return deckList;

        }


    }


}
