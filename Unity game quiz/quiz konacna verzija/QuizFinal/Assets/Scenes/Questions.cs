using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerQuestions
{
    public string pitanje;
    public static PlayerQuestions createFromJson(string jsonString)
    {
        return JsonUtility.FromJson<PlayerQuestions>(jsonString);

    }

   
}
