using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System;
using CardObjects;

public class tutorial : MonoBehaviour
{
 
    // This is the collection of tutorial canvas's
    public GameObject firstLevel;
    public GameObject secondLevel;
    public GameObject thirdLevel;
    public GameObject fourthLevel;
    public GameObject fifthLevel;
    public GameObject sixthLevel;
    public GameObject seventhLevel;
    public GameObject eighthLevel;
    public GameObject ninthLevel;
    public GameObject tenthLevel;
    public GameObject elevenLevel;
    public GameObject twelveLevel;
    public GameObject thirteenLevel;
    public GameObject fourteenLevel;
    public GameObject fifteenLevel;



    public GameObject buyCoinsModal;


    // I need to store something from the gameobject. could be anything. i'll do the camera
    public GameObject randomObject;



    Cards pcards1;
    Cards pcards2;
    Cards dcards1;
    Cards dcards2;

    //feedback cards
    Cards fpcards1;
    Cards fpcards2;
    Cards fdcards1;

    //buttons
    public GameObject hitButton;
    public GameObject stayButton;
    public GameObject doubleButton;
    public GameObject splitButton;
    public GameObject helpButton;



    public GameObject rightSide;

    storePurchases storePuchases;

    //this will hold the modal window
    public GameObject modalWindow;

    // this will change the text in the modal popup
    public Text modalFeedbackHelp;

    //this is the coin count text field
    public Text countText;
    // this will be the total running count of the coins
    private int coinCount = 0;

    //this is the streak counter text field
    public Text streakCountText;

    //this will keep track of the streak
    private int streakCount = 0;
    //this will keep track of the highest streak count
    private int highestStreakCount = 0;

    //changes a number in the button methods to see if the user is right
    public int correctAnswerNumber;


    public GameObject playerCard1;
    public GameObject playerCard2;
    public GameObject dealerCard1;
    public GameObject dealerCard2;

    public GameObject closeModuleButton;

    //feedback cards
    public GameObject feedbackplayerCard1;
    public GameObject feedbackplayerCard2;
    public GameObject feedbackdealerCard1;

    // these show the text of the totals on the UI screen
    public Text playerValueTotal;
    public Text dealerValueTotal;

    // this will show the user if they are correc or incorrect.
    // it is located right above the feedbacktext
    public Text correctOrIncorrect;

    // this will show the feedback text on the screen
    public Text feedBackText;

    // shows what choice the player picked
    public Text playersMove;


    // play card audio
    public AudioSource cardDeal;



    //will have the skin name in here
    public string skin;

    public int card1;
    public int card2;
    public int card3;
    public int card4;

    int returned = 0;

    public string card1Face;
    public string card2Face;
    public string card3Face;

    //these will hold the answers they got right or wrong
    public int correct;
    public int incorrect;

    //this will hold the textbox of the percentage
    public Text percentageText;




    //method to shuffle the array
    private int[] shuffleArray(int[] deck)
    {

        //shuffling the array
        // TODO: change the shuffling to an actual shuffling algorithm: Knuth shuffle algorithm
        var i = new System.Random();
        int[] MyRandomArray = deck.OrderBy(x => i.Next()).ToArray();

        return MyRandomArray;
    }




    void Awake()
    {
        // this hides the modal pop up
        modalWindow.SetActive(false);
        buyCoinsModal.SetActive(false);

        // all the tutorial canvas's will be here
        firstLevel.SetActive(true);
        secondLevel.SetActive(false);
        thirdLevel.SetActive(false);
        fourthLevel.SetActive(false);
        fifthLevel.SetActive(false);
        sixthLevel.SetActive(false);
        seventhLevel.SetActive(false);
        eighthLevel.SetActive(false);
        ninthLevel.SetActive(false);
        tenthLevel.SetActive(false);
        elevenLevel.SetActive(false);
        twelveLevel.SetActive(false);
        thirteenLevel.SetActive(false);
        fourteenLevel.SetActive(false);
        fifteenLevel.SetActive(false);


        //player card 1
        pcards1 = playerCard1.GetComponent<Cards>();
        //player card 2
        pcards2 = playerCard2.GetComponent<Cards>();
        //dealer card 1
        dcards1 = dealerCard1.GetComponent<Cards>();
        //dealer card 2
        dcards2 = dealerCard2.GetComponent<Cards>();




    }

