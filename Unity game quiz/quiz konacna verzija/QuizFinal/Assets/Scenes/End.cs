using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    Text txtScore;

    private void Start()
    {
        txtScore = GameObject.Find("txtScore").GetComponent<Text>();
        txtScore.text = GetMethodPitanje.brojBodova.ToString();
        GetMethodPitanje.brojBodova = 0;


    }

}
