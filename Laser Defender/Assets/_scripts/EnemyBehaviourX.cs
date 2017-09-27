using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyBehaviourX : MonoBehaviour {
 
public interface ICustomeMessageTarget : IEventSystemHandler {
        void Message1();
}
  
public class CustomMessageTarget : MonoBehaviour, ICustomeMessageTarget {
        public void Message1() {
            Debug.Log("Message 1 recieved");
        }
}

    void OnStart() {
       // BlueLazerOne.GameObject.GetComponent<Projectile>();    
    }

    void OnTriggerEnter2D(Collider2D collider) {

        //Note, This is what I found worked on v.2017. Replaceing "Projectile missile =". 
        if (collider.gameObject.GetComponent<Collider2D>()) {

            Debug.Log("I'm the Enmemy and I have been Hit.");
        }
    }
   
}
    

