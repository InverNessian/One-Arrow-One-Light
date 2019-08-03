using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject player;
    BoxCollider2D boxCollider;
    public bool attached;
    bool pickup;
    public float speed; //since speed is a public variable, you can set its value from the editor

    UnityEngine.Vector3 target;
    UnityEngine.Vector3 mousePos;
    UnityEngine.Vector3 direction;
    private float angle;
    void Start()
    {
        //set initial values
        player = GameObject.FindGameObjectWithTag("Player");
        boxCollider = GetComponent<BoxCollider2D>();
        attached = true;
        pickup = false;
      
    }

    void Update()
    {
        // check for input and if it's attached to the player
        if (Input.GetButtonDown("Fire1") && attached)
        {
            //if it is attached, detach it and add velocity
            attached = false;
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;
            direction = target - transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = UnityEngine.Quaternion.AngleAxis(angle, UnityEngine.Vector3.forward);
         }

        if (transform.position != target)
        {
            
            transform.position = UnityEngine.Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
           
            pickup = true;
        }
        //track player position while attached
        if (attached)
        {
            transform.position = player.transform.position;
        }

       
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when the arrow collides with the player, if it's a pickup it reattaches
        if (pickup && collision.name.Equals("Character"))
        {
            attached = true;
            pickup = false;
        }

        //when the arrow collides with anything other than the character, if it's not attached it stops moving
        if (!attached && !collision.name.Equals("Character"))
        {
            GetComponentInParent<Rigidbody2D>().velocity = UnityEngine.Vector2.zero;
            pickup = true;
        }

        if (!attached && collision.CompareTag("Wall"))
        {
            target = transform.position;
        }

    }
}
