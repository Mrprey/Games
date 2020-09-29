using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public Transform player;
    public bool canMove;
    public int damage;
    public float moveSpeed;
    public float health;
    public GameObject bossProjectile;
    public float shotCoolDown;
    public float projectileCount;
    public bool rageMode;
    public float ragePercent;
    public Animator bossAnime;
    
    private float rageHaelth;
    private float shootTimer;
    private bool canShoot;
    private Vector2 targetSpot;
    public Vector2[] movePoints;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GetNextSpot();
        ragePercent = ragePercent * health/100;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null){
            if (transform.position.x != targetSpot.x && transform.position.y != targetSpot.y){
                if (canMove = true){
                    transform.position = Vector2.MoveTowards(transform.position, targetSpot, moveSpeed * Time.deltaTime);
                }
            }
            else{
                GetNextSpot();
            }
            if (shootTimer <= 0){
                Shoot();
            }
            else{
                shootTimer -= Time.deltaTime;
            }
        }

        if(health <= rageHaelth && !rageMode){
            Enrage();
        }
    }

    private void GetNextSpot(){
        int randomSpot = Random.Range(0, movePoints.Length);
        targetSpot = movePoints[randomSpot];
        

    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            collision.gameObject.GetComponent<PlayerScript>().TakeDamage(damage);
        }
    }

    private void Shoot(){
        shootTimer = shotCoolDown;
        float angleStep = 360f / projectileCount;
        float angle = 0f;

        for (int i = 0; i <= projectileCount -1; i++){
            float xPosition = transform.position.x + Mathf.Sin((angle * Mathf.PI)/180)*360;
            float yPosition = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * 360;

            Vector2 projectileDirection = new Vector2(xPosition, yPosition);

            var projectile = Instantiate(bossProjectile, transform.position, Quaternion.identity);
            projectile.GetComponent<BossProjectile>().SetDirection(projectileDirection * 3);

            angle += angleStep;
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
    private void Enrage(){
        rageMode = true;
        moveSpeed *= 3;
        shotCoolDown *= .75f;
        bossAnime.SetTrigger("Rage");
    }
}
