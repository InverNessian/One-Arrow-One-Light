using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    //variables
    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {

        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioManager.Stop("WowBoss");
            audioManager.Stop("Basic");
            audioManager.Stop("WowDanger");
            audioManager.Stop("Darkness");
            audioManager.Play("EndMusic");
            GameObject.Find("GameController").GetComponent<GameController>().LoadScene(5);
        }
    }
}
