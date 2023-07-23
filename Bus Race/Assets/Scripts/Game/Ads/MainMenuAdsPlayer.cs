using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAdsPlayer : MonoBehaviour
{
    private void Start()
    {
        var adsHandler = new YandexGameAdsHandler();

        adsHandler.ShowFullSceenAd();        
    }
}
