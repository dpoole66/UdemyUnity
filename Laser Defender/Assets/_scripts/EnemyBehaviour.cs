using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
    
    public GameObject playerOneWeapon;
    public float health = 500.0f;
    
    void OnStart() {
           
    }

    void OnTriggerEnter2D(Collider2D collider) {
       
        Projectile myHit = playerOneWeapon.GetComponent<Projectile>();


        //Note, This is what I found worked on v.2017. Replaceing "Projectile missile =". 
        if (myHit) {
            health -= myHit.GetComponent<Projectile>().GetDamage();
            Debug.Log(health);
            if (health <= 0){
                Destroy(gameObject);
            }
            
        }
    }
   
}
    

