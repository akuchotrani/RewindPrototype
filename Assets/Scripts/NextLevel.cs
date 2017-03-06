using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour {

    public static int index = 1;
  
	// Use this for initialization
	void Start () {
  
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("player collided");
       
        if (collision.collider.tag == "Player")
        {
            if (index < 7)
            {
                SceneManager.LoadScene(index);

            }
        }
        ++index;
    }
}
