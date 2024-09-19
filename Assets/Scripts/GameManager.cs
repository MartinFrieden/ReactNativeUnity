using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void ExtitButtonClick()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
        intentObject.Call<AndroidJavaObject>("putExtra", "callBackFromUnityToRN", "Hello From Unity!!!");
        GetCurrentActivity().Call("setResult", -1, intentObject);
        GetCurrentActivity().Call("finish");            
#endif
    }

    public AndroidJavaObject GetIntent()
    {
        return GetCurrentActivity().Call<AndroidJavaObject>("getIntent");
    }

    public AndroidJavaObject GetCurrentActivity()
    {
        AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        return UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    }
}
