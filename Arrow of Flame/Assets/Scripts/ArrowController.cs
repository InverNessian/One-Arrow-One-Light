using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject player;
    BoxCollider2D boxCollider;
    bool attached;
    bool pickup;
    public float speed; //since speed is a public variable, you can set its value from the editor
    Vector3 target;


    void Start()
    {
        //set initial values
        player = GameObject.FindGameObjectWithTag("Player");
        boxCollider = GetComponent<BoxCollider2D>();
        attached = true;
        pickup = false;
        target = Vector3.zero;
    }

    void Update()
    {
        // check for input and if it's attached to the player
        if (Input.GetButtonDown("Fire1") && attached)
        {
            //if it is attached, detach it and add velocity
            attached = false;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 velocity = new Vector2((mousePos.x - player.transform.position.x)*speed, (mousePos.y - player.transform.position.y)*speed);
            GetComponentInParent<Rigidbody2D>().AddForce(velocity);

            float newAngle = Vector2.Angle(new Vector2(mousePos.x, mousePos.y), new Vector2(player.transform.position.x, player.transform.position.y));
            
            //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Debug.Log(Vector2.Angle(new Vector2(mousePos.x, mousePos.y), new Vector2(player.transform.position.x, player.transform.position.y)));
            //this is for finding the new angle we need to rotate the arrow, so that it's facing the right direction as it fires
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
            GetComponentInParent<Rigidbody2D>().velocity = Vector2.zero;
            pickup = true;
        }

    }
}
