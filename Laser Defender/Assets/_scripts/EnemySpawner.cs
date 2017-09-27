﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float enemySpeed = 5;
    public GameObject playerPrefab;
    public GameObject playerWeapon;
    public float width = 16;
    public float height = 8;
    
    private float xMin;
    private float xMax;

    private bool movingRight = false;
    

	// Use this for initialization
	void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftBoundry = Camera.main.ViewportToWorldPoint(new Vector3(0.03f, 0, distance));
        Vector3 rightBoundry = Camera.main.ViewportToWorldPoint(new Vector3(0.97f, 0, distance));
        xMin = leftBoundry.x;
        xMax = rightBoundry.x;

        foreach (Transform child in transform){
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
	}

    public void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    // Update is called once per frame
    void Update() {
        if(movingRight){
            transform.position += Vector3.right * enemySpeed * Time.deltaTime;
        } else{
            transform.position += Vector3.left * enemySpeed * Time.deltaTime;
        }


        float leftFormation = transform.position.x - (0.5f * width);
        float rightFormation = transform.position.x + (0.5f * width);

        if(leftFormation < xMin) {
            movingRight = true;
        }   else if(rightFormation > xMax) {
            movingRight = false;
            
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
    }
}
