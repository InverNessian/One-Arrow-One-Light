using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    //public variables
    public GameObject door;
    public Sprite OpenDoor;
    public Animator anim;

    private void Start()
    {

        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //do anything else we want
            door.GetComponent<BoxCollider2D>().isTrigger=true;
            door.GetComponent<SpriteRenderer>().sprite = OpenDoor;
            anim.SetBool("LeverPushed", true);
        }
    }
}
