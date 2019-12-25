using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    public float startingTime;
    private Text theText;
    //private PauseMenu thePauseMenu;

	// Use this for initialization
	void Start () {

        theText = GetComponent<Text>();

        //thePauseMenu = FindObjectOfType<PauseMenu>();
	}
	
	// Update is called once per frame
	void Update () {
        //If pause menu is paused
        //return;

        startingTime -= Time.deltaTime; 
        theText.text = "" + Mathf.Round(startingTime);

        //If time == 0, then load next scene
        if(startingTime == 0)
        {
            //Check if 
            //Check current scene
            //If scene is not last scene, then load next scene
            //If scene is last, go to main menu
        }
	}
}
