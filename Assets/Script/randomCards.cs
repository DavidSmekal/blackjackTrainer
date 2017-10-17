using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System;

public class randomCards : MonoBehaviour
{
    public class CardObject
    {
        public int value { get; set; }
        public string face { get; set; }

    }

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

    //left and right gameObjects
    public GameObject leftSide;
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



    //an array for the deck of cards
    int[] cardArray = new int[51];

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

        //player card 1
        pcards1 = playerCard1.GetComponent<Cards>();
        //player card 2
        pcards2 = playerCard2.GetComponent<Cards>();
        //dealer card 1
        dcards1 = dealerCard1.GetComponent<Cards>();
        //dealer card 2
        dcards2 = dealerCard2.GetComponent<Cards>();

        //shows the coins up at the top
        coinCount = PlayerPrefs.GetInt("Coins");
        countText.text = coinCount.ToString();




    }
    void Start()
    {

        //this will look in the player preference to find the user's position of UI
        int position = PlayerPrefs.GetInt("Position");
        if (position == 0)
        {
            leftSide.SetActive(false);
            rightSide.SetActive(true);
        }
        else if (position == 1)
        {

            leftSide.SetActive(true);
            rightSide.SetActive(false);
        }



        //finds the skin stored in player preference and uses it to set the cardback
        skin = PlayerPrefs.GetString("Skin");

        // type. 1 = total. 2 = contains ace. 3 = pair.
        List<CardObject> haha = new List<CardObject>
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



        //populating the deck array
        for (int i = 0; i < 51; i++)
        {
            cardArray[i] = i;

        }

        //passing the cardArray to the shuffle method to get a shuffled array
        int[] shuffledArray = shuffleArray(cardArray);


        //player card 1
        card1 = shuffledArray[0];
        pcards1.cardIndex = card1;
        pcards1.showFace();


        //player card 2
        card2 = shuffledArray[2];
        pcards2.cardIndex = card2;
        pcards2.showFace();


        //dealer card 1
        card3 = shuffledArray[1];
        dcards1.cardIndex = card3;
        dcards1.showFace();


        //dealer card 2
        card4 = shuffledArray[3];
        dcards2.cardIndex = card4;
        dcards2.showBack(skin);



        //this will show the card totals on the UI
        SetPlayerCountText(haha[card1], haha[card2]);
        SetDealerCountText(haha[card3]);

        //determines if the user should hit, stand, double or split
        returned = blackJackCheatSheet(haha[card1], haha[card2], haha[card3]);

        //getting the faces of the cards so it can show up in the modal feedback box
        card1Face = haha[card1].face;
        card2Face = haha[card2].face;
        card3Face = haha[card3].face;


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


    //returns 1 if hit. 2 if stand. 3 if double. 4 if split. 9 for unknown for now
    public int blackJackCheatSheet(CardObject firstPlayerCard, CardObject secondPlayerCard, CardObject firstDealerCard)
    {

        int returnValue = 0;

        var cheatSheet = new int[27, 10]
        {
               //   A  2  3  4  5  6  7  8  9  10
         /*8*/     {1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
         /*9*/     {1, 1, 3, 3, 3, 3, 1, 1, 1, 1},  
         /*10*/    {1, 3, 3, 3, 3, 3, 3, 3, 3, 1},  
         /*11*/    {3, 3, 3, 3, 3, 3, 3, 3, 3, 3}, 
         /*12*/    {1, 1, 1, 2, 2, 2, 1, 1, 1, 1}, 
         /*13*/    {1, 2, 2, 2, 2, 2, 1, 1, 1, 1},  
         /*14*/    {1, 2, 2, 2, 2, 2, 1, 1, 1, 1},  
         /*15*/    {1, 2, 2, 2, 2, 2, 1, 1, 1, 1},  
         /*16*/    {1, 2, 2, 2, 2, 2, 1, 1, 1, 1}, 
         /*17*/    {2, 2, 2, 2, 2, 2, 2, 2, 2, 2}, 
         /*A,2*/   {1, 1, 1, 1, 3, 3, 1, 1, 1, 1},
         /*A,3*/   {1, 1, 1, 1, 3, 3, 1, 1, 1, 1},  
         /*A,4*/   {1, 1, 1, 3, 3, 3, 1, 1, 1, 1},  
         /*A,5*/   {1, 1, 1, 3, 3, 3, 1, 1, 1, 1}, 
         /*A,6*/   {1, 1, 3, 3, 3, 3, 1, 1, 1, 1}, 
         /*A,7*/   {1, 2, 3, 3, 3, 3, 2, 2, 1, 1}, 
         /*A,8*/   {2, 2, 2, 2, 2, 2, 2, 2, 2, 2}, 
         /*2,2*/   {1, 4, 4, 4, 4, 4, 4, 1, 1, 1}, 
         /*3,3*/   {1, 4, 4, 4, 4, 4, 4, 1, 1, 1}, 
         /*4,4*/   {1, 1, 1, 1, 4, 4, 1, 1, 1, 1}, 
         /*5,5*/   {1, 3, 3, 3, 3, 3, 3, 3, 3, 1},  
         /*6,6*/   {1, 4, 4, 4, 4, 4, 1, 1, 1, 1}, 
         /*7,7*/   {1, 4, 4, 4, 4, 4, 4, 1, 1, 1}, 
         /*8,8*/   {4, 4, 4, 4, 4, 4, 4, 4, 4, 4}, 
         /*9,9*/   {2, 4, 4, 4, 4, 4, 2, 4, 4, 2}, 
         /*10,10*/ {2, 2, 2, 2, 2, 2, 2, 2, 2, 2}, 
         /*A,A*/   {4, 4, 4, 4, 4, 4, 4, 4, 4, 4},

        };

        // I added -1 to firstDealerCard.value to make the index and the number align.

        // if there is a pair of aces, do this if statement
        if (firstPlayerCard.face == "Ace" && secondPlayerCard.face == "Ace")
        {
            returnValue = 4;
        }
        // if there is an Ace in one hand, do this if statement.
        else if (firstPlayerCard.face == "Ace" || secondPlayerCard.face == "Ace")
        {
            int firstPlayerCardValue = firstPlayerCard.value;
            int secondPlayerCardValue = secondPlayerCard.value;


            if (firstPlayerCardValue == 1 || secondPlayerCardValue == 1)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[9, i];
                    }

                }
            }
            if (firstPlayerCardValue == 2 || secondPlayerCardValue == 2)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[10, i];
                    }

                }
            }
            else if (firstPlayerCardValue == 3 || secondPlayerCardValue == 3)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[11, i];
                    }

                }
            }
            else if (firstPlayerCardValue == 4 || secondPlayerCardValue == 4)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[12, i];
                    }

                }
            }
            else if (firstPlayerCardValue == 5 || secondPlayerCardValue == 5)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[13, i];
                    }

                }
            }
            else if (firstPlayerCardValue == 6 || secondPlayerCardValue == 6)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[14, i];
                    }

                }
            }
            else if (firstPlayerCardValue == 7 || secondPlayerCardValue == 7)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[15, i];
                    }

                }
            }
            else if (firstPlayerCardValue == 8 || secondPlayerCardValue == 8)
            {

                returnValue = 2;
            }
            else if (firstPlayerCardValue == 9 || secondPlayerCardValue == 9)
            {
                returnValue = 2;
            }
            else if (firstPlayerCardValue == 10 || secondPlayerCardValue == 10)
            {
                returnValue = 2;
            }


        }
        // if there is a pair, do this if statement
        else if (firstPlayerCard.value == secondPlayerCard.value)
        {
            int firstPlayerCardValue = firstPlayerCard.value;

            if (firstPlayerCardValue == 2)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[17, i];
                    }

                }

            }

            else if (firstPlayerCardValue == 3)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[18, i];
                    }

                }

            }
            else if (firstPlayerCardValue == 4)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[19, i];
                    }

                }

            }
            else if (firstPlayerCardValue == 5)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[20, i];
                    }

                }

            }
            else if (firstPlayerCardValue == 6)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[21, i];
                    }

                }

            }
            else if (firstPlayerCardValue == 7)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[22, i];
                    }

                }

            }
            else if (firstPlayerCardValue == 8)
            {

                returnValue = 4;

            }
            else if (firstPlayerCardValue == 9)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[24, i];
                    }

                }

            }
            else if (firstPlayerCardValue == 10)
            {

                returnValue = 2;

            }

        }

        // else, if it's just a total of everything, do this statement
        else
        {

            int totalValue = firstPlayerCard.value + secondPlayerCard.value;

            if ((totalValue == 4) || (totalValue == 5) || (totalValue == 6) || (totalValue == 7))
            {
                returnValue = 1;
            }

            else if (totalValue == 8)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[0, i];
                    }

                }

            }
            else if (totalValue == 9)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[1, i];
                    }

                }
            }
            else if (totalValue == 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[2, i];
                    }

                }
            }
            else if (totalValue == 11)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[3, i];
                    }

                }
            }
            else if (totalValue == 12)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[4, i];
                    }

                }
            }
            else if (totalValue == 13)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[5, i];
                    }

                }
            }
            else if (totalValue == 14)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[6, i];
                    }

                }
            }
            else if (totalValue == 15)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[7, i];
                    }

                }
            }
            else if (totalValue == 16)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[8, i];
                    }

                }
            }
            else if (totalValue == 17)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[9, i];
                    }

                }
            }
            //this isn't in the matrix above.
            else if ((totalValue == 18) || (totalValue == 19) || (totalValue == 20) || (totalValue == 21))
            {
                returnValue = 2;
            }

        }


        return returnValue;


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
        Start();

    }

    void stand()
    {

        playersMove.text = "You stayed!";
        correctAnswerNumber = 2;
        checkAnswer(correctAnswerNumber, returned, card1, card2, card3);
        Start();

    }

    void double_()
    {
        playersMove.text = "You doubled!";
        correctAnswerNumber = 3;
        checkAnswer(correctAnswerNumber, returned, card1, card2, card3);

        Start();
    }

    void split()
    {
        playersMove.text = "You split!";
        correctAnswerNumber = 4;
        checkAnswer(correctAnswerNumber, returned, card1, card2, card3);

        Start();
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
            percentageCorrect(correct, incorrect);


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
            percentageCorrect(correct, incorrect);
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
    }

    public void percentageCorrect(int correct, int incorrect)
    {

        int total = correct + incorrect;
        decimal percent = (correct / (decimal)total) * 100;

        decimal percentageRounded = decimal.Round(percent, 1, MidpointRounding.AwayFromZero);

        percentageText.text = "Percentage:" + correct + "/" + total + "          " + percentageRounded + "%";


    }

    // if this button is pressed, it will close the modal
    public void closeModal()
    {
        modalWindow.SetActive(false);

    }
}
