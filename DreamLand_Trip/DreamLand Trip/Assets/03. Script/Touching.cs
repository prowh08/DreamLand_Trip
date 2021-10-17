using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touching : MonoBehaviour
{
    public GameObject title,title_show;
    public Animator anim;


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                title.SetActive(false);
                title_show.SetActive(true);
                anim.SetBool("moving", true);
            }
        }
    }
}
