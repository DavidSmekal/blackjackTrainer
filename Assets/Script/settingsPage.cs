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

    public GameObject creditsButton;
    public GameObject closeModal;

    public GameObject modalWindow;
    public GameObject modalWindow2;
    public GameObject modalWindow3;

    public InputField nameInputField;
    public InputField emailInputField;
    public InputField feedbackInputField;

    public Text feedbackThanks;



    public void Start()
    {
        // this makes it so I can fade the checkmark multiple times
        checkMarkConfirmation.canvasRenderer.SetAlpha(0f);

        // this hides the modal pop up
        modalWindow.SetActive(false);
        modalWindow2.SetActive(false);
        modalWindow3.SetActive(false);



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
}
