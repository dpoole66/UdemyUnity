using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour   {
    //    static MusicPlayer instance = null;
    //    public GameObject enemyShip;
    public float playerSpeed;
    public GameObject playerWeapon;
    public float fireRate = 0.01f;
    public float weaponSpeed = 3.0f;

    public GameObject enemyWeapon;

    public float health = 500.0f;
    float xMin;
    float xMax;

    void Start(){
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0.03f, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(0.97f, 0, distance));
        xMin = leftMost.x;
        xMax = rightMost.x;
    }

    void Fire(){
        GameObject lazer = Instantiate(playerWeapon, transform.position, Quaternion.identity) as GameObject;
        lazer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, weaponSpeed);
    }

	void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            InvokeRepeating("Fire", 0.001f, fireRate);
        }

        if(Input.GetKeyUp(KeyCode.Space)){
            CancelInvoke("Fire");
        }

		if (Input.GetKey (KeyCode.LeftArrow)) {
            transform.position += Vector3.left * playerSpeed * Time.deltaTime;
        }
		else if (Input.GetKey(KeyCode.RightArrow)){
            transform.position += Vector3.right * playerSpeed * Time.deltaTime;
        }

        float newX = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }


    void OnTriggerEnter2D(Collider2D collision) {

        LazerOne enemyHit = enemyWeapon.GetComponent<LazerOne>();

        Destroy(collision.gameObject);

        //Note, This is what I found worked on v.2017. Replaceing "Projectile missile =". 
        if (enemyHit) {
            health -= enemyHit.GetComponent<LazerOne>().GetDamage();
            Debug.Log("Player Health = " + health);
            if (health <= 0) {
                Destroy(gameObject);
            }

        }
    }

}



