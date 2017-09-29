using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject enemyWeapon;
    public float fireRate = 2.0f;
    public float weaponSpeed = 3.0f;
    public float health = 500.0f;
    public int scoreValue = 100;
    public GameObject playerWeapon;

    

    void Start(){
        GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    void OnTriggerEnter2D(Collider2D collision) {

        LazerOne myHit = playerWeapon.GetComponent<LazerOne>();
        
        Destroy(collision.gameObject);
        

        
        //Note, This is what I found worked on v.2017. Replaceing "Projectile missile =". 
        if (myHit) {
            health -= myHit.GetComponent<LazerOne>().GetDamage();
            Debug.Log("Hit Enemy Health = " + health);
            if (health <= 0) {
                Destroy(gameObject);
            }

        }
    }

    void EnemyFire() {
        GameObject enemylazer = Instantiate(enemyWeapon, transform.position, Quaternion.Euler(0, 180, 0)) as GameObject;
        enemylazer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -weaponSpeed);
    }

    void Update() {

        float probability = Time.deltaTime * fireRate;

        if (Random.value < probability) {
            EnemyFire();
        }

        

    }


}
