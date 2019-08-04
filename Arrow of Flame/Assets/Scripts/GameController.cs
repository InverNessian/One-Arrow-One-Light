using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //public static GameController gameController;
    //public enum GAME_STATE { MAIN_MENU, CUTSCENE, IN_GAME, GAME_OVER, LEVEL_WIN }
    //public GAME_STATE game_state;

    public GameObject transitionUI;


    // Start is called before the first frame update
    void Awake()
    {
        
    }

    private void Start()
    {
        StartCoroutine(EndTransition());
    }

    private void Update()
    {
        //this allows any key to advance from the cutscene
        //if (Input.anyKey)
        //{
            //game_state = GAME_STATE.IN_GAME;
        //    LoadScene(2);
        //}
    }

    IEnumerator EndTransition()
    {
        //after we load the new scene, set it to inactive so we can click other button UIs
        yield return new WaitForSeconds(1.2f);
        transitionUI.SetActive(false);
    }

    IEnumerator SceneLoad(int scene)
    {
        //this method actually does all the heavy lifting
        //we find the transition image
        transitionUI.SetActive(true);
        transitionUI.GetComponent<Animator>().SetBool("Exit", true);
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(scene);
    }


    public void LoadScene(int sceneIndex)
    {
        //this is a nice pretty method that our buttons can call
        StartCoroutine(SceneLoad(sceneIndex));
    }

    public void GameOver()
    {
        //set the game state to game over and show the game over UI
        //game_state = GAME_STATE.GAME_OVER;
        //gameOverUI.SetActive(true);
        //gameOverUI.transform.position = Vector3.zero;
    }

    public static void ExitGame()
    {
        Application.Quit();
    }

    /*
    public void SetGameState(int code)
    {
        //this function allows our buttons to change the game state on click
        //since they normally can only call functions with simple parameters when clicked
        switch (code)
        {
            case 0:
                game_state = GAME_STATE.MAIN_MENU;
                break;
            case 1:
                game_state = GAME_STATE.CUTSCENE;
                break;
            case 2:
                game_state = GAME_STATE.IN_GAME;
                break;
            case 3:
                game_state = GAME_STATE.GAME_OVER;
                break;
            case 4:
                game_state = GAME_STATE.LEVEL_WIN;
                break;
        }
    }
    */
}

