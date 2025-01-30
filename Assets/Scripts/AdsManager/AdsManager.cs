// using System.Collections;
//
// using System.Collections.Generic;
//
// using UnityEngine;
//
//
// public class AdsManager : MonoBehaviour
// {
//     public string bannerID = "";
//
//     public string interstitialID = "";
//
//     public string rewardedID = "";
//
//     public string sdkKey = "";
//     
//
//     // Start is called before the first frame update
//
//     void Start()
//
//     {
//
//       MaxSdkCallbacks.OnSdkInitializedEvent += (MaxSdkBase.SdkConfiguration sdkConfiguration) => {
//
//         // AppLovin SDK is initialized, start loading ads
//
//       };
//         
//       MaxSdk.SetSdkKey(sdkKey);
//
//       MaxSdk.InitializeSdk();
//
//       InitializeBannerAds();
//
//       InitializeInterstitialAds();
//
//       InitializeRewardedAds();
//
//     }
//     
//     public void InitializeBannerAds()
//
//     {
//       // Banners are automatically sized to 320×50 on phones and 728×90 on tablets
//
//       // You may call the utility method MaxSdkUtils.isTablet() to help with view sizing adjustments
//
//       MaxSdk.CreateBanner(bannerID, MaxSdkBase.BannerPosition.BottomCenter);
//
//
//
//       // Set background or background color for banners to be fully functional
//
//       MaxSdk.SetBannerBackgroundColor(bannerID, Color.clear);
//
//
//
//       MaxSdkCallbacks.Banner.OnAdLoadedEvent += OnBannerAdLoadedEvent;
//
//       MaxSdkCallbacks.Banner.OnAdLoadFailedEvent += OnBannerAdLoadFailedEvent;
//
//       MaxSdkCallbacks.Banner.OnAdClickedEvent += OnBannerAdClickedEvent;
//
//       MaxSdkCallbacks.Banner.OnAdRevenuePaidEvent += OnBannerAdRevenuePaidEvent;
//
//       MaxSdkCallbacks.Banner.OnAdExpandedEvent += OnBannerAdExpandedEvent;
//
//       MaxSdkCallbacks.Banner.OnAdCollapsedEvent += OnBannerAdCollapsedEvent;
//
//     }
//
//
//
//     private void OnBannerAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) { }
//
//
//
//     private void OnBannerAdLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo) { }
//
//
//
//     private void OnBannerAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) { }
//
//
//
//     private void OnBannerAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) { }
//
//
//
//     private void OnBannerAdExpandedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) { }
//
//
//
//     private void OnBannerAdCollapsedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) { }
//
//
//
//     public void ShowBanner()
//     {
//       MaxSdk.ShowBanner(bannerID);
//
//     }
//
//     
//     public void HideBanner()
//
//     {
//
//       MaxSdk.HideBanner(bannerID);
//
//     }
//
//
//
//     public void InitializeInterstitialAds()
//
//     {
//
//       // Attach callback
//
//       MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += OnInterstitialLoadedEvent;
//
//       MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialLoadFailedEvent;
//
//       MaxSdkCallbacks.Interstitial.OnAdDisplayedEvent += OnInterstitialDisplayedEvent;
//
//       MaxSdkCallbacks.Interstitial.OnAdClickedEvent += OnInterstitialClickedEvent;
//
//       MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialHiddenEvent;
//
//       MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent += OnInterstitialAdFailedToDisplayEvent;
//
//
//
//       // Load the first interstitial
//
//       LoadInterstitial();
//
//     }
//
//
//
//     private void LoadInterstitial()
//
//     {
//
//       MaxSdk.LoadInterstitial(interstitialID);
//
//     }
//
//
//
//     private void OnInterstitialLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
//
//     {
//
//       //
//
//     }
//
//
//
//     private void OnInterstitialLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
//
//     {
//
//       LoadInterstitial();
//
//     }
//
//
//
//     private void OnInterstitialDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) { }
//
//
//
//     private void OnInterstitialAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
//
//     {
//
//       // Interstitial ad failed to display. AppLovin recommends that you load the next ad.
//
//       LoadInterstitial();
//
//     }
//
//
//
//     private void OnInterstitialClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) { }
//
//
//
//     private void OnInterstitialHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
//
//     {
//
//       // Interstitial ad is hidden. Pre-load the next ad.
//
//       LoadInterstitial();
//
//     }
//
//
//
//     public void ShowInterstitial()
//
//     {
//
//       if (MaxSdk.IsInterstitialReady(interstitialID))
//
//       {
//
//         MaxSdk.ShowInterstitial(interstitialID);
//
//       }
//
//     }
//
//
//
//     public void InitializeRewardedAds()
//
//     {
//
//       // Attach callback
//
//       MaxSdkCallbacks.Rewarded.OnAdLoadedEvent += OnRewardedAdLoadedEvent;
//
//       MaxSdkCallbacks.Rewarded.OnAdLoadFailedEvent += OnRewardedAdLoadFailedEvent;
//
//       MaxSdkCallbacks.Rewarded.OnAdDisplayedEvent += OnRewardedAdDisplayedEvent;
//
//       MaxSdkCallbacks.Rewarded.OnAdClickedEvent += OnRewardedAdClickedEvent;
//
//       MaxSdkCallbacks.Rewarded.OnAdRevenuePaidEvent += OnRewardedAdRevenuePaidEvent;
//
//       MaxSdkCallbacks.Rewarded.OnAdHiddenEvent += OnRewardedAdHiddenEvent;
//
//       MaxSdkCallbacks.Rewarded.OnAdDisplayFailedEvent += OnRewardedAdFailedToDisplayEvent;
//
//       MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent += OnRewardedAdReceivedRewardEvent;
//
//
//
//       // Load the first rewarded ad
//
//       LoadRewardedAd();
//
//     }
//
//
//
//     private void LoadRewardedAd()
//
//     {
//
//       MaxSdk.LoadRewardedAd(rewardedID);
//
//     }
//
//
//
//     private void OnRewardedAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
//
//     {
//
//       //
//
//     }
//
//
//
//     private void OnRewardedAdLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
//
//     {
//
//       LoadRewardedAd();
//
//     }
//
//
//
//     private void OnRewardedAdDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) { }
//
//
//
//     private void OnRewardedAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
//
//     {
//
//       // Rewarded ad failed to display. AppLovin recommends that you load the next ad.
//
//       LoadRewardedAd();
//
//     }
//
//
//
//     private void OnRewardedAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) { }
//
//
//
//     private void OnRewardedAdHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
//
//     {
//
//       // Rewarded ad is hidden. Pre-load the next ad
//
//       LoadRewardedAd();
//
//     }
//
//
//
//     private void OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdk.Reward reward, MaxSdkBase.AdInfo adInfo)
//
//     {
//
//       // The rewarded ad displayed and the user should receive the reward
//
//     }
//
//
//
//     private void OnRewardedAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
//
//     {
//
//       // Ad revenue paid. Use this callback to track user revenue.
//
//     }
//
//
//
//     public void ShowRewarded()
//
//     {
//
//       if (MaxSdk.IsRewardedAdReady(rewardedID))
//
//       {
//
//         MaxSdk.ShowRewardedAd(rewardedID);
//
//       }
//
//     }
//
// }
//