    void Update()
    {
        //shows the coins up at the top
        coinCount = PlayerPrefs.GetInt("Coins");
        countText.text = coinCount.ToString();


    }
    void Start()
    {

        int soundEffect = PlayerPrefs.GetInt("Sound");
        if (soundEffect == 1)
        {
            // plays the card deal sound effect
            cardDeal.Play();
        }

        blackJackCheatSheet blackJackCheatSheet = randomObject.AddComponent<blackJackCheatSheet>();




        //finds the skin stored in player preference and uses it to set the cardback
        skin = PlayerPrefs.GetString("Skin");

        List<CardObject> deckList = CreateDeck.createDeck();


        //player card 1
        card1 = presetCardOne(0);
        pcards1.cardIndex = card1;
        pcards1.showFace();


        //player card 2
        card2 = presetCardTwo(1);
        pcards2.cardIndex = card2;
        pcards2.showFace();


        //dealer card 1
        card3 = presetCardThree(2);
        dcards1.cardIndex = card3;
        dcards1.showFace();


        //dealer card 2
        card4 = presetCardFour(3);
        dcards2.cardIndex = card4;
        dcards2.showBack(skin);



        //this will show the card totals on the UI
        SetPlayerCountText(deckList[card1], deckList[card2]);
        SetDealerCountText(deckList[card3]);

        //determines if the user should hit, stand, double or split
        returned = blackJackCheatSheet.blackJackCheatSheetMethod(deckList[card1], deckList[card2], deckList[card3]);

        //getting the faces of the cards so it can show up in the modal feedback box
        card1Face = deckList[card1].face;
        card2Face = deckList[card2].face;
        card3Face = deckList[card3].face;


    }


    // changes the total under the cards in the UI
    void SetPlayerCountText(CardObject firstCard, CardObject secondCard)
    {
        int total = firstCard.value + secondCard.value;
        //If there is an ace, we have to change the 1 to 11.
        if (firstCard.face == "Ace" || secondCard.face == "Ace")
        {
            total = total + 10;
        }

        playerValueTotal.text = "Player Count: " + total.ToString();

    }

    // changes the total under the cars in the UI
    void SetDealerCountText(CardObject firstCard)
    {
        int total = firstCard.value;
        if (firstCard.face == "Ace")
        {
            total = total + 10;
        }
        dealerValueTotal.text = "Dealer Count: " + total.ToString();
    }





    void printFeedback(int feedbackInt)
    {
        if (feedbackInt == 1)
        {
            feedBackText.text = "You should hit";


        }
        else if (feedbackInt == 2)
        {
            feedBackText.text = "You should stay";

        }
        else if (feedbackInt == 3)
        {
            feedBackText.text = "You should double";

        }
        else if (feedbackInt == 4)
        {
            feedBackText.text = "You should split";
        }
        else
        {
            feedBackText.text = "***Something went wrong***";
        }
    }

    // gets called when the button is pressed in UI
    void hit()
    {


        playersMove.text = "You hit!";
    

        correctAnswerNumber = 1;
        checkAnswer(correctAnswerNumber, returned, card1, card2, card3);
        updateCards(50, 46, 28, 5);

        fourthLevel.SetActive(false);
        fifthLevel.SetActive(true);

    }

    void stand()
    {

        playersMove.text = "You stayed!";
       
        correctAnswerNumber = 2;
        checkAnswer(correctAnswerNumber, returned, card1, card2, card3);
        updateCards(34, 6, 14, 25);

        seventhLevel.SetActive(false);
        eighthLevel.SetActive(true);

    }

