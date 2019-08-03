using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController gameController;

    // Start is called before the first frame update
    void Awake()
    {
        //this allows us to set a "singleton", a gameobject that will persist even when we load new scenes.
        //there will only ever be one instance of this object
        if (gameController != null && gameController != this)
        {
            Destroy(this.gameObject);
        }
        gameController = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}
