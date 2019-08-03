using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    public float magnitude;
    bool shake = false;
    int shakeTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //added this line to keep the game from erroring out after a game over
        if (GameController.gameController.game_state == GameController.GAME_STATE.IN_GAME)
        {
            if (!shake)
            {
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
                //set the X and Y to the player's location
            }
            else
            {
                //if the camera is shaking, do this fancy method
                float ShakeX = Random.Range(1f, 2f) * magnitude;
                float ShakeY = Random.Range(1f, 2f) * magnitude;
                if (shakeTimer % 2 == 0)
                {
                    ShakeX = -ShakeX;
                }
                else
                {
                    //every other frame, we invert the shake value so that it actually looks like it shakes
                    ShakeY = -ShakeY;
                }
                //set the value like normal, except we add our random stuff as well to offset it
                transform.position = new Vector3(player.transform.position.x + ShakeX, player.transform.position.y + ShakeY, -10);

                //now we tick down our frame counter
                shakeTimer -= 1;
                if (shakeTimer == 0)
                {
                    shake = false;
                }
            }

        }
    }

    public void CameraShake(int frames)
    {
        //this method can be called from other objects since it's public.
        //that call tells us how many frames to shake the camera.
        shake = true;
        shakeTimer = frames;
    }
}
