using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour   {
//    static MusicPlayer instance = null;
    public float speed = 5.0f;
    public GameObject enemyPrefab;
    public GameObject projectile;
    public float fireRate = 0.1f;
    public float weaponSpeed = 13.0f;
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
        GameObject lazer = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
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
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
		else if (Input.GetKey(KeyCode.RightArrow)){
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        float newX = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

}



