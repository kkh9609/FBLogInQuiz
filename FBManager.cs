using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.SceneManagement;

public class FBManager : MonoBehaviour
{
    void InitFacebook()
    {
        if (!FB.IsInitialized)
            FB.Init(InitCallBack, OnHideUnity);
        else
            FB.ActivateApp();
    }
    void InitCallBack()
    {
        if(FB.IsInitialized)
            FB.ActivateApp();
    }
    void OnHideUnity(bool isGameShow)
    {
        Time.timeScale = isGameShow ? 1 : 0;
    }
    void LogInFaceBook()
    {
        if(!FB.IsLoggedIn)
        {
            List<string> parms = new List<string>() { "gaming_user_picture", "gaming_profile", "email" };
            FB.LogInWithReadPermissions(parms, AuthCallback);
        }
    }
    void AuthCallback(ILoginResult result)
    {
        if (result.Error != null)
            Debug.LogFormat("로그인 실패...Auth Error : {0}", result.Error);
        else
            OnLoginSuccess();
    }
    protected virtual void OnLoginSuccess()
    {
        Debug.Log("로그인 성공");
        SceneManager.LoadScene(1);
    }
    private void Start()
    {
        if (!FB.IsInitialized && !FB.IsLoggedIn)
            InitFacebook();
    }
    private void Update()
    {
        if(FB.IsLoggedIn)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void OnLogInFB()
    {
        LogInFaceBook();
    }
}
