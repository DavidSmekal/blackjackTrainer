using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Networking;
using TwitterKit.Unity;

public class randomCardsTimed : MonoBehaviour
{
    public class CardObject
    {
        public int value { get; set; }
        public string face { get; set; }

    }

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
    public Text streakCountTextLeft;
    //this will keep track of the streak
    private int streakCount = 0;
    //this will keep track of the highest streak count
    private int highestStreakCount = 0;

    //changes a number in the button methods to see if the user is right
    public int correctAnswerNumber;


    // play card audio
    public AudioSource cardDeal;


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
    public Text playersMoveLeft;


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
    public Text percentageTextLeft;

    // this stuff below will all be stuff added to this new gamemode (so I don't get confused if I have to change something later)
    ///////////////////////////////////////////////////////////////
    // 60 second timer
    private float timeLeft = 60f;
    // text to store the timer in the user interface
    public Text timer;
    //need to keep score. 
    private int timedScore = 0;
    // text to store the score in the user interface
    public Text score;
    // when game is over, show a gameover modal with the player's score
    public GameObject gameOverModal;
    // game over modal score and percentage 
    public Text gameOverScore;
    public Text gameOverPercentage;
    // boolean to stop the gameover method from calling over and over again.
    public bool updateBool = true;
    // modal to set username for leaderboards
    public GameObject setNameLeaderboards;
    //username text input
    public InputField usernameInput;



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
        gameOverModal.SetActive(false);

        //if username is set, it will hide username modal
        if (PlayerPrefs.GetString("Username").Length > 2)
        {
            setNameLeaderboards.SetActive(false);
        }
        else
        {
            setNameLeaderboards.SetActive(true);
        }

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

