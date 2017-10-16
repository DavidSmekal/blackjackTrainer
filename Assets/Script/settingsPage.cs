using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class settingsPage : MonoBehaviour {

    public GameObject leftButton;
    public GameObject rightButton;

    public Text checkMarkConfirmation;

    public GameObject creditsButton;
    public GameObject closeModal;

    public GameObject modalWindow;

    public GameObject modalWindow2;




    public void Start()
    {
        // this makes it so I can fade the checkmark multiple times
        checkMarkConfirmation.canvasRenderer.SetAlpha(0f);

        // this hides the modal pop up
        modalWindow.SetActive(false);
        modalWindow2.SetActive(false);

        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("content", "myData");
        form.AddField("index", "myData");

        
        UnityWebRequest www = UnityWebRequest.Post("http://107.170.227.172/form.php", form);
        yield return www;

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
           
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
