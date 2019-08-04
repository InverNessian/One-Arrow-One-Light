using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogNamer : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GetComponentInParent<Text>().text = PlayerPrefs.GetString("dogName");
    }

    public void ConfirmName()
    {
        //store the value of the text field in PlayerPrefs
        string temp = GetComponentInParent<Text>().text;
        if (temp.Equals("")){
            temp = "nice try ;)"; //if anyone tries to be cheeky and leave it blank
        }
        PlayerPrefs.SetString("dogName", temp);
    }
}
