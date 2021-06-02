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

public class GetMethodPitanje : MonoBehaviour
{
    private const string defaultContentType = "application/json";
    public static int redniBrojPitanja;
    Text question;
    public GameObject txtTimer;
    public GameObject txtAnswer1;
    public GameObject txtAnswer2;
    public GameObject txtAnswer3;
    public GameObject txtAnswer4;
    public float timer = 450f;
    public bool takingAway = false;
    public static string tezinaPitanja;
    public static int brojBodova;

    private List<LeaderBoard> rezultati = new List<LeaderBoard>();
    private List<Odgovori> odgovoriZaPitanje = new List<Odgovori>();
    private List<Odgovori> odgovoriZaProveru = new List<Odgovori>();
    List<Pitanja> pitanje;
    List<Odgovori> odgovori;

    

    void Start()
    {
        //GetData();
        pozivPitanja();
        txtTimer.GetComponent<Text>().text = "Time left: " + System.Math.Round(timer, 1).ToString();
    }

    void Awake()
    {
        GetData();
        //pozivPitanja();
        question = GameObject.Find("txtQuestion").GetComponent<Text>();
        brojBodova = 0;
        redniBrojPitanja = 0;
    }

    void Update()
    {
        if (takingAway == false && timer > 0)
        {
            StartCoroutine(Countdown());
        }
        else if (takingAway == false && timer <= 0)
        {
            SceneManager.LoadScene(4);
        }
    }

    IEnumerator Countdown()
    {
        takingAway = true;
        yield return new WaitForSeconds(1f);
        timer -= 1f;
        txtTimer.GetComponent<Text>().text = "Time left: " + timer.ToString();
        takingAway = false;
    }

    public void startProvere()
    {
        StartCoroutine(startProvere_Coroutine());
        pozivPitanja();

    }


    void GetData() => StartCoroutine(GetData_Coroutine());

