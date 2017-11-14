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
      //  ShowOptions options = new ShowOptions();
     //   options.resultCallback = HandleShowResult;

     //   Advertisement.Show("rewardedVideo", options);

        const string RewardedPlacementId = "rewardedVideo";

        #if UNITY_ADS
        if (!Advertisement.IsReady(RewardedPlacementId))
        {
            Debug.Log(string.Format("Ads not ready for placement '{0}'", RewardedPlacementId));
            return;
        }

        var options = new ShowOptions { resultCallback = HandleShowResult };
        Advertisement.Show(RewardedPlacementId, options);
        #endif
    }

    // handles the results after user watched an add
    void HandleShowResult(ShowResult result)
    {

        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                coinCount = PlayerPrefs.GetInt("Coins");
                coinCount = coinCount + 1000;
                PlayerPrefs.SetInt("Coins", coinCount);
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }

    }
}
