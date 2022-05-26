using UnityEngine;
using UnityEngine.Purchasing;

public class MyIAPManager : IStoreListener
{

    private IStoreController controller;
    private IExtensionProvider extensions;

    public MyIAPManager()
    {

        Debug.Log("IAP Manager initialization started");
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
         builder.AddProduct("Popularity", ProductType.Consumable, new IDs
         {
             {"Popularity", GooglePlay.Name},
             {"Popularity", MacAppStore.Name}
         });

        UnityPurchasing.Initialize(this, builder);

    }

    /// <summary>
    /// Called when Unity IAP is ready to make purchases.
    /// </summary>
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        this.controller = controller;
        this.extensions = extensions;
        Debug.Log("IAP Manager initialization finished");
    }

    /// <summary>
    /// Called when Unity IAP encounters an unrecoverable initialization error.
    ///
    /// Note that this will not be called if Internet is unavailable; Unity IAP
    /// will attempt initialization until it becomes available.
    /// </summary>
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("IAP Manager initialization failed"+error);
    }

    /// <summary>
    /// Called when a purchase completes.
    ///
    /// May be called at any time after OnInitialized().
    /// </summary>
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
    {
        return PurchaseProcessingResult.Complete;
    }

    /// <summary>
    /// Called when a purchase fails.
    /// </summary>
    public void OnPurchaseFailed(Product i, PurchaseFailureReason p)
    {
    }
}