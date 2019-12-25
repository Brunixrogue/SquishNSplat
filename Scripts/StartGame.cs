using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{

    //Start Button -- Loads game level 1
    public void GameStart()
    {
        //Loads game after delay
        StartCoroutine(LoadAfterDelay("Level1"));
        Time.timeScale = 1;
        //Set kills = 0
    }

    IEnumerator LoadAfterDelay(string levelName)
    {
        // wait 1 second
        yield return new WaitForSeconds(1.2f);
        Application.LoadLevel("Level1");

    }

}
