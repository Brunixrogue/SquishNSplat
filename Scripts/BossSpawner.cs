using UnityEngine;
using System.Collections;

public class BossSpawner : MonoBehaviour {

	public GameObject bossPrefab;
	Camera cam;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		float randomX = 0;
		float randomY = 0;
		float maxY = cam.orthographicSize - 0.5f;
		float maxX = cam.aspect * cam.orthographicSize;
		int randomVar = Random.Range (0, 2);
		if (randomVar == 0) {
			randomX = -maxX;
			randomY = maxY;
		}
		if (randomVar == 1) {
			randomX = maxX;
			randomY = -maxY;
		}
		if (randomVar == 2) {
			randomX = maxX;
			randomY = maxY;
		}
		Instantiate (bossPrefab, new Vector3(randomX, randomY, 0), Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