    IEnumerator GetData_Coroutine()
    {
        string url = "http://localhost:62263/Api/Pitanja";
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ProtocolError || request.result == UnityWebRequest.Result.ConnectionError)
            {
                SceneManager.LoadScene(7);
            }
            else
            {
                string urlODG = "http://localhost:62263/Api/Odgovori";
                using (UnityWebRequest requestODG = UnityWebRequest.Get(urlODG))
                {
                    yield return requestODG.SendWebRequest();
                    if (requestODG.result == UnityWebRequest.Result.ProtocolError || requestODG.result == UnityWebRequest.Result.ConnectionError)
                    {
                        SceneManager.LoadScene(7);
                    }
                    else
                    {
                        pitanje = JsonConvert.DeserializeObject<List<Pitanja>>(request.downloadHandler.text);
                        odgovori = JsonConvert.DeserializeObject<List<Odgovori>>(requestODG.downloadHandler.text);
                        //pozivPitanja();
                    }
                }
            }
        }
    }

    IEnumerator startProvere_Coroutine()
    {
        Button btn = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        Text txt = btn.GetComponentInChildren<Text>();
        //ColorBlock colors = btn.colors;
        for (int i = 0; i < odgovoriZaProveru.Count; i++)
        {
            if (txt.text == odgovoriZaProveru[i].odgovor)
            {
                var item = odgovoriZaProveru[i];
                if(Convert.ToInt32(item.tacnost) == 1)
                {
                    Debug.Log(tezinaPitanja);
                    if (tezinaPitanja == "easy")
                    {
                        brojBodova += 100;
                        
                    }
                    else if(tezinaPitanja == "medium")
                    {
                        brojBodova += 500;
                    }
                    else if(tezinaPitanja == "hard")
                    {
                        brojBodova += 1000;
                    }
                    yield return new WaitForSeconds(0f);
                    odgovoriZaProveru.Clear();
                }
                else if(Convert.ToInt32(item.tacnost) == 0)
                {
                    RequestHeader contentTypeHeader = new RequestHeader
                    {
                        Key = "Content-Type",
                        Value = "application/json"
                    };
                    string link = "http://localhost:62263/Api/Player?username={username}";
                    LeaderBoard igrac = new LeaderBoard();
                    igrac.username = GetLogin.player;
                    igrac.brojBodova = brojBodova;
                    rezultati.Add(igrac);
                    string str = JsonConvert.SerializeObject(igrac, Formatting.Indented);
                    StartCoroutine(HttpPut_Coroutine(link, str, new List<RequestHeader> { contentTypeHeader }));
                    yield return new WaitForSeconds(0f);
                    redniBrojPitanja = 0;
                    odgovoriZaProveru.Clear();
                    SceneManager.LoadScene(4);
                }
            }   
        }
    }

    public void pozivPitanja()
    {
        redniBrojPitanja += 1;
        if(redniBrojPitanja <= 5)
        {
            foreach(var pit in pitanje)
            {
                if (pit.level == "easy" && Convert.ToInt32(pit.iskorisceno) == 0)
                {
                    tezinaPitanja = "easy";
                    question.text = pit.pitanje;
                    foreach (var odg in odgovori)
                    {
                        if (Convert.ToInt32(odg.pitanjeID) == Convert.ToInt32(pit.pitanjeID))
                        {
                            odgovoriZaPitanje.Add(odg);
                            odgovoriZaProveru.Add(odg);
                        }
                    }
                    pit.iskorisceno = 1;
                    pitanje.Remove(pit);
                    txtAnswer1.GetComponent<Text>().text = odgovoriZaPitanje[0].odgovor;
                    txtAnswer2.GetComponent<Text>().text = odgovoriZaPitanje[1].odgovor;
                    txtAnswer3.GetComponent<Text>().text = odgovoriZaPitanje[2].odgovor;
                    txtAnswer4.GetComponent<Text>().text = odgovoriZaPitanje[3].odgovor;
                    odgovoriZaPitanje.Clear();
                    break;
                }
            }
        }
        else if (redniBrojPitanja >= 6 && redniBrojPitanja <= 10)
        {
            foreach (var pit in pitanje)
            {
                if (pit.level == "medium" && Convert.ToInt32(pit.iskorisceno) == 0)
                {
                    question.text = pit.pitanje;
                    foreach (var odg in odgovori)
                    {
                        if (Convert.ToInt32(odg.pitanjeID) == Convert.ToInt32(pit.pitanjeID))
                        {
                            odgovoriZaPitanje.Add(odg);
                            odgovoriZaProveru.Add(odg);
                        }
                    }
                    pit.iskorisceno = 1;
                    pitanje.Remove(pit);
                    tezinaPitanja = "medium";
                    txtAnswer1.GetComponent<Text>().text = odgovoriZaPitanje[0].odgovor;
                    txtAnswer2.GetComponent<Text>().text = odgovoriZaPitanje[1].odgovor;
                    txtAnswer3.GetComponent<Text>().text = odgovoriZaPitanje[2].odgovor;
                    txtAnswer4.GetComponent<Text>().text = odgovoriZaPitanje[3].odgovor;
                    odgovoriZaPitanje.Clear();
                    break;
                }
            }
        }
        else if (redniBrojPitanja >= 11 && redniBrojPitanja <= 15)
        {
            foreach (var pit in pitanje)
            {
                if (pit.level == "hard" && Convert.ToInt32(pit.iskorisceno) == 0)
                {
                    question.text = pit.pitanje;
                    foreach (var odg in odgovori)
                    {
                        if (Convert.ToInt32(odg.pitanjeID) == Convert.ToInt32(pit.pitanjeID))
                        {
                            odgovoriZaPitanje.Add(odg);
                            odgovoriZaProveru.Add(odg);
                        }
                    }
                    pit.iskorisceno = 1;
                    pitanje.Remove(pit);
                    tezinaPitanja = "hard";
                    txtAnswer1.GetComponent<Text>().text = odgovoriZaPitanje[0].odgovor;
                    txtAnswer2.GetComponent<Text>().text = odgovoriZaPitanje[1].odgovor;
                    txtAnswer3.GetComponent<Text>().text = odgovoriZaPitanje[2].odgovor;
                    txtAnswer4.GetComponent<Text>().text = odgovoriZaPitanje[3].odgovor;
                    odgovoriZaPitanje.Clear();
                    break;
                }
            }
        }
        else if (redniBrojPitanja >= 16)
        {
            brojBodova += Convert.ToInt32(timer);
            RequestHeader contentTypeHeader = new RequestHeader
            {
                Key = "Content-Type",
                Value = "application/json"
            };
            string link = "http://localhost:62263/api/Player?username={username}";
            LeaderBoard igrac = new LeaderBoard();
            igrac.username = GetLogin.player;
            igrac.brojBodova = brojBodova;
            rezultati.Add(igrac);
            string str = JsonConvert.SerializeObject(igrac, Formatting.Indented);
            StartCoroutine(HttpPut_Coroutine(link, str, new List<RequestHeader> { contentTypeHeader }));
            redniBrojPitanja = 0;
            SceneManager.LoadScene(4);
        }
    }

    public IEnumerator HttpPut_Coroutine(string url, string body, IEnumerable<RequestHeader> headers = null)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Put(url, body))
        {

            if (headers != null)
            {
                foreach (RequestHeader header in headers)
                {
                    webRequest.SetRequestHeader(header.Key, header.Value);
                }
            }

            webRequest.uploadHandler.contentType = defaultContentType;
            webRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body));

            yield return webRequest.SendWebRequest();

        }
    }
}
