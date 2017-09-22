using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private bool hasStarted = false;
    private Vector3 paddleToBallVector;

    // init with ball and paddle offset 
    void Start() {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
    }

    void Update()   {
        if (!hasStarted)    { 
            this.transform.position = paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButtonDown(0))    {
                Debug.Log("Launch Skull");

                // Rigidbody2D differes from course "this.rigidbody2d.velocity" is obsolete.
                hasStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 15f);
            }
        }
    }
}
