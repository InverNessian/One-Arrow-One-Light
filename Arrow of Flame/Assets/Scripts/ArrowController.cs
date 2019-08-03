using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject parent;
    BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.FindGameObjectWithTag("Player");
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && transform.parent != null)
        {
            transform.parent = null;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                
        }
    }

    private void FireArrow()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = parent.transform.position;
        transform.parent = parent.transform;
    }
}
