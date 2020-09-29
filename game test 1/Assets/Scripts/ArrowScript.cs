using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float arrowLifeTime;
    public float arrowSpeed;
    public float arrowDamage;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, arrowLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * arrowSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Enemy")){
            Destroy(gameObject);
            collision.GetComponent<EnemyScript>().TakeDamage(arrowDamage);
        }
        if (collision.CompareTag("EnemyRange")){
            Destroy(gameObject);
            collision.GetComponent<EnemyRangeScript>().TakeDamage(arrowDamage); 
        }
        if (collision.CompareTag("Boss")){
            Destroy(gameObject);
            collision.GetComponent<BossScript>().TakeDamage(arrowDamage);
        }
    }
}
