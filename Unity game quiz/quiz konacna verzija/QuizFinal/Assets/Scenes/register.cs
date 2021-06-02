using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Data;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class register : MonoBehaviour
{


    public void GoToMainMenu()
    {

        SceneManager.LoadScene(6);

    }

    public void GoToLogin()
    {

        SceneManager.LoadScene(2);

    }

    /* public void PlayerName()
     {
         tekst =txtUsername.GetComponent<Text>().text;
         username.GetComponent<Text>().text = "Usepesno registrovan" + tekst;
     } */

}
