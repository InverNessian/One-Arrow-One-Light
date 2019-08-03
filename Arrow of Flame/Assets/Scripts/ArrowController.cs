using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject player;
    BoxCollider2D boxCollider;
    bool attached;
    bool pickup;
    float speed = 5f;
    Vector3 target;


    // Start is called before the first frame update
    void Start()
    {
        //set initial values
        player = GameObject.FindGameObjectWithTag("Player");
        boxCollider = GetComponent<BoxCollider2D>();
        attached = true;
        pickup = false;
        target = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // check for input and if it's attached to the player
        if (Input.GetButtonDown("Fire1") && attached)
        {
            //if it is attached, detach it and modify position, then set as pickup
            attached = false;
            Debug.Log(Input.mousePosition);
            transform.position += new Vector3(1,0,0);
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
    }
}
