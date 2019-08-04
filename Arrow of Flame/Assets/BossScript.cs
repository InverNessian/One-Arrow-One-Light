using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public Collider2D Room;
    public Transform player;
    public float speed = 3;
    public int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (UnityEngine.Vector2.Distance(transform.position, player.transform.position) < 10)
        {

            transform.position = UnityEngine.Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }



    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow") && !collision.gameObject.GetComponent<ArrowController>().attached)
        {
            health -= 1;
            if (health <= 0)
            {
                Camera.main.GetComponent<CameraController>().CameraShake(8);
                Destroy(gameObject);
            }
        }

    }
}

