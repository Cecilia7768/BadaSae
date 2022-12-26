using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class Admob_Banner : MonoBehaviour
{
  private RewardedAd rewardedAd;
  private BannerView bannerView;
  string adUnitId;

  public void Start()
  {
    MobileAds.Initialize(initStatus => { });
    this.RequestBanner();


    //  this.rewardedAd = new RewardedAd(adUnitId);

    //  this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded; // 광고 로드가 완료되면 호출
    //  this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad; // 광고 로드가 실패했을 때 호출
    //  this.rewardedAd.OnAdOpening += HandleRewardedAdOpening; // 광고가 표시될 때 호출(기기 화면을 덮음)
    //  this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow; // 광고 표시가 실패했을 때 호출
    //  this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;// 광고를 시청한 후 보상을 받아야할 때 호출
    //  this.rewardedAd.OnAdClosed += HandleRewardedAdClosed; // 닫기 버튼을 누르거나 뒤로가기 버튼을 눌러 동영상 광고를 닫을 때 호출
    //}

    //public void HandleRewardedAdLoaded(object sender, EventArgs args) { }

    //public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    //{
    //}

    //public void HandleRewardedAdOpening(object sender, EventArgs args) { }

    //public void HandleRewardedAdFailedToShow(object sender, EventArgs args) { }

    //public void HandleRewardedAdClosed(object sender, EventArgs args) { }

    //public void HandleUserEarnedReward(object sender, Reward args)
    //{
  }

  private void RequestBanner()
  {
    //adUnitId 설정
#if UNITY_ANDROID
    adUnitId = "ca-app-pub-3940256099942544/6300978111";
#endif

    if (bannerView != null)
      this.bannerView.Destroy();

    AdSize adaptiveSize =
      AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

    this.bannerView = new BannerView(adUnitId, adaptiveSize, AdPosition.Bottom);


    AdRequest request = new AdRequest.Builder().Build();
    this.bannerView.LoadAd(request);
  }


}