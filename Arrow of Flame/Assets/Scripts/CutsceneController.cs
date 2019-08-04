using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
    public GameObject collar;
    public GameObject cave;
    public GameObject button;

    private void Start()
    {
        StartCoroutine(Transition());
    }


    IEnumerator Transition()
    {
        //after we load the new scene, set it to inactive so we can click other button UIs
        yield return new WaitForSeconds(7f);
        cave.GetComponent<Animator>().SetBool("Transition", true);
        Debug.Log(cave.GetComponent<Animator>().GetBool("Transition"));
        yield return new WaitForSeconds(1f);
        cave.GetComponent<Animator>().SetBool("Pan", true);
        button.SetActive(true);
    }


}
