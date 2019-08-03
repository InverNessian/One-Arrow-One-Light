using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Transform Player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = UnityEngine.Vector3.MoveTowards(transform.position, Player.position, speed*Time.deltaTime);
    }
}
