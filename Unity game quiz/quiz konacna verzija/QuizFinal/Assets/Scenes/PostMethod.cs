using System.Net;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PostMethod : MonoBehaviour
{
    Text username;

    public string tekst;
    

    public GameObject txtPassword;

    public GameObject txtUsername;


    void Start()
    {
        username = GameObject.Find("username").GetComponent<Text>();
        GameObject.Find("btnRegister").GetComponent<Button>().onClick.AddListener(PostData);
    }
    public void GoToLogin()
    {

        SceneManager.LoadScene(2);

    }

    void PostData() => StartCoroutine(PostData_Coroutine());

    IEnumerator PostData_Coroutine()
    {
        username.text = "Loading...";
        string url = "http://localhost:62263/api/Player";
        WWWForm form = new WWWForm();
        form.AddField("username", txtUsername.GetComponent<Text>().text);
        form.AddField("password", txtPassword.GetComponent<Text>().text);
        using (UnityWebRequest request = UnityWebRequest.Post(url, form))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ProtocolError || request.result == UnityWebRequest.Result.ConnectionError)
            {
                username.text = request.error;
                GoToLogin();

            }
            else
                username.text = request.downloadHandler.text;
        }
    }
}