    void double_()
    {
        playersMove.text = "You doubled!";
      
        correctAnswerNumber = 3;
        checkAnswer(correctAnswerNumber, returned, card1, card2, card3);

        updateCards(30, 31, 33, 3);
        eighthLevel.SetActive(false);
        ninthLevel.SetActive(true);
    }

    void split()
    {
        playersMove.text = "You split!";
      
        correctAnswerNumber = 4;
        checkAnswer(correctAnswerNumber, returned, card1, card2, card3);

        updateCards(45, 3, 44, 3);
        ninthLevel.SetActive(false);
        tenthLevel.SetActive(true);
    }

    // if the user presses this button, a module feedback box will appear
    void help()
    {

        //if the '?' button has been pressed, a pop up will occur
        modalWindow.SetActive(true);




        if (returned == 1)
        {
            modalFeedbackHelp.text = "If you have '" + card2Face + ", " + card1Face + "' and the dealer has '" + card3Face + "', you should hit";


        }
        else if (returned == 2)
        {
            modalFeedbackHelp.text = "If you have '" + card2Face + ", " + card1Face + "' and the dealer has '" + card3Face + "', you should stay";

        }
        else if (returned == 3)
        {
            modalFeedbackHelp.text = "If you have '" + card2Face + ", " + card1Face + "' and the dealer has '" + card3Face + "', you should double";

        }
        else if (returned == 4)
        {
            modalFeedbackHelp.text = "If you have '" + card2Face + ", " + card1Face + "' and the dealer has '" + card3Face + "', you should split";
        }
        else
        {
            modalFeedbackHelp.text = "***Something went wrong***";
        }

        // hitting this button will reset the streak counter
        streakCount = 0;
        setStreakCount();

        tenthLevel.SetActive(false);
        elevenLevel.SetActive(true);

    }


    // this method checks if the answer is correct.
    // first parameter takes in the button that the user pressed.
    // second parameter is the value that comes from 'returned'
    // which is from the array of answers.
    void checkAnswer(int x, int y, int card1, int card2, int card3)
    {
        if (x == y)
        {
            correctOrIncorrect.text = "Correct!";
            confirmationCardSwitch.changeCorrect();
            printFeedback(returned);

            //increasing the coin count
            coinCount++;
            setCoinCount();
            streakCount++;
            setStreakCount();

            //increment correct int, and send it to method to update on screen
            correct++;
            PlayerPrefs.SetInt("totalCorrect", PlayerPrefs.GetInt("totalCorrect") + 1);
            percentageCorrect(correct, incorrect);

            PlayerPrefs.SetInt("temp_correct", correct);

        }
        else
        {
            correctOrIncorrect.text = "Incorrect!";
            confirmationCardSwitch.changeIncorrect();
            printFeedback(returned);

            streakCount = 0;
            setStreakCount();

            //increment incorrect int, and send it to method to update on screen
            incorrect++;
            PlayerPrefs.SetInt("totalIncorrect", PlayerPrefs.GetInt("totalIncorrect") + 1);
            percentageCorrect(correct, incorrect);

            PlayerPrefs.SetInt("temp_incorrect", incorrect);
        }

        //TODO: pass in 3 ints, card1 etc. to show the user what hand they just played in the feedback box
        fpcards1 = feedbackplayerCard1.GetComponent<Cards>();
        fpcards2 = feedbackplayerCard2.GetComponent<Cards>();
        fdcards1 = feedbackdealerCard1.GetComponent<Cards>();

        fpcards1.cardIndex = card1;
        fpcards1.showFace();

        fpcards2.cardIndex = card2;
        fpcards2.showFace();

        fdcards1.cardIndex = card3;
        fdcards1.showFace();
    }

    // prints out the amount of coins the user has
    void setCoinCount()
    {
        countText.text = coinCount.ToString();
        // Write into PlayerPreference to save the amount so when the user closes the game
        // and reopens it, the coins will be saved.
        PlayerPrefs.SetInt("Coins", coinCount);
    }

