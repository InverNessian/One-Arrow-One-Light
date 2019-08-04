using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenWall : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow") && !collision.gameObject.GetComponent<ArrowController>().attached)
        {
            anim.SetBool("Hit", true);
            Destroy(gameObject,1);
        }
    }

}
