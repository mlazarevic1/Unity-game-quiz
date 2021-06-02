using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class GetLogin : MonoBehaviour
{
    Text username;
    public GameObject txtPassword;
    public GameObject txtUsername;
    public static string player;

    private void Start()
    {
        GameObject.Find("btnLogin").GetComponent<Button>().onClick.AddListener(GetData);
    }

    void GetData() => StartCoroutine(GetData_Coroutine());
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(7);
    }

    IEnumerator GetData_Coroutine()
    {
        string url = "http://localhost:62263/Api/PlayerLogIn";
        WWWForm form = new WWWForm();
        form.AddField("username", txtUsername.GetComponent<Text>().text);
        form.AddField("password", txtPassword.GetComponent<Text>().text);
        using (UnityWebRequest request = UnityWebRequest.Post(url, form))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ProtocolError || request.result == UnityWebRequest.Result.ConnectionError)
            {

                username.text = request.error;
            }
            else if(request.downloadHandler.text.Trim('"') == "Pogresan username ili sifra")
            {
                GameObject.Find("username").GetComponent<Text>().text = request.downloadHandler.text.Trim('"');
            }
            else
            {
                player = request.downloadHandler.text.Trim('"');
                GoToMainMenu();
            }
        }
    }
}
