using UnityEngine;
using System.Collections;

public class WinMenu : MonoBehaviour {

    public GameObject winMenuCanvas;
    public GameObject AudioObject;

    void Update () {
        if (LevelController.winAndAlive == true)
        {
			Debug.Log ("WHY WIN");
            winMenuCanvas.SetActive(true);
            Time.timeScale = 0;
			Debug.Log ("WIN");
        }
        //else, isGameOver is false
        else
        {
			if(!StartPause.isPaused){
			Time.timeScale = 1;
			}
            winMenuCanvas.SetActive(false);

        }
    }

    public void NextLevel()
    {
        LevelController.winAndAlive = false;
        Time.timeScale = 1;

        //If the loaded level is not the last level, load the next level
        if(Application.loadedLevel <= 4)
        {
           Application.LoadLevel(Application.loadedLevel + 1);

        }
       
        if (Application.loadedLevel == 5)
        {
            Application.LoadLevel("Main Menu");
        }
    }

    public void QuitMenu()
    {
        //Go to main menu
        AudioObject = GameObject.Find("MusicHandler");
        Destroy(AudioObject);

		Time.timeScale = 1;
        Application.LoadLevel(0);
		LevelController.winAndAlive = false;
        
    }

}
