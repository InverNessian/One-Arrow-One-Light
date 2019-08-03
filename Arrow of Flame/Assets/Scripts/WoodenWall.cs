using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow") && !collision.gameObject.GetComponent<ArrowController>().attached)
        {
            Destroy(gameObject);
        }
    }

}
