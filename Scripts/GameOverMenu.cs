using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {

    public GameObject gameOverMenuCanvas;
	public GameObject winMenuCanvas;
	public GameObject AudioObject;

	
	// Update is called once per frame
	void Update () {
		Debug.Log (winMenuCanvas);
        //If isAlive is false, then isGameOver is true
		if(GoalController.isAlive == false)
        {
            gameOverMenuCanvas.SetActive(true);
			winMenuCanvas.SetActive(false);
			LevelController.winAndAlive = false;
            Time.timeScale = 0;
        }
        //else, isGameOver is false
        else
        {
            gameOverMenuCanvas.SetActive(false);
            

        }
    }

    public void YesRetry()
    {



        //***Change to load level 1****
        //Check Level and load that level
        if (Application.loadedLevel == 1)
        {
            Application.LoadLevel("Level1");

        }
        if (Application.loadedLevel == 2)
        {
            Application.LoadLevel("Level2");

        }
        if (Application.loadedLevel == 3)
        {
            Application.LoadLevel("Level3");

        }
        if (Application.loadedLevel == 4)
        {
            Application.LoadLevel("Level4");

        }
		if (Application.loadedLevel == 5)
		{
			Application.LoadLevel("Level5");

		}
    }

    public void NoRetry()
    {
        //Go to main menu
		AudioObject = GameObject.Find("MusicHandler");
		Destroy (AudioObject);
		GoalController.isAlive = true;
		Time.timeScale = 1;
        Application.LoadLevel("Main Menu");

    }
}
