using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

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

    //this will hold the running count object that will be hidden of a user presses a button
    public GameObject runningCountWindow;

    public GameObject hideButton;



    public GameObject playerCard1;
    public GameObject playerCard2;
    public GameObject dealerCard1;
    public GameObject dealerCard2;

    public GameObject gameOver;
    public Text actualRunningCount;
    public Text myRunningCount;


    public Text playersCount;
    private int countInt = 0;

    private int arraySum = 0;

    // the running total in the whole game
    public Text runningCount;

  

    public int card1;
    public int card2;
    public int card3;
    public int card4;



    public string card1Face;
    public string card2Face;
    public string card3Face;


    public int coinCount;
    public Text countText;



    private static System.Random rng = new System.Random();

    Stack<CardObject> Deck;

    List<int> cardsUsed;


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

        hideButton.SetActive(true);

        List<CardObject> deckList = new List<CardObject>
        {
            new CardObject() {card = 0, cardCountValue = -1, value = 1, face = "Ace"},
            new CardObject() {card = 1, cardCountValue = -1, value = 1, face = "Ace"},
            new CardObject() {card = 2, cardCountValue = -1, value = 1, face = "Ace"},
            new CardObject() {card = 3, cardCountValue = -1, value = 1, face = "Ace"},
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
            new CardObject() {card = 24, cardCountValue = 0, value = 7, face = "7"},
            new CardObject() {card = 25, cardCountValue = 0, value = 7, face = "7"},
            new CardObject() {card = 26, cardCountValue = 0, value = 7, face = "7"},
            new CardObject() {card = 27, cardCountValue = 0, value = 7, face = "7"},
            new CardObject() {card = 28, cardCountValue = 0, value = 8, face = "8"},
            new CardObject() {card = 29, cardCountValue = 0, value = 8, face = "8"},
            new CardObject() {card = 30, cardCountValue = 0, value = 8, face = "8"},
            new CardObject() {card = 31, cardCountValue = 0, value = 8, face = "8"},
            new CardObject() {card = 32, cardCountValue = 0, value = 9, face = "9"},
            new CardObject() {card = 33, cardCountValue = 0, value = 9, face = "9"},
            new CardObject() {card = 34, cardCountValue = 0, value = 9, face = "9"},
            new CardObject() {card = 35, cardCountValue = 0, value = 9, face = "9"},
            new CardObject() {card = 36, cardCountValue = -1, value = 10, face = "10"},
            new CardObject() {card = 37, cardCountValue = -1, value = 10, face = "10"},
            new CardObject() {card = 38, cardCountValue = -1, value = 10, face = "10"},
            new CardObject() {card = 39, cardCountValue = -1, value = 10, face = "10"},
            new CardObject() {card = 40, cardCountValue = -1, value = 10, face = "Jack"},
            new CardObject() {card = 41, cardCountValue = -1, value = 10, face = "Jack"},
            new CardObject() {card = 42, cardCountValue = -1, value = 10, face = "Jack"},
            new CardObject() {card = 43, cardCountValue = -1, value = 10, face = "Jack"},
            new CardObject() {card = 44, cardCountValue = -1, value = 10, face = "Queen"},
            new CardObject() {card = 45, cardCountValue = -1, value = 10, face = "Queen"},
            new CardObject() {card = 46, cardCountValue = -1, value = 10, face = "Queen"},
            new CardObject() {card = 47, cardCountValue = -1, value = 10, face = "Queen"},
            new CardObject() {card = 48, cardCountValue = -1, value = 10, face = "King"},
            new CardObject() {card = 49, cardCountValue = -1, value = 10, face = "King"},
            new CardObject() {card = 50, cardCountValue = -1, value = 10, face = "King"},
            new CardObject() {card = 51, cardCountValue = -1, value = 10, face = "King"},
        };
        Shuffle(deckList);

        Deck = new Stack<CardObject>(deckList);

        // this list will save all the values that have been popped from the deck
        // this is so I can keep track of the card number track
        cardsUsed = new List<int>();




        //TODO: need to reorganize the order these are dealt in
        //player card 1
        cardsUsed.Add(Deck.Peek().cardCountValue);
        card1 = Deck.Pop().card;
        pcards1.cardIndex = card1;
        pcards1.showFace();


        //player card 2
        cardsUsed.Add(Deck.Peek().cardCountValue);
        card2 = Deck.Pop().card;
        pcards2.cardIndex = card2;
        pcards2.showFace();


        //dealer card 1
        cardsUsed.Add(Deck.Peek().cardCountValue);
        card3 = Deck.Pop().card;
        dcards1.cardIndex = card3;
        dcards1.showFace();


        //dealer card 2
        cardsUsed.Add(Deck.Peek().cardCountValue);
        card4 = Deck.Pop().card;
        dcards2.cardIndex = card4;
        dcards2.showFace();


       

    }

    void Awake()
    {

        gameOver.SetActive(false);

        //player card 1
        pcards1 = playerCard1.GetComponent<Cards>();
        //player card 2
        pcards2 = playerCard2.GetComponent<Cards>();
        //dealer card 1
        dcards1 = dealerCard1.GetComponent<Cards>();
        //dealer card 2
        dcards2 = dealerCard2.GetComponent<Cards>();





    }

   
    void Update () {

        // shows the player's +/- count
        playersCount.text = countInt.ToString();

        //shows the coins up at the top
        coinCount = PlayerPrefs.GetInt("Coins");
        countText.text = coinCount.ToString();


    }

    public void updateCards()
    {

      
        

        
        arraySum = cardsUsed.Sum();
        // showing the total running total on the screen
        runningCount.text = arraySum.ToString();

        // when pressing the enter button, it checks if the answer is correct or not
        // and refreshes the gameboard
        if (countInt == arraySum)
        {
            // user is correct
            confirmationCardSwitch.changeCorrect();
            coinCount++;
            setCoinCount();

        }
        else
        {
           // user is incorrect
            confirmationCardSwitch.changeIncorrect();
        }


        //TODO: need to reorganize the order these are dealt in
        //player card 1
        cardsUsed.Add(Deck.Peek().cardCountValue);
        card1 = Deck.Pop().card;
        pcards1.cardIndex = card1;
        pcards1.showFace();


        //player card 2
        cardsUsed.Add(Deck.Peek().cardCountValue);
        card2 = Deck.Pop().card;
        pcards2.cardIndex = card2;
        pcards2.showFace();


        //dealer card 1
        cardsUsed.Add(Deck.Peek().cardCountValue);
        card3 = Deck.Pop().card;
        dcards1.cardIndex = card3;
        dcards1.showFace();


        //dealer card 2
        cardsUsed.Add(Deck.Peek().cardCountValue);
        card4 = Deck.Pop().card;
        dcards2.cardIndex = card4;
        dcards2.showFace();


        if (Deck.Count == 0)
        {

            gameOver.SetActive(true);

            actualRunningCount.text = "Actual running count: " + arraySum.ToString();
            myRunningCount.text = "My running count: " + countInt.ToString();

            // delete the running count from the left side because
            // it will confuse the user at the gameover screen
            runningCount.text = " ";

            StartCoroutine(Upload2());

        }


    }

    public void increment()
    {
        countInt++;
        
    }

    public void decrement()
    {
        countInt--;
      
    }

    void setCoinCount()
    {
        countText.text = coinCount.ToString();
        // Write into PlayerPreference to save the amount so when the user closes the game
        // and reopens it, the coins will be saved.
        PlayerPrefs.SetInt("Coins", coinCount);
    }

    public void hideCount()
    {


        runningCountWindow.SetActive(false);

    }

    public void showCount()
    {
        runningCountWindow.SetActive(true);

    }

    IEnumerator Upload2()
    {

        WWWForm form = new WWWForm();

        form.AddField("realCount", arraySum);
        form.AddField("usersCount", countInt);
        form.AddField("username", PlayerPrefs.GetString("Username"));


        UnityWebRequest www = UnityWebRequest.Post("http://107.170.227.172/card_counting_scores.php", form);
        yield return www.Send();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);

        }
        else
        {
            Debug.Log("Form upload complete!");


        }



    }


}
