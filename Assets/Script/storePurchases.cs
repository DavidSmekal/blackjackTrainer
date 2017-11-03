using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class storePurchases : MonoBehaviour
{

    //retrieving the coins stored in memory
    private int coinCount = 0;

    //count count text box
    public Text countText;

    //boolean to unlock items
    private bool itemLocked;

    //"character array" of unlocked items
    public string unlockedItems;

    //highlight purchase button to show it's purchased. change the colour
    public Sprite purchased;

    //this will hold the modal window
    public GameObject modalWindow;

    // this will change the text to show the user which deck they clicked on
    public Text changedDeck;


    SpriteRenderer spriteRenderer;

    Cards cards;


    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject closeModuleButton;
    public GameObject purchaseButton1;
    public GameObject purchaseButton2;
    public GameObject purchaseButton3;
    public GameObject purchaseButton4;
    public GameObject purchaseButton5;



    //playerpreference to store the user's deck choice
    private string deckChoice;

    void Start()
    {
        // this hides the modal pop up
        modalWindow.SetActive(false);

    }


    void Update()
    {

        //shows the total coins at the top of the screen
        coinCount = PlayerPrefs.GetInt("Coins");
        countText.text = coinCount.ToString();

        // if the user doesn't have enough coins, disable the 'enable' button
        if (coinCount < 1000)
        {
            purchaseButton1.GetComponent<Button>().interactable = false;
        }
        if (coinCount < 10000)
        {
            purchaseButton2.GetComponent<Button>().interactable = false;
        }
        if (coinCount < 30000)
        {
            purchaseButton3.GetComponent<Button>().interactable = false;
        }
        if (coinCount < 50000)
        {
            purchaseButton4.GetComponent<Button>().interactable = false;
        }
        if (coinCount < 100000)
        {
            purchaseButton5.GetComponent<Button>().interactable = false;
        }


        //get the saved string to get the purchased items
        string savedString = PlayerPrefs.GetString("Unlocked_items");

        // if the item has been purchased, disable the button
        if (savedString.Contains("1"))
        {
            button2.GetComponent<Button>().interactable = true;
            purchaseButton1.GetComponent<Button>().interactable = false;
        }
        if (savedString.Contains("2"))
        {
            button3.GetComponent<Button>().interactable = true;
            purchaseButton2.GetComponent<Button>().interactable = false;
        }
        if (savedString.Contains("3"))
        {
            button4.GetComponent<Button>().interactable = true;
            purchaseButton3.GetComponent<Button>().interactable = false;
        }
        if (savedString.Contains("4"))
        {
            button5.GetComponent<Button>().interactable = true;
            purchaseButton4.GetComponent<Button>().interactable = false;
        }
        if (savedString.Contains("5"))
        {
            button6.GetComponent<Button>().interactable = true;
            purchaseButton5.GetComponent<Button>().interactable = false;
        }



        // enable and disable the "enable" button

        if (!(savedString.Contains("1")))
        {
            button2.GetComponent<Button>().interactable = false;
        }
        if (!(savedString.Contains("2")))
        {
            button3.GetComponent<Button>().interactable = false;
        }
        if (!(savedString.Contains("3")))
        {
            button4.GetComponent<Button>().interactable = false;
        }
        if (!(savedString.Contains("4")))
        {
            button5.GetComponent<Button>().interactable = false;
        }
        if (!(savedString.Contains("5")))
        {
            button6.GetComponent<Button>().interactable = false;
        }
    }

    public void purchaseItem(string itemNumber)
    {
        // the int will decide which items are unlocked. example. 12  items 1 and 2 will be unlocked. dirty method.
        string x = itemNumber;



        string savedString = PlayerPrefs.GetString("Unlocked_items");

        // if the string doesn't contain the item number, then we can purchase the item.
        if (!(savedString.Contains(x)))
        {

            savedString = savedString.Insert(savedString.Length, x);

            PlayerPrefs.SetString("Unlocked_items", savedString);
        }

        //these if statements will purchase the products
        // it will subtract the amount and save the new amount in player preferences
        if (x == "1")
        {

            PlayerPrefs.SetInt("Coins", (PlayerPrefs.GetInt("Coins") - 1000));       
            // this sends to the database the item string and the cost of the item
            StartCoroutine(Upload("green", 1000));

        }
        if (x == "2")
        {
            PlayerPrefs.SetInt("Coins", (PlayerPrefs.GetInt("Coins") - 10000));
            // this sends to the database the item string and the cost of the item        
            StartCoroutine(Upload("blue", 10000));

        }
        if (x == "3")
        {
            PlayerPrefs.SetInt("Coins", (PlayerPrefs.GetInt("Coins") - 30000));
            // this sends to the database the item string and the cost of the item
            StartCoroutine(Upload("brick", 30000));
        }
        if (x == "4")
        {
            PlayerPrefs.SetInt("Coins", (PlayerPrefs.GetInt("Coins") - 50000));
            // this sends to the database the item string and the cost of the item
            StartCoroutine(Upload("grass", 50000));
        }
        if (x == "5")
        {
            PlayerPrefs.SetInt("Coins", (PlayerPrefs.GetInt("Coins") - 100000));
            // this sends to the database the item string and the cost of the item
            StartCoroutine(Upload("sky", 100000));
        }


    }


    //this method will switch the sprite to the new sprite
    public void switchSprite(string x)
    {
        //save string choice in playerpreference
        PlayerPrefs.SetString("Skin", x);

        //if the 'enable' button has been pressed, a pop up will occur
        modalWindow.SetActive(true);

        changedDeck.text = "You have changed the deck to: " + x + "!";



    }

    // if this button is pressed, it will close the modal
    public void closeModal()
    {
        modalWindow.SetActive(false);

    }

    // this function uploads to the database the item that was purchased
    IEnumerator Upload(string item_purchased, int cost)
    {

        String uniqueSystemIde = SystemInfo.deviceUniqueIdentifier;

        WWWForm form = new WWWForm();

        // if the user doesn't exist, it will be uploaded anyway and it will be blank in the database
        // The deviceId will still be attached so a username isn't needed

        form.AddField("username", PlayerPrefs.GetString("Username"));
        form.AddField("deviceId", uniqueSystemIde);
        form.AddField("purchaseString", item_purchased);
        form.AddField("cost", cost);

       

        UnityWebRequest www = UnityWebRequest.Post("http://107.170.227.172/store_purchases.php", form);
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
