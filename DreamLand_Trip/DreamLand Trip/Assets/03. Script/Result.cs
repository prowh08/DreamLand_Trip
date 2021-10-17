using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public Sprite[] level = new Sprite[9];
    public GameObject[] star = new GameObject[3];
    public GameObject time, movet;
    public Image Limage;
    public Text TMo, TI;

    Stage stage;
    Player player;

    public void RePan()
    {
        stage = GameObject.Find("manager").GetComponent<Stage>();
        player = GameObject.Find("player").GetComponent<Player>();
        
        switch (stage.cnt)
        {
            case 0:
                Limage.sprite = level[0];
                break;
            case 1:
                Limage.sprite = level[1];
                break;
            case 2:
                Limage.sprite = level[2];
                break;
            case 3:
                Limage.sprite = level[3];
                break;
            case 4:
                Limage.sprite = level[4];
                break;
            case 5:
                Limage.sprite = level[5];
                break;
            case 6:
                Limage.sprite = level[6];
                break;
            case 7:
                Limage.sprite = level[7];
                break;
            case 8:
                Limage.sprite = level[8];
                break;
        }

        stage.cnt += 1;
        player.SPos();
        stage.NextStage();
    }
}
