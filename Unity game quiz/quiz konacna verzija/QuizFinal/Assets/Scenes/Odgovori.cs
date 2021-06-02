using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


[System.Serializable]
public class Odgovori
{
    public int pitanjeID { get; set; }
    public string odgovor { get; set; }
    public int tacnost { get; set; }
}

