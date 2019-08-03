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
    // Start is called before the first frame update
    void Start()
    {
        speed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0) * speed * Time.deltaTime;
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
