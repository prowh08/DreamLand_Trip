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
    public Text TMo, TI, EndTime;


    Stage stage;
    Player player;
    Timer Tti;
    
    public void RePan() // 레벨 나타내기
    {
        stage = GameObject.Find("manager").GetComponent<Stage>();
        
        switch (stage.cnt)
        {
            case 0:
                Limage.sprite = level[0];
                Level();
                break;
            case 1:
                Limage.sprite = level[1];
                Level();
                break;
            case 2:
                Limage.sprite = level[2];
                Level();
                break;
            case 3:
                Limage.sprite = level[3];
                Level();
                break;
            case 4:
                Limage.sprite = level[4];
                Level();
                break;
            case 5:
                Limage.sprite = level[5];
                Level();
                break;
            case 6:
                Limage.sprite = level[6];
                Level();
                break;
            case 7:
                Limage.sprite = level[7];
                Level();
                break;
            case 8:
                Limage.sprite = level[8];
                Level();
                break;
            case 9:
                Limage.sprite = level[9];
                Level();
                break;
        }
    }

    public void NextS()
    {
        player = GameObject.Find("player").GetComponent<Player>();
        stage = GameObject.Find("manager").GetComponent<Stage>();

        stage.cnt += 1;
        stage.NextStage();
        player.SPos();
    } // 다음 스테이지 관련 함수 호출

    public void Level() // 점수에 따른 별 모양
    {
        player = GameObject.Find("player").GetComponent<Player>();
        stage = GameObject.Find("manager").GetComponent<Stage>();
        Tti = GameObject.Find("manager").GetComponent<Timer>();

        for (int i = 0; i < 3; i++)
            star[i].SetActive(false);

        List<Dictionary<string, object>> data = CSVReader.Read("MoveCnt"); //CSV 파일 파싱

        if ((int)data[stage.cnt]["End"]-player.mcnt[stage.cnt] <= (int)data[stage.cnt]["End"])
        {
            if ((int)data[stage.cnt]["End"]-player.mcnt[stage.cnt] <= (int)data[stage.cnt]["Good"])
            {
                if ((int)data[stage.cnt]["End"]-player.mcnt[stage.cnt] <= (int)data[stage.cnt]["Perfect"])
                    star[2].SetActive(true);
                else
                    star[1].SetActive(true);
            }
            else
                star[0].SetActive(true);

            TMo.text = player.mcnt[stage.cnt].ToString();
            TI.text = Tti.TTex;
        }
        else
            player.Retry();
    }

    public void LReset()
    {
        Tti = GameObject.Find("manager").GetComponent<Timer>();

        for (int i=0;i<3;i++)
            star[i].SetActive(false);
        
        Tti.nowTime = 0f;
    }

    public void RecordTime()
    {
        Tti = GameObject.Find("manager").GetComponent<Timer>();
        EndTime.text = Tti.TTex;
    }

    public void Qu()
    {
        Application.Quit();
    }
}
