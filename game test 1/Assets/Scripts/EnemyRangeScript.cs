using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeScript : MonoBehaviour
{
    public Transform player;
    public float shotCooldown;
    public float stoopingDistance;
    public float retreatDistance;
    public float moveSpeed = 1.7f;
    public GameObject projectile;
    public float health;

    private float shotTimer;
    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        shotTimer = shotCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > stoopingDistance){
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, player.position) < stoopingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance){ 
            transform.position = this.transform.position;

            if(canShoot){
                Shoot();
            }

        }
        else if(Vector2.Distance(transform.position, player.position) < retreatDistance){
            transform.position = Vector2.MoveTowards(transform.position, player.position, -moveSpeed * Time.deltaTime);
        }
        if (shotTimer <= 0 ){
            canShoot = true;
        }
        else{
            canShoot = false;
            shotTimer -= Time.deltaTime;

        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
    private void Shoot(){
        Instantiate(projectile, transform.position, Quaternion.identity);
        shotTimer = shotCooldown;
    }
}
