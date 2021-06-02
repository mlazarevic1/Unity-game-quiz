using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuLOG : MonoBehaviour
{ 
    public void GoToLogin()
    {

        SceneManager.LoadScene(2);

    }
    public void GoToRegister()
    {

        SceneManager.LoadScene(1);

    }
    public void Exit()
    {

        Application.Quit();

    }

}
