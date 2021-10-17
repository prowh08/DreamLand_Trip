using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float[] Times = new float[10];
    public float nowTime=0f;
    public Text ti;
    public float mi,se;

    public string TTex;

    // Update is called once per frame
    void Update()
    {
        nowTime += Time.deltaTime;

        TTex = Mathf.Round(nowTime) + "초";
        ti.text = TTex;
    }
}
