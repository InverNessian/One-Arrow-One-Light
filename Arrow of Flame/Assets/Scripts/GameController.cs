using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //public static GameController gameController;
    //public enum GAME_STATE { MAIN_MENU, CUTSCENE, IN_GAME, GAME_OVER, LEVEL_WIN }
    //public GAME_STATE game_state;
    //public GameObject gameOverUI;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    private void Start()
    {
        //game_state = GAME_STATE.MAIN_MENU;
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
    public static void LoadSceneStatic(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
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

