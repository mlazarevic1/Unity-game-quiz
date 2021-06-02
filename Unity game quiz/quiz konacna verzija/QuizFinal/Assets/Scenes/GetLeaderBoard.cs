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

public class GetLeaderBoard : MonoBehaviour
{
    private List<LeaderBoard> rezultati;
    // Start is called before the first frame update
    public List<LeaderBoard> SviIgraci = new List<LeaderBoard>();
    public Text Username1;
    public Text Points1;
    public Text Username2;
    public Text Points2;
    public Text Username3;
    public Text Points3;
    public Text Username4;
    public Text Points4;
    public Text Username5;
    public Text Points5;


    void Awake()
    {
        Izlistaj();
    }

    void Izlistaj() => StartCoroutine(Izlistaj_Coroutine());

    IEnumerator Izlistaj_Coroutine()
    {
        string url = "http://localhost:62263/Api/Player";
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ProtocolError || request.result == UnityWebRequest.Result.ConnectionError)
            {
                SceneManager.LoadScene(5);
            }
            else
            {
                rezultati = JsonConvert.DeserializeObject<List<LeaderBoard>>(request.downloadHandler.text);
                foreach (var player in rezultati)
                {
                    SviIgraci.Add(player);
                }
                    for(int i = 0; i < SviIgraci.Count; i++)
                {

                    GameObject.Find("Username1").GetComponent<Text>().text = SviIgraci[0].username;
                    GameObject.Find("Points1").GetComponent<Text>().text = SviIgraci[0].brojBodova.ToString();

                    GameObject.Find("Username2").GetComponent<Text>().text = SviIgraci[1].username;
                    GameObject.Find("Points2").GetComponent<Text>().text = SviIgraci[1].brojBodova.ToString();

                    GameObject.Find("Username3").GetComponent<Text>().text = SviIgraci[2].username;
                    GameObject.Find("Points3").GetComponent<Text>().text = SviIgraci[2].brojBodova.ToString();

                    GameObject.Find("Username4").GetComponent<Text>().text = SviIgraci[4].username;
                    GameObject.Find("Points4").GetComponent<Text>().text = SviIgraci[4].brojBodova.ToString();

                    GameObject.Find("Username5").GetComponent<Text>().text = SviIgraci[5].username;
                    GameObject.Find("Points5").GetComponent<Text>().text = SviIgraci[5].brojBodova.ToString();

                }
            }
        }
    }

}
