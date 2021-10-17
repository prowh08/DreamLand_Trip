using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    public InputField inputNick;
    public Text ReTime;

    public GameObject[] rank = new GameObject[5];

    public void Save()
    {
        PlayerPrefs.SetString("Nick", inputNick.text);
        PlayerPrefs.SetString("ReTime", ReTime.ToString());
    }

    public void Load()
    {
        
    }
}