    void setStreakCount()
    {
        streakCountText.text = "Streak Counter: " + streakCount.ToString();


        //saves the highest streak count in the variable highestStreakCount

        if (streakCount > highestStreakCount)
        {
            highestStreakCount = streakCount;

            PlayerPrefs.SetInt("temp_higheststreakcount", highestStreakCount);
        }

        // this will keep track of user's overall highest streak - saved in playerprefs
        if (streakCount > PlayerPrefs.GetInt("StreakCount"))
        {
            PlayerPrefs.SetInt("StreakCount", streakCount);
        }



    }

    public void percentageCorrect(int correct, int incorrect)
    {

        int total = correct + incorrect;
        decimal percent = (correct / (decimal)total) * 100;

        decimal percentageRounded = decimal.Round(percent, 1, MidpointRounding.AwayFromZero);

        percentageText.text = "Percent:" + correct + "/" + total + "          " + percentageRounded + "%";
     


    }

    // if this button is pressed, it will close the modal
    public void closeModal()
    {
        modalWindow.SetActive(false);
        elevenLevel.SetActive(false);
        twelveLevel.SetActive(true);

    }

    public void secondTutorial()
    {

        firstLevel.SetActive(false);
        secondLevel.SetActive(true);
        updateCards(50, 6, 28, 25);


    }
    public void thirdTutorial()
    {
        secondLevel.SetActive(false);
        thirdLevel.SetActive(true);


    }
    public void fourthTutorial()
    {
        thirdLevel.SetActive(false);
        fourthLevel.SetActive(true);

    }


    public void sixthTutorial()
    {
        fifthLevel.SetActive(false);
        sixthLevel.SetActive(true);
    }

    public void seventhTutorial()
    {
        sixthLevel.SetActive(false);
        seventhLevel.SetActive(true);
    }

  
    public void thirteenTutorial()
    {

        twelveLevel.SetActive(false);
        thirteenLevel.SetActive(true);
    }

  
    public void openBuyCoins()
    {
        buyCoinsModal.SetActive(true);
        thirteenLevel.SetActive(false);
        fourteenLevel.SetActive(true);
    }
    public void closeBuyCoins()
    {
        fourteenLevel.SetActive(false);
        fifteenLevel.SetActive(true);
        buyCoinsModal.SetActive(false);
    }


    public int presetCardOne(int number)
    {
        return number;
    }

    public int presetCardTwo(int number)
    {
        return number;
    }
    public int presetCardThree(int number)
    {
        return number;
    }

    public int presetCardFour(int number)
    {
        return number;
    }

    public void updateCards(int first, int second, int third, int forth)
    {

        blackJackCheatSheet blackJackCheatSheet = randomObject.AddComponent<blackJackCheatSheet>();




        //finds the skin stored in player preference and uses it to set the cardback
        skin = PlayerPrefs.GetString("Skin");

        List<CardObject> deckList = CreateDeck.createDeck();

        //player card 1
        card1 = first;
        pcards1.cardIndex = card1;
        pcards1.showFace();


        //player card 2
        card2 = second;
        pcards2.cardIndex = card2;
        pcards2.showFace();


        //dealer card 1
        card3 = third;
        dcards1.cardIndex = card3;
        dcards1.showFace();


        //dealer card 2
        card4 = forth;
        dcards2.cardIndex = card4;
        dcards2.showBack(skin);



        //this will show the card totals on the UI
        SetPlayerCountText(deckList[card1], deckList[card2]);
        SetDealerCountText(deckList[card3]);

        //determines if the user should hit, stand, double or split
        returned = blackJackCheatSheet.blackJackCheatSheetMethod(deckList[card1], deckList[card2], deckList[card3]);

        //getting the faces of the cards so it can show up in the modal feedback box
        card1Face = deckList[card1].face;
        card2Face = deckList[card2].face;
        card3Face = deckList[card3].face;

    }
}

