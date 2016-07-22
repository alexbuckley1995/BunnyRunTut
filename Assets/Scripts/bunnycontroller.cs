using UnityEngine;
using System.Collections;

public class bunnycontroller : MonoBehaviour {

    private Rigidbody2D myrigidbody;
    public float bunnyjumpforce = 500f;

	// Use this for initialization
	void Start () {
        myrigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetButtonUp("Jump"))
        {
            myrigidbody.AddForce(transform.up * bunnyjumpforce);
        }
	}
}
