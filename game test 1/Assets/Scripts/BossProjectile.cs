﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    private bool hasDirection;
    private Vector2 moveDirection;

    public float lifeTime;
    public float moveSpeed;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(hasDirection){
            transform.position = Vector2.MoveTowards(transform.position, moveDirection, moveSpeed * Time.deltaTime);

        }
    }

    public void SetDirection(Vector2 direction){
        hasDirection = true;
        moveDirection = direction;
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            collision.gameObject.GetComponent<PlayerScript>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
