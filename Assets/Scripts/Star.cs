using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
         Debug.Log("collision");

        if (collision.collider.tag == "Player")
        {
            Debug.Log("Player collision");
            Destroy(this.gameObject);
        }
    }
}
