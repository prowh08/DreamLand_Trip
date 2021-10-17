using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int speed = 2000;
    public GameObject RetryP;
    public GameObject ResultP;
    public GameObject NeB,EndB;
    public Text movet;
    public int[] mcnt = new int[10]; // 각 스테이지별 최대 이동횟수


    Rigidbody2D rbody;
    Vector3 touching;
    float posx, posy;

    int num = 0;
    bool reset;
    public bool boss=false , boss1=false , boss2= false;
    GameObject[] obj = new GameObject[3];

    Stage stage;
    Result result;

    public Text tt, t;

    void Start()
    {
        Time.timeScale = 4;
        rbody = GetComponent<Rigidbody2D>();
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        gameObject.transform.position = new Vector2(210, 1400);
        stage = GameObject.Find("manager").GetComponent<Stage>();
        stage.cnt = 0;

    }


    void FixedUpdate()
    {
        if (reset == false)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (Input.GetTouch(0).phase == TouchPhase.Began)// 터치 시작할 때
                {
                    touching = Input.GetTouch(0).position;
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    posx = Input.GetTouch(0).position.x - touching.x;
                    posy = Input.GetTouch(0).position.y - touching.y;

                    if (Mathf.Abs(posx) > Mathf.Abs(posy)) //좌우 이동
                    {
                        if (touching.x > Input.GetTouch(0).position.x)
                        {
                            rbody.velocity = new Vector2(-speed, 0);
                        }
                        else if (touching.x < Input.GetTouch(0).position.x)
                        {
                            rbody.velocity = new Vector2(speed, 0);
                        }
                    }
                    else if (Mathf.Abs(posx) < Mathf.Abs(posy)) //상하 이동
                    {
                        if (touching.y > Input.GetTouch(0).position.y)
                        {
                            rbody.velocity = new Vector2(0, -speed);
                        }
                        else if (touching.y < Input.GetTouch(0).position.y)
                        {
                            rbody.velocity = new Vector2(0, speed);
                        }
                    }
                }
            }

            movet.text = mcnt[stage.cnt].ToString();
        } // 터치 했을 때 움직이는 방향

        if (mcnt[stage.cnt] < 1)
            Retry();
    }

    void OnCollisionEnter2D(Collision2D col) // 외부로 나갔을 때 종료와 8스테이지 이전까지 boss와 만났을 때 조건
    {
        if (col.gameObject.tag == "outline")
        {
            reset = true;
            Time.timeScale = 0;
            RetryP.SetActive(true);
        }
        else if (col.gameObject.tag == "Aplanet")
        {
            mcnt[stage.cnt] -= 1;
        }

        if (stage.cnt < 9)
        {
            if (col.gameObject.tag == "boss")
            {
                mcnt[stage.cnt] -= 1;
                Time.timeScale = 0;
                StopP();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col) // Bplanet 과 boss들 과 만났을 때 각 조건
    {
        if (col.gameObject.tag == "Bplanet")
            Catch(col);

        if (stage.cnt > 7 && stage.cnt < 9)
        {
            if (col.gameObject.CompareTag("boss"))
            {
                boss = true;
                col.gameObject.SetActive(false);
                obj[0] = col.gameObject;
                Catch(col);
            }

            else if (col.gameObject.tag == "boss1")
            {
                boss1 = true;
                col.gameObject.SetActive(false);
                obj[1] = col.gameObject;
                Catch(col);
            }

            if (boss == true && boss1 == true)
            {
                mcnt[stage.cnt] -= 1;
                StopP();
                Time.timeScale = 0;
            }
        }
        else if (stage.cnt > 8)
        {
            if (col.gameObject.tag == "boss")
            {
                boss = true;
                col.gameObject.SetActive(false);
                obj[0] = col.gameObject;
                Catch(col);
            }
            else if (col.gameObject.tag == "boss1")
            {
                boss1 = true;
                col.gameObject.SetActive(false);
                obj[1] = col.gameObject;
                Catch(col);
            }
            else if (col.gameObject.tag == "boss2")
            {
                boss2 = true;
                col.gameObject.SetActive(false);
                obj[2] = col.gameObject;
                Catch(col);
            }

            if (boss == true && boss1 == true && boss2 == true)
            {
                mcnt[stage.cnt] -= 1;
                Time.timeScale = 0;

                result.RePan();
                ResultP.SetActive(true);
                NeB.SetActive(false);
                EndB.SetActive(true);
            }
        }
    }

    public void Retry() //  재시작
    {
        mcnt[stage.cnt] = num;

        result = GameObject.Find("manager").GetComponent<Result>();
        result.LReset();

        reset = false;

        Debug.Log(boss);
        Debug.Log(boss1);

        if (boss == true && boss1 == true && boss2 == true)
        {
            Debug.Log("1");
            SObj(7);
        }
            
        else if (boss == true && boss1 == true)
        {
            Debug.Log("2");
            SObj(4);
        }

       
        else if (boss == true && boss2 == true)
        {
            Debug.Log("3");
            SObj(5);
        }
        else if (boss1 == true && boss2 == true)
        {
            Debug.Log("4");
            SObj(6);
        }
        
        else if (boss == true)
        {
            Debug.Log("5");
            SObj(1);
        }
        
        else if (boss1 == true)
        {
            Debug.Log("6");
            SObj(2);
        }
        
        else if (boss2 == true)
        {
            Debug.Log("7");
            SObj(3);
        }
        
        else{
            Debug.Log("8");
        }
        
        SPos();
    }

    public void StopP() // 다음 스테이지로 넘어가는 함수
    {
        stage = GameObject.Find("manager").GetComponent<Stage>();
        result = GameObject.Find("manager").GetComponent<Result>();

        result.RePan();
        ResultP.SetActive(true);
        boss = boss1 = boss2 = false;

    }

    public void SPos() //각 스테이지별 player 시작 위치
    {
        stage = GameObject.Find("manager").GetComponent<Stage>();
        Time.timeScale = 4;
        num = mcnt[stage.cnt];

        switch (stage.cnt)
        {
            case 0:
                gameObject.transform.position = new Vector2(210, 1400);
                break;
            case 1:
                gameObject.transform.position = new Vector2(300, 1500);
                break;
            case 2:
                gameObject.transform.position = new Vector2(210, 1680);
                break;
            case 3:
                gameObject.transform.position = new Vector2(470, 1580);
                break;
            case 4:
                gameObject.transform.position = new Vector2(375, 1580);
                break;
            case 5:
                gameObject.transform.position = new Vector2(210, 1210);
                break;
            case 6:
                gameObject.transform.position = new Vector2(120, 1220);
                break;
            case 7:
                gameObject.transform.position = new Vector2(890, 1300);
                break;
            case 8:
                gameObject.transform.position = new Vector2(210, 1130);
                break;
            case 9:
                gameObject.transform.position = new Vector2(800, 1650);
                break;
        }


    }

    public void Catch(Collider2D col) //Bplnet과 boss들이 player와 만났을 때 멈추게 하기
    {
        gameObject.transform.position = col.transform.position;
        speed = 0;
        rbody.velocity = new Vector2(speed, speed);
        speed = 2000;
    }

    public void SObj(int i) // 숨은 보스들 다시 보이게
    {
        if (i == 1)
        {
            obj[0].SetActive(true);
            boss = false;
        }
        else if (i == 2)
        {
            obj[1].SetActive(true);
            boss1 = false;
        }
        else if (i == 3)
        {
            obj[2].SetActive(true);
            boss2 = false;
        }

        else if (i == 4)
        {
            obj[0].SetActive(true);
            obj[1].SetActive(true);
            boss = boss1 = false;
        }
        else if (i == 5)
        {
            obj[0].SetActive(true);
            obj[2].SetActive(true);
            boss = boss2 = false;
        }
        else if (i == 6)
        {
            obj[1].SetActive(true);
            obj[2].SetActive(true);
            boss2 = boss1 = false;
        }
        else if (i == 7)
        {
            obj[0].SetActive(true);
            obj[1].SetActive(true);
            obj[2].SetActive(true);
            boss = boss2 = boss1 = false;
        }
        
    }

}
