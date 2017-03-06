using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSprite : MonoBehaviour {

    public bool isPicked = false;
	// Use this for initialization
	void Start (){}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse down");
            isPicked = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("mouse up");
            isPicked = false;
        }

        if (isPicked == true)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            transform.position = mousePos;
        }
	}
}
