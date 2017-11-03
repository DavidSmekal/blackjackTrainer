using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class inappPurchase : MonoBehaviour {

    public GameObject buyCoinsModal;
    private int coinCount;

    public void Awake()
    {
        buyCoinsModal.SetActive(false);
    }

    public void openBuyCoins()
    {
        buyCoinsModal.SetActive(true);
    }

    public void closeBuyCoins()
    {
        buyCoinsModal.SetActive(false);
    }

    // user watches an ad when they press the button
    public void watchAd()
    {
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;

        Advertisement.Show("rewardedVideo", options);
    }

    // handles the results after user watched an add
    void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            coinCount = PlayerPrefs.GetInt("Coins");
            coinCount = coinCount + 1000;
            PlayerPrefs.SetInt("Coins", coinCount);

        }

    }
}
