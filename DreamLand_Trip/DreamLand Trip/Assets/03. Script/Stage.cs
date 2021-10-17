using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public GameObject[] sta = new GameObject[10];
    public int cnt = 0;

    public void NextStage()
    {
        sta[cnt - 1].SetActive(false);
        sta[cnt].SetActive(true);
    }
    
}
