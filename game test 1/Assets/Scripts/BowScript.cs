using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScript : MonoBehaviour{

    public Transform player;
    public float offset = 1f;
    public bool canShoot;
    public Transform ArrowPoint;
    public float shotCooldown = .5f;
    public GameObject arrow;

    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update(){
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Vector3 playerToMouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.position;
        playerToMouseDir.z = 0;
        transform.position = player.position + (offset * playerToMouseDir.normalized);
    }

    public void Shoot(){
        if(canShoot){
            Instantiate(arrow, ArrowPoint.position, ArrowPoint.rotation);

            StartCoroutine(ShootCooldown());
        }
    }
    IEnumerator ShootCooldown(){
        canShoot = false;

        yield return new WaitForSeconds(shotCooldown);

        canShoot = true;
    }
}
