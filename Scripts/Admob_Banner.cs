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

    //  this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded; // ���� �ε尡 �Ϸ�Ǹ� ȣ��
    //  this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad; // ���� �ε尡 �������� �� ȣ��
    //  this.rewardedAd.OnAdOpening += HandleRewardedAdOpening; // ���� ǥ�õ� �� ȣ��(��� ȭ���� ����)
    //  this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow; // ���� ǥ�ð� �������� �� ȣ��
    //  this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;// ���� ��û�� �� ������ �޾ƾ��� �� ȣ��
    //  this.rewardedAd.OnAdClosed += HandleRewardedAdClosed; // �ݱ� ��ư�� �����ų� �ڷΰ��� ��ư�� ���� ������ ���� ���� �� ȣ��
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
    //adUnitId ����
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