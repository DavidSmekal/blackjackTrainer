using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class settingsPage : MonoBehaviour
{

    public GameObject leftButton;
    public GameObject rightButton;

    public Text checkMarkConfirmation;
    public Text checkMarkConfirmationMusic;
    public Text checkMarkConfirmationSound;

    public GameObject creditsButton;
    public GameObject closeModal;

    public GameObject modalWindow;
    public GameObject modalWindow2;
    public GameObject modalWindow3;

    public GameObject modalLeaderboard;
    public GameObject modalchangeUserName;

    public InputField nameInputField;
    public InputField emailInputField;
    public InputField feedbackInputField;

    public Text feedbackThanks;

    public List<string> usernameArray;
    public List<string> scoreArray;
    public string[] databaseArray;

    // will hold the leaderboard text blocks
    public Text rankTextBlock;
    public Text usernameTextBlock;
    public Text scoreTextBlock;

    // will show the user their old username found in playerprefs
    public Text oldUsername;

    //will store the new username input
    public InputField newUsername;


    public void Start()
    {
        // this makes it so I can fade the checkmark multiple times
        checkMarkConfirmation.canvasRenderer.SetAlpha(0f);
        checkMarkConfirmationSound.canvasRenderer.SetAlpha(0f);
        checkMarkConfirmationMusic.canvasRenderer.SetAlpha(0f);

        // this hides the modal pop up
        modalWindow.SetActive(false);
        modalWindow2.SetActive(false);
        modalWindow3.SetActive(false);
        modalLeaderboard.SetActive(false);
        modalchangeUserName.SetActive(false);



    }

    //this upload method sends feedback to my php script in my server
    //the server then emails it to my email
    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameInputField.text);
        form.AddField("email", emailInputField.text);
        form.AddField("input", feedbackInputField.text);



        UnityWebRequest www = UnityWebRequest.Post("http://107.170.227.172/form.php", form);
        yield return www.Send();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            feedbackThanks.text = www.error;
        }
        else
        {
            Debug.Log("Form upload complete!");
            feedbackThanks.text = "Thank you for sending feedback!";

        }
    }

    // action to do when pressing left button
    public void pressLeftButton()
    {
        PlayerPrefs.SetInt("Position", 1);

        // this makes it so I can fade the checkmark multiple times
        checkMarkConfirmation.canvasRenderer.SetAlpha(1f);

        // this makes the checkmark fade
        checkMarkConfirmation.CrossFadeAlpha(0.0f, 1.0f, true);


    }

    // acting to do when pressing right button
    public void pressRightButton()
    {
        PlayerPrefs.SetInt("Position", 0);

        // this makes it so I can fade the checkmark multiple times
        checkMarkConfirmation.canvasRenderer.SetAlpha(1f);

        // this makes the checkmark fade
        checkMarkConfirmation.CrossFadeAlpha(0.0f, 1.0f, false);
    }


    // turn sound effects on
    // 1 == sound on. 0 = sound off
        public void soundOn()
    {
        PlayerPrefs.SetInt("Sound", 1);

        // this makes it so I can fade the checkmark multiple times
        checkMarkConfirmationSound.canvasRenderer.SetAlpha(1f);

        // this makes the checkmark fade
        checkMarkConfirmationSound.CrossFadeAlpha(0.0f, 1.0f, false);
    }

    // turn sound effects off

    public void soundOff()
    {
        PlayerPrefs.SetInt("Sound", 0);

        // this makes it so I can fade the checkmark multiple times
        checkMarkConfirmationSound.canvasRenderer.SetAlpha(1f);

        // this makes the checkmark fade
        checkMarkConfirmationSound.CrossFadeAlpha(0.0f, 1.0f, false);
    }

    // turn music on
    // 1 = music on. 0 = music off
    public void musicOn()
    {
        PlayerPrefs.SetInt("Music", 1);

        // this makes it so I can fade the checkmark multiple times
        checkMarkConfirmationMusic.canvasRenderer.SetAlpha(1f);

        // this makes the checkmark fade
        checkMarkConfirmationMusic.CrossFadeAlpha(0.0f, 1.0f, false);
    }

    // turn music off

    public void musicOff()
    {
        PlayerPrefs.SetInt("Music", 0);

        // this makes it so I can fade the checkmark multiple times
        checkMarkConfirmationMusic.canvasRenderer.SetAlpha(1f);

        // this makes the checkmark fade
        checkMarkConfirmationMusic.CrossFadeAlpha(0.0f, 1.0f, false);
    }

    public void viewCreditPage()
    {
        // this shows the modal pop up
        modalWindow.SetActive(true);
    }

    public void closeCreditPage()
    {
        modalWindow.SetActive(false);
    }

    public void viewAlignmentModal()
    {
        modalWindow2.SetActive(true);
    }

    public void closeAlignmentModal()
    {
        modalWindow2.SetActive(false);
    }

    // the button to send the feedback to my email
    public void sendText()
    {
        StartCoroutine(Upload());
    }

    public void openFeedbackModal()
    {
        modalWindow3.SetActive(true);
    }

    public void closeFeedbackModal()
    {
        modalWindow3.SetActive(false);
    }


    public void deleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

    // this is a temporary field to give me lots of coins

    public void giveCoins()
    {
        PlayerPrefs.SetInt("Coins", 100000);

    }

    public void opendatabaseModal()
    {
        modalLeaderboard.SetActive(true);
        StartCoroutine(viewDatabase());
    }

    public void closeDatabaseModal()
    {
        // this block clears the text because if I didn't and the user were to click on the modal again
        // it would keep adding onto the previous information
        rankTextBlock.text = " ";
        usernameTextBlock.text = " ";
        scoreTextBlock.text = " ";
        usernameArray.Clear();
        scoreArray.Clear();
        StopCoroutine(viewDatabase());
        modalLeaderboard.SetActive(false);

 
}

    IEnumerator viewDatabase()
    {
        // pulls data from the link. The link has a string echo'd which contains the database values
        WWW data = new WWW("http://107.170.227.172/view_scores.php");
        yield return data;

        string dataString = data.text;

        databaseArray = dataString.Split(';');

        string[] placeholder;

        // databaseArray is in format 423|davio. this for loop will split them
        // it will store the first half into scoreArray, and the second half into usernameArray
       
        for (int i = 0; i < databaseArray.Length - 1; i++)
        {
            string haha = databaseArray[i];
          

            placeholder = haha.Split('|');


            scoreArray.Add(placeholder[0]);
            usernameArray.Add(placeholder[1]);



        }

        // this prints out the score, username, and their rank
        for (int i = 0; i < scoreArray.Count; i++)
        {

            rankTextBlock.text += (i + 1) + "\n";
            usernameTextBlock.text += usernameArray[i] + "\n";
            scoreTextBlock.text += scoreArray[i] + "\n";

        }

    }

    // change username modal

    public void changeUserName()
    {
        modalchangeUserName.SetActive(true);

        oldUsername.text = "Old username: " + PlayerPrefs.GetString("Username");
    }


    public void closechangeUserNameModal()
    {


        if (newUsername.text.Length > 2)
        {
            //updates the playerpref's username
            PlayerPrefs.SetString("Username", newUsername.text);

            StartCoroutine(Upload2());

            // this clears the text if the user were to open up the modal again
            newUsername.text = " ";


            modalchangeUserName.SetActive(false);
        }
       




    }

    IEnumerator Upload2()
    {
        WWWForm form = new WWWForm();

        // gets the users unique deviceId
        String uniqueSystemIde = SystemInfo.deviceUniqueIdentifier;


        // sends the new username that was typed it, and the systemId
        form.AddField("username", newUsername.text);
        form.AddField("deviceId", uniqueSystemIde);

        



        UnityWebRequest www = UnityWebRequest.Post("http://107.170.227.172/change_username.php", form);
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
