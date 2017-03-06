using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoost : MonoBehaviour {

    public GameObject player;
    public int Boost;
    private Rigidbody2D playerRigidbody;
    public GameObject enemy;


	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigidbody = player.GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
       
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.collider.tag == "Player")
        {

            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, playerRigidbody.velocity.y + Boost);
            if (enemy.GetComponent<SpriteRenderer>().enabled == true)
            {
                //Disable the sprite
                enemy.GetComponent<SpriteRenderer>().enabled = false;

                //Disable the scripts 
                enemy.GetComponent<Reverse>().enabled = false;
                enemy.GetComponent<Enemy>().enabled = false;

            }

            else
            {
                enemy.GetComponent<SpriteRenderer>().enabled = true;

                enemy.GetComponent<Reverse>().enabled = true;
                enemy.GetComponent<Enemy>().enabled = true;
            }
                
          
                  
        }
    }
}
