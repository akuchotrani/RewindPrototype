using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse : MonoBehaviour
{
    private ArrayList Movements = new ArrayList();
   // private ArrayList Velocity = new ArrayList();

    private int counter = 0;
    private bool isRewinding = false;
    BoxCollider2D collider;
   // Rigidbody2D rigidbody;
    private void Start()
    {
        //rigidbody = this.GetComponent<Rigidbody2D>();
        collider = this.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (isRewinding == false)
        {
            Movements.Add(transform.position);
            //Velocity.Add(rigidbody.velocity);
            counter++;
        }

        if (Input.GetKey(KeyCode.R))
        {
            isRewinding = true;
            RewindTime();
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            isRewinding = false;
        }

    }


    void RewindTime()
    {
        counter--;
        if (counter > 0)
        {
            collider.isTrigger = false;
            transform.position = (Vector3)Movements[counter];
            //rigidbody.velocity = (Vector2)Velocity[counter];
            Movements.RemoveAt(counter);
           // Velocity.RemoveAt(counter);
        }
    }

}
