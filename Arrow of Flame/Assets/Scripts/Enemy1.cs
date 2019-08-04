using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;


public class Enemy1 : MonoBehaviour
{
    public Collider2D Room;
    public Transform player;
    public float speed = 3;
    private UnityEngine.Vector3 RandoPos;
    public float randomMoveTimer=1;
    private float randomMoveTimerCounter=0;
    private UnityEngine.Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (UnityEngine.Vector2.Distance(transform.position, player.transform.position) < 5)
        {
            
            
                transform.position = UnityEngine.Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        
       /* else
        {
            if (randomMoveTimerCounter <= 0)
            {
                RandoPos = new UnityEngine.Vector3(transform.position.x + Random.Range(-1, 1.1f), transform.position.y + Random.Range(-1, 1.1f), 0);
                randomMoveTimerCounter = randomMoveTimer;
            }
            
            
                transform.position = UnityEngine.Vector3.MoveTowards(transform.position, RandoPos, speed * Time.deltaTime);
                
            
            randomMoveTimerCounter -= Time.deltaTime;
        } */
        
      
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow") && !collision.gameObject.GetComponent<ArrowController>().attached)
        {
            //this lets us shake the camera for 4 frames when we kill an enemy
            Camera.main.GetComponent<CameraController>().CameraShake(4);
            Destroy(gameObject);
        }

    }
}
