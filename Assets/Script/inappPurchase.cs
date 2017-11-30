using UnityEngine;
using UnityEngine.Advertisements;
using System;
using UnityEngine.Purchasing;

public class inappPurchase : MonoBehaviour, IStoreListener
{



    private static IStoreController m_StoreController;          // The Unity Purchasing system.
    private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.


    // specific mapping to Unity Purchasing's AddProduct, below.
    public static string GOLD_50000 = "gold50000";
    public static string GOLD_100000 = "gold100000";

    public GameObject buyCoinsModal;
    private int coinCount;

    public GameObject dirtyBlockModalCoins;

    public void Awake()
    {
        buyCoinsModal.SetActive(false);
        dirtyBlockModalCoins.SetActive(false);

    }

    void Start()
    {
        // If we haven't set up the Unity Purchasing reference
        if (m_StoreController == null)
        {
            // Begin to configure our connection to Purchasing
            InitializePurchasing();
        }

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

        // need to pop up an empty text box to block the text
        dirtyBlockModalCoins.SetActive(true);

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

        dirtyBlockModalCoins.SetActive(false);
    }


    public void InitializePurchasing()
    {

        if (IsInitialized())
        {

            return;
        }


        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());


        builder.AddProduct(GOLD_50000, ProductType.Consumable);
        builder.AddProduct(GOLD_100000, ProductType.Consumable);


        UnityPurchasing.Initialize(this, builder);
    }


    private bool IsInitialized()
    {
        // Only say we are initialized if both the Purchasing references are set.
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }


    public void buy50000()
    {

        BuyProductID(GOLD_50000);
    }

    public void buy100000()
    {

        BuyProductID(GOLD_100000);
    }




    void BuyProductID(string productId)
    {
        // If Purchasing has been initialized ...
        if (IsInitialized())
        {
            // ... look up the Product reference with the general product identifier and the Purchasing 
            // system's products collection.
            Product product = m_StoreController.products.WithID(productId);

            // If the look up found a product for this device's store and that product is ready to be sold ... 
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
                // asynchronously.
                m_StoreController.InitiatePurchase(product);
            }
            // Otherwise ...
            else
            {
                // ... report the product look-up failure situation  
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        // Otherwise ...
        else
        {
            // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
            // retrying initiailization.
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }



    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        // Purchasing has succeeded initializing. Collect our Purchasing references.
        Debug.Log("OnInitialized: PASS");

        // Overall Purchasing system, configured with products for this application.
        m_StoreController = controller;
        // Store specific subsystem, for accessing device-specific store features.
        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
        // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }


    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        // A consumable product has been purchased by this user.
        if (String.Equals(args.purchasedProduct.definition.id, GOLD_50000, StringComparison.Ordinal))
        {
            Debug.Log("You just bought $50,000!");

            coinCount = PlayerPrefs.GetInt("Coins");
            coinCount = coinCount + 50000;
            PlayerPrefs.SetInt("Coins", coinCount);

        }

        else if (String.Equals(args.purchasedProduct.definition.id, GOLD_100000, StringComparison.Ordinal))
        {
            Debug.Log("You just bought $100,000!");
            coinCount = PlayerPrefs.GetInt("Coins");
            coinCount = coinCount + 100000;
            PlayerPrefs.SetInt("Coins", coinCount);
        }

        else
        {
            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
        }

        return PurchaseProcessingResult.Complete;
    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
        // this reason with the user to guide their troubleshooting actions.
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}






