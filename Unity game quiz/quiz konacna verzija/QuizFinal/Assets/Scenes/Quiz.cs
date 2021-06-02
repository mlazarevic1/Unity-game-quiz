using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEditor;
using System.IO;
using System;


public class Quiz : MonoBehaviour
{
    Text playerInfo;
   
    private void Start()
    {

        playerInfo = GameObject.Find("playerInfo").GetComponent<Text>();
        playerInfo.text = "Welcome " + GetLogin.player;
        
    }

    
    public void GoToQuiz()
    {

        SceneManager.LoadScene(3);

    }
    public void GoToLeaderBoeard()
    {

        SceneManager.LoadScene(5);

    }
    public void Exit()
    {

        Application.Quit();

    }
}
