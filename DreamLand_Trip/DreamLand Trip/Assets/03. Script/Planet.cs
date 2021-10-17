using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{
    Rigidbody2D rgd;
    public Text tt;
    public GameObject player;

    void Awake()
    {
        rgd = GetComponent<Rigidbody2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //player.transform.position = gameObject.transform.position;
    }
}
