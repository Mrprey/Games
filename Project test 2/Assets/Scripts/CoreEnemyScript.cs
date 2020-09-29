using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoreEnemyScript : MonoBehaviour
{
    public float heart;
    public float speedMove = 3;
    public float damage;
    public Transform playerN;
    public PlayerScript playerS;

    public DialogController dialog;


    // Start is called before the first frame update
    void Start()
    {
        playerN = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
           // playerN.GetComponent<PlayerScript>().speedMove = 0;
            Action();
        }

    }

    public abstract void SpeechScript();


    public abstract void Action();
}
