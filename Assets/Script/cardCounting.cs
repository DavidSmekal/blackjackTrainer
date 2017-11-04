using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class cardCounting :  MonoBehaviour {


    public class CardObject
    {
        public int card { get; set; }
        public int cardCountValue { get; set; }
        public int value { get; set; }
        public string face { get; set; }
        
    }

    Cards pcards1;
    Cards pcards2;
    Cards dcards1;
    Cards dcards2;
    Cards p2cards1;
    Cards p2cards2;


    public GameObject playerCard1;
    public GameObject playerCard2;
    public GameObject dealerCard1;
    public GameObject dealerCard2;
    public GameObject player2Card1;
    public GameObject player2Card2;




    //will have the skin name in here
    public string skin;

    public int card1;
    public int card2;
    public int card3;
    public int card4;
    public int card5;
    public int card6;


    public string card1Face;
    public string card2Face;
    public string card3Face;

  

    private static System.Random rng = new System.Random();

    Stack<CardObject> Deck;


    // Fisher-Yates Shuffle algorithm taken from https://stackoverflow.com/questions/273313/randomize-a-listt
    public static void Shuffle<T>(IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

  



    // Use this for initialization
    void Start () {

        //finds the skin stored in player preference and uses it to set the cardback
        skin = PlayerPrefs.GetString("Skin");

        List<CardObject> haha = new List<CardObject>
        {
            new CardObject() {card = 0, cardCountValue = 1, value = 1, face = "Ace"},
            new CardObject() {card = 1, cardCountValue = 1, value = 1, face = "Ace"},
            new CardObject() {card = 2, cardCountValue = 1, value = 1, face = "Ace"},
            new CardObject() {card = 3, cardCountValue = 1, value = 1, face = "Ace"},
            new CardObject() {card = 4, cardCountValue = 1, value = 2, face = "2"},
            new CardObject() {card = 5, cardCountValue = 1, value = 2, face = "2"},
            new CardObject() {card = 6, cardCountValue = 1, value = 2, face = "2"},
            new CardObject() {card = 7, cardCountValue = 1, value = 2, face = "2"},
            new CardObject() {card = 8, cardCountValue = 1, value = 3, face = "3"},
            new CardObject() {card = 9, cardCountValue = 1, value = 3, face = "3"},
            new CardObject() {card = 10, cardCountValue = 1, value = 3, face = "3"},
            new CardObject() {card = 11, cardCountValue = 1, value = 3, face = "3"},
            new CardObject() {card = 12, cardCountValue = 1, value = 4, face = "4"},
            new CardObject() {card = 13, cardCountValue = 1, value = 4, face = "4"},
            new CardObject() {card = 14, cardCountValue = 1, value = 4, face = "4"},
            new CardObject() {card = 15, cardCountValue = 1, value = 4, face = "4"},
            new CardObject() {card = 16, cardCountValue = 1, value = 5, face = "5"},
            new CardObject() {card = 17, cardCountValue = 1, value = 5, face = "5"},
            new CardObject() {card = 18, cardCountValue = 1, value = 5, face = "5"},
            new CardObject() {card = 19, cardCountValue = 1, value = 5, face = "5"},
            new CardObject() {card = 20, cardCountValue = 1, value = 6, face = "6"},
            new CardObject() {card = 21, cardCountValue = 1, value = 6, face = "6"},
            new CardObject() {card = 22, cardCountValue = 1, value = 6, face = "6"},
            new CardObject() {card = 23, cardCountValue = 1, value = 6, face = "6"},
            new CardObject() {card = 24, cardCountValue = 1, value = 7, face = "7"},
            new CardObject() {card = 25, cardCountValue = 1, value = 7, face = "7"},
            new CardObject() {card = 26, cardCountValue = 1, value = 7, face = "7"},
            new CardObject() {card = 27, cardCountValue = 1, value = 7, face = "7"},
            new CardObject() {card = 28, cardCountValue = 1, value = 8, face = "8"},
            new CardObject() {card = 29, cardCountValue = 1, value = 8, face = "8"},
            new CardObject() {card = 30, cardCountValue = 1, value = 8, face = "8"},
            new CardObject() {card = 31, cardCountValue = 1, value = 8, face = "8"},
            new CardObject() {card = 32, cardCountValue = 1, value = 9, face = "9"},
            new CardObject() {card = 33, cardCountValue = 1, value = 9, face = "9"},
            new CardObject() {card = 34, cardCountValue = 1, value = 9, face = "9"},
            new CardObject() {card = 35, cardCountValue = 1, value = 9, face = "9"},
            new CardObject() {card = 36, cardCountValue = 1, value = 10, face = "10"},
            new CardObject() {card = 37, cardCountValue = 1, value = 10, face = "10"},
            new CardObject() {card = 38, cardCountValue = 1, value = 10, face = "10"},
            new CardObject() {card = 39, cardCountValue = 1, value = 10, face = "10"},
            new CardObject() {card = 40, cardCountValue = 1, value = 10, face = "Jack"},
            new CardObject() {card = 41, cardCountValue = 1, value = 10, face = "Jack"},
            new CardObject() {card = 42, cardCountValue = 1, value = 10, face = "Jack"},
            new CardObject() {card = 43, cardCountValue = 1, value = 10, face = "Jack"},
            new CardObject() {card = 44, cardCountValue = 1, value = 10, face = "Queen"},
            new CardObject() {card = 45, cardCountValue = 1, value = 10, face = "Queen"},
            new CardObject() {card = 46, cardCountValue = 1, value = 10, face = "Queen"},
            new CardObject() {card = 47, cardCountValue = 1, value = 10, face = "Queen"},
            new CardObject() {card = 48, cardCountValue = 1, value = 10, face = "King"},
            new CardObject() {card = 49, cardCountValue = 1, value = 10, face = "King"},
            new CardObject() {card = 50, cardCountValue = 1, value = 10, face = "King"},
            new CardObject() {card = 51, cardCountValue = 1, value = 10, face = "King"},
        };
        Shuffle(haha);

        Deck = new Stack<CardObject>(haha);





        //TODO: need to reorganize the order these are dealt in
        //player card 1
        card1 = Deck.Pop().card;
        pcards1.cardIndex = card1;
        pcards1.showFace();


        //player card 2
        card2 = Deck.Pop().card;
        pcards2.cardIndex = card2;
        pcards2.showFace();


        //dealer card 1
        card3 = Deck.Pop().card;
        dcards1.cardIndex = card3;
        dcards1.showFace();


        //dealer card 2
        card4 = Deck.Pop().card;
        dcards2.cardIndex = card4;
        dcards2.showBack(skin);

        //player2 card 1
        card5 = Deck.Pop().card;
        p2cards1.cardIndex = card5;
        p2cards1.showFace();

        //player2 card 1
        card6 = Deck.Pop().card;
        p2cards2.cardIndex = card6;
        p2cards2.showFace();

    }

    void Awake()
    {
      

        //player card 1
        pcards1 = playerCard1.GetComponent<Cards>();
        //player card 2
        pcards2 = playerCard2.GetComponent<Cards>();
        //dealer card 1
        dcards1 = dealerCard1.GetComponent<Cards>();
        //dealer card 2
        dcards2 = dealerCard2.GetComponent<Cards>();
        //player2 card 1
        p2cards1 = player2Card1.GetComponent<Cards>();
        //player2 card 2
        p2cards2 = player2Card2.GetComponent<Cards>();




    }

    // Update is called once per frame
    void Update () {
       


    }

    public void updateCards()
    {

        //TODO: need to reorganize the order these are dealt in
        //player card 1
        card1 = Deck.Pop().card;
        pcards1.cardIndex = card1;
        pcards1.showFace();


        //player card 2
        card2 = Deck.Pop().card;
        pcards2.cardIndex = card2;
        pcards2.showFace();


        //dealer card 1
        card3 = Deck.Pop().card;
        dcards1.cardIndex = card3;
        dcards1.showFace();


        //dealer card 2
        card4 = Deck.Pop().card;
        dcards2.cardIndex = card4;
        dcards2.showBack(skin);

        //player2 card 1
        card5 = Deck.Pop().card;
        p2cards1.cardIndex = card5;
        p2cards1.showFace();

        //player2 card 1
        card6 = Deck.Pop().card;
        p2cards2.cardIndex = card6;
        p2cards2.showFace();

    }
}
