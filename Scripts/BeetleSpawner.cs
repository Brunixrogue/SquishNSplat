using UnityEngine;
using System.Collections;

public class BeetleSpawner : MonoBehaviour {

public float minSpawnTime;
public float maxSpawnTime;
public GameObject beetlePrefab;
private int beetleNum;
private int maxBeetle;
public static bool beetlesDead;

// Use this for initialization
void Start () {
		beetleNum = 0;
		Invoke("SpawnBeetle", minSpawnTime);

		if (Application.loadedLevel == 1) {
			beetlesDead = true;
			maxBeetle = 0;
			beetleNum = 0;
		}
		if (Application.loadedLevel == 2) {
			beetlesDead = false;
			maxBeetle = 15;
			beetleNum = 0;
		}
		if (Application.loadedLevel == 3) {
			beetlesDead = false;
			maxBeetle = 7;
			beetleNum = 0;
		}
		if (Application.loadedLevel == 4) {
			beetlesDead = false;
			maxBeetle = 20;
			beetleNum = 0;
		}
        if (Application.loadedLevel == 5)
        {
            beetlesDead = false;
            maxBeetle = 25;
            beetleNum = 0;
        }
    }

void SpawnBeetle()
{

		if (beetleNum < maxBeetle) {
			beetleNum++;
			// 1
			Camera camera = Camera.main;
			Vector3 cameraPos = camera.transform.position;
			float xMax = camera.aspect * camera.orthographicSize;
			float xRange = camera.aspect * camera.orthographicSize * 1.75f;
			float yMax = camera.orthographicSize - 0.5f;
			int randomVar = Random.Range (0, 3);
			float randomX = 0;
			float randomY = 0;
			if (randomVar == 0) {
				randomX = xMax;
				randomY = Random.Range (-yMax, yMax);
			}
			if (randomVar == 1) {
				randomX = -xMax;
				randomY = Random.Range (-yMax, yMax);
			}
			if (randomVar == 2) {
				randomX = cameraPos.x + Random.Range (xMax - xRange, xMax);
				randomY = yMax;
			}
			if (randomVar == 3) {
				randomX = cameraPos.x + Random.Range (xMax - xRange, xMax);
				randomY = -yMax;
			}
	
			// 2
			Vector3 beetlePos = new Vector3 (randomX, randomY, beetlePrefab.transform.position.z);
	
			// 3

			Instantiate (beetlePrefab, beetlePos, Quaternion.identity);
			Invoke ("SpawnBeetle", Random.Range (minSpawnTime, maxSpawnTime));
		}
	
}


	void Update () {
		if (BugController.beetlesDead >= maxBeetle) {
			beetlesDead = true;
			Debug.Log ("BEETLESTRUE");
		}
	}




}
