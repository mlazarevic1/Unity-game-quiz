using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[System.Serializable]
public class LeaderBoard
{
    public string username { get; set; }
    public int brojBodova { get; set; }
}