    void Update()
    {
        // if the user hasn't typed in a username yet, the timer will be paused
        if (setNameLeaderboards.activeInHierarchy == false)
        {
            // this decrements the timer
            timeLeft -= Time.deltaTime;
            int intTimeLeft = Mathf.RoundToInt(timeLeft);

            timer.text = intTimeLeft.ToString();

            if ((updateBool == true) && (timeLeft < 0))
            {

                // after destroy is called, it will cause an error to repeat in the console since I am
                // am still trying to access Text. I don't think this should impact gameplay, so I will
                // leave it be.
                Destroy(timer);
                GameOver();
                updateBool = false;

            }
        }

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
        returned = blackJackCheatSheet.blackJackCheatSheetMethodTimed(haha[card1], haha[card2], haha[card3]);

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





    void printFeedback(int feedbackInt)
    {
        if (feedbackInt == 1)
        {
            feedBackText.text = "You should hit";


        }
        else if (feedbackInt == 2)
        {
            feedBackText.text = "You should stand";

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
        playersMoveLeft.text = "You hit!";

        correctAnswerNumber = 1;
        checkAnswer(correctAnswerNumber, returned, card1, card2, card3);
        Start();

    }

    void stand()
    {

        playersMove.text = "You stayed!";
        playersMoveLeft.text = "You stayed!";
        correctAnswerNumber = 2;
        checkAnswer(correctAnswerNumber, returned, card1, card2, card3);
        Start();

    }

    void double_()
    {
        playersMove.text = "You doubled!";
        playersMoveLeft.text = "You doubled!";
        correctAnswerNumber = 3;
        checkAnswer(correctAnswerNumber, returned, card1, card2, card3);

        Start();
    }

    void split()
    {
        playersMove.text = "You split!";
        playersMoveLeft.text = "You split!";
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
            modalFeedbackHelp.text = "If you have '" + card2Face + ", " + card1Face + "' and the dealer has '" + card3Face + "', you should stand";

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

            String skin2 = PlayerPrefs.GetString("Skin");

            //increasing the coin count
            if (skin2 == "Brick")
            {
                coinCount += 2;
            }
            else if (skin2 == "Grass")
            {
                coinCount += 3;
            }
            else if (skin2 == "Sky")
            {
                coinCount += 4;
            }
            else
            {
                coinCount++;
            }


            setCoinCount();
            streakCount++;
            setStreakCount();

            //increment correct int, and send it to method to update on screen
            correct++;
            PlayerPrefs.SetInt("totalCorrect", PlayerPrefs.GetInt("totalCorrect") + 1);
            percentageCorrect(correct, incorrect);

            //this will increment the user's score
            timedScore++;
            setTimedScore();


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

            //this will decrement the user's score
            timedScore--;
            setTimedScore();
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
        streakCountTextLeft.text = "Streak Counter: " + streakCount.ToString();

        //saves the highest streak count in the variable highestStreakCount

        if (streakCount > highestStreakCount)
        {
            highestStreakCount = streakCount;
        }
        // this will keep track of user's overall highest streak - saved in playerprefs

        if (streakCount > PlayerPrefs.GetInt("StreakCount"))
        {
            PlayerPrefs.SetInt("StreakCount", streakCount);
        }
      
       

    }

    void setTimedScore()
    {
        score.text = timedScore.ToString();
    }

    public void percentageCorrect(int correct, int incorrect)
    {

        int total = correct + incorrect;
        decimal percent = (correct / (decimal)total) * 100;

        decimal percentageRounded = decimal.Round(percent, 1, MidpointRounding.AwayFromZero);

        percentageText.text = "Percent:" + correct + "/" + total + "          " + percentageRounded + "%";
        percentageTextLeft.text = "Percent:" + correct + "/" + total + "          " + percentageRounded + "%";


    }

    // if this button is pressed, it will close the modal
    public void closeModal()
    {
        modalWindow.SetActive(false);

    }

    public void GameOver()
    {
        gameOverModal.SetActive(true);

        int total = correct + incorrect;
        decimal percent = (correct / (decimal)total) * 100;

        decimal percentageRounded = decimal.Round(percent, 1, MidpointRounding.AwayFromZero);
        gameOverPercentage.text = "Percent Correct: " + correct + "/" + total + " = " + percentageRounded + "%";

        gameOverScore.text = "Score: " + timedScore;

        StartCoroutine(Upload2());


    }

    // this will create a new username
    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();

        // gets the users unique deviceId
        String uniqueSystemIde = SystemInfo.deviceUniqueIdentifier;


   
        form.AddField("username", PlayerPrefs.GetString("Username"));
        form.AddField("deviceId", uniqueSystemIde);

        PlayerPrefs.SetString("Username", usernameInput.text);



        UnityWebRequest www = UnityWebRequest.Post("http://107.170.227.172/insert_user.php", form);
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

    // this will update the user's score
    IEnumerator Upload2()
    {
        // gets the users unique deviceId
        String uniqueSystemIde = SystemInfo.deviceUniqueIdentifier;

        WWWForm form = new WWWForm();
  

        form.AddField("count", timedScore);
        form.AddField("correct", correct);
        form.AddField("incorrect", incorrect);
        form.AddField("highestStreak", highestStreakCount);
        form.AddField("username", PlayerPrefs.GetString("Username"));
        form.AddField("deviceId", uniqueSystemIde);


        UnityWebRequest www = UnityWebRequest.Post("http://107.170.227.172/insert_timedscore.php", form);
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

    public void PlayAgain()
    {
        SceneManager.LoadScene("Timed Challenge");
    }
    
    //this will close the set username modal. At the the same time, it will input the username into playerprefs.
    public void closeAndUpdateUsername()
    {


        PlayerPrefs.SetString("Username", usernameInput.text);

        if (PlayerPrefs.GetString("Username").Length > 2)
        {
            setNameLeaderboards.SetActive(false);
            StartCoroutine(Upload());
        }

        Debug.Log("From player prefs: " + PlayerPrefs.GetString("Username"));

        
    }

    public void StartComposer(TwitterSession session, String imageUri)
    {

        Twitter.Compose(session, imageUri, "I just received a score of " + timedScore.ToString() + " from learning how to play blackjack! Try it yourself! https://play.google.com/store/apps/details?id=com.DDeveloper.BlackJackTrainer", new string[] { "#BlackjackTrainer" },
              (string tweetId) => { UnityEngine.Debug.Log("Tweet Success, tweetId = " + tweetId); },
              (ApiError error) => { UnityEngine.Debug.Log("Tweet Failed " + error.message); },
              () => { Debug.Log("Compose cancelled"); }
      );


    }
    public void postToTwitter()
    {
        Twitter.Init();

        StartLogin();

    }
    public void StartLogin()
    {
        TwitterSession session = Twitter.Session;
        if (session == null)
        {
            Twitter.LogIn(LoginComplete, LoginFailure);
        }
        else
        {
            LoginComplete(session);
        }
    }

    public void LoginComplete(TwitterSession session)
    {
        // Start composer or request email

        StartComposer(session, "test");
    }

    public void LoginFailure(ApiError error)
    {
        UnityEngine.Debug.Log("code=" + error.code + " msg=" + error.message);
    }



}
