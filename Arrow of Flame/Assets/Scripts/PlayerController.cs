using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int normalSpeed=3;
    private int speed;
    public int health = 3;
    public int speedBoost =5;
    public float invulnerability = 2f;
    private float invulnerabilityTimer;
    private Vector3 MoveTarget;
    private Vector3 direction;
    private float angle;
    private Quaternion lastRot;
    private bool moving;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        speed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            MoveTarget = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0) * speed * Time.deltaTime;
            direction =  transform.position;
            transform.position += MoveTarget;
            direction -= transform.position;
            anim.SetBool("IsMoving", true);
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg+90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            lastRot = transform.rotation;
        }else
        {
            transform.rotation = lastRot;
            anim.SetBool("IsMoving", false);
        }
        invulnerabilityTimer -= Time.deltaTime;
        if (invulnerabilityTimer <= 0)
        {
            speed = normalSpeed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && invulnerabilityTimer <= 0)
        {
            health -= 1;
            invulnerabilityTimer = invulnerability;
            speed = speedBoost;
            if (health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
