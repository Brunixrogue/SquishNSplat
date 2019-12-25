using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {
	public GameObject AudioObject;
    public static bool winAndAlive;

	// Use this for initialization
	void Start () {
		AudioObject = GameObject.Find("MusicHandler");
        winAndAlive = false;
		Time.timeScale = 1;

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Delete)){
			Application.LoadLevel(Application.loadedLevel +1);
		}
		if (Application.loadedLevel == 1) {
			if (HillSpawner.hillsDead) {
                //LoadLevel is now handled in the WinMenu script
                //When winAndAlive is true, the WinMenu script will be called
                winAndAlive = true;
				HillSpawner.hillsDead = false;
			}
		}
		if (Application.loadedLevel == 2) {
			if ((HillSpawner.hillsDead && BeetleSpawner.beetlesDead) || Input.GetKeyDown(KeyCode.Delete)){
                winAndAlive = true;
				HillSpawner.hillsDead = false;
				BeetleSpawner.beetlesDead = false;
            }
		}
		if (Application.loadedLevel == 3) {
			if ((HillSpawner.hillsDead && BeetleSpawner.beetlesDead && FlySpawner.flysDead) || Input.GetKeyDown(KeyCode.Delete)) {
                winAndAlive = true;
				HillSpawner.hillsDead = false;
				BeetleSpawner.beetlesDead = false;
				FlySpawner.flysDead = false;
            }
				
		}
		if (Application.loadedLevel == 4) {
			if ((HillSpawner.hillsDead && BeetleSpawner.beetlesDead && FlySpawner.flysDead) || Input.GetKeyDown(KeyCode.Delete)) {
				HillSpawner.hillsDead = false;
				BeetleSpawner.beetlesDead = false;
				FlySpawner.flysDead = false;
				Destroy (AudioObject);
                winAndAlive = true;
            }
			
		}
		if (Application.loadedLevel == 5) {
			if (BossController.bossDeath >= 2) {
				Destroy (AudioObject);
				winAndAlive = true;
			}
		}

	}
}

