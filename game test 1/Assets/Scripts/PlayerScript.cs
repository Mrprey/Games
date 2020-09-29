using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour{

    public float moveSpeed;
    public Rigidbody2D playerRb;
    public float recoveringTime;
    public int health;
    public Animator playerAnime;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameScript gameScript;


    private Vector2 direction;
    private BowScript bow;
    private bool recovering;
    private float recoveringCounter;
    private bool facingRight = true;



    // Start is called before the first frame update
    void Start()
    {
        bow = FindObjectOfType<BowScript>();
    }

    // Update is called once per frame
    void Update(){

        direction.y = Input.GetAxisRaw("Vertical");
        direction.x = Input.GetAxisRaw("Horizontal");

        playerAnime.SetFloat("Speed", Mathf.Abs(direction.x) + Mathf.Abs(direction.y));

        Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        if (dir.x > 0 && !facingRight || dir.x < 0 && facingRight){
            Flip();
        }

        if (Input.GetMouseButtonDown(0)){
            bow.Shoot();
        }
        if (recovering){
            recoveringCounter += Time.deltaTime;
            if(recoveringCounter >= recoveringTime){
                recoveringCounter = 0;
                recovering = false;
            }
        }       
         
    }

    private void FixedUpdate(){
        playerRb.MovePosition(playerRb.position + (direction * moveSpeed * Time.fixedDeltaTime));
    }

        public void TakeDamage(int damage){
            if (!recovering){
                recovering = true;
                health -= damage;
                UpdateHealthUI(health);

                if (health <= 0){
                    Destroy(gameObject);
                    gameScript.Die();
                }
            }
        }

    private void Flip(){
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void UpdateHealthUI(int currentHealth){
        for(int i = 0; i < hearts.Length; i++){
            if(i < currentHealth){
                hearts[i].sprite = fullHeart;
            }
            else{
                hearts[i].sprite = emptyHeart;
            }
        }
    }
}
