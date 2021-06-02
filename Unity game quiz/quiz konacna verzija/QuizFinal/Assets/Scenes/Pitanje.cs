using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[System.Serializable]
public class Pitanje
{
    
    public int pitanjeID { get; set; }
    public string pitanje { get; set; }
    public string level { get; set; }
    public int iskorisceno { get; set;}
    
}
