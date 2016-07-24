using UnityEngine;
using System.Collections;

public class DestroyOnHit : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)  //The Collider2D other is the thing we have collided with. 
    {
        Destroy(other.gameObject);  //we are finding from the collider called other the gameObject we collided into and then in this line we are going to tell Unity to destroy that gameObject for us. 
    }
}
