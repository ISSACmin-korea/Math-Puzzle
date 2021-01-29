using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class AdmobScreenAd : MonoBehaviour
{
    private readonly string unitID = "ca-app-pub-2795477849017803/1188974967";
    private readonly string test_unitID = "ca-app-pub-2795477849017803/1188974967";

    private readonly string test_deviceID = "";

    private InterstitialAd screenAd;

    private void Start()
    {
        InitAd();
        Invoke("Show", 10f);
    }
    private void InitAd()
    {
        string id = unitID;

        screenAd = new InterstitialAd(id);

        AdRequest request = new AdRequest.Builder().Build();

        screenAd.LoadAd(request);
        screenAd.OnAdClosed += (sender, e) => Debug.Log("광고가 닫힘");
        screenAd.OnAdLoaded += (sender, e) => Debug.Log("광고가 로드됨");
    }

    public void Show()
    {
        StartCoroutine("ShowScreenAd");
    }

    private IEnumerator ShowScreenAd()
    {
        while (!screenAd.IsLoaded())
        {
            yield return null;
        }
        screenAd.Show();
    }
}
