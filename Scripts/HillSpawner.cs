using UnityEngine;
using System.Collections;

public class HillSpawner : MonoBehaviour {

    private float minSpawnTime; //private since we will only edit this in the script
    private float maxSpawnTime;
    private int maxHill;
	private int hillNum;
    private int hillcounter;
    public GameObject hillPrefab;
	public static bool hillsDead;
	public GameObject goal;
    
    //2    
    void Start()
    {
		goal = GameObject.FindGameObjectWithTag ("goal");
        //Level 1 Spawning
        if (Application.loadedLevel == 1)
        {
            //Set max hills to 3
			hillsDead = false;
			BugController.antsDead = 0;
            maxHill = 7;
			hillNum = 0;
            hillcounter = maxHill;
            minSpawnTime = 0.5f;
            maxSpawnTime = 5.0f;
        }
        //Level 2 Spawning
        if (Application.loadedLevel == 2)
        {
            //Set max hills to 4
			hillsDead = false;
			BugController.antsDead = 0;
            maxHill = 4;
			hillNum = 0;
            hillcounter = maxHill;
            minSpawnTime = 1.0f;
            maxSpawnTime = 14.0f;
        }
        //Level 3 Spawning
        if (Application.loadedLevel == 3)
        {
            //Set max hills to 5
			hillsDead = false;
			BugController.antsDead = 0;
            maxHill = 5;
			hillNum = 0;
            hillcounter = maxHill;
            minSpawnTime = 1.0f;
            maxSpawnTime = 12.0f;
        }
        //Level 4 Spawning
        if (Application.loadedLevel == 4)
        {
            //Set max hills to 6
			hillsDead = false;
			BugController.antsDead = 0;
            maxHill = 6;
			hillNum = 0;
            hillcounter = maxHill;
            minSpawnTime = 1.0f;
            maxSpawnTime = 11.0f;
        }
       

        Invoke("SpawnHill", minSpawnTime);
    }

    //3
    void SpawnHill()
    {
		hillNum++;
		// 1
		Camera camera = Camera.main;
		Vector3 cameraPos = camera.transform.position;
		float xMax = camera.aspect * camera.orthographicSize;
		float xRange = camera.aspect * camera.orthographicSize * 1.75f;
		float yMax = camera.orthographicSize - 0.5f;
		float xMinRight = goal.transform.position.x + 4f;
		float yMinRight = goal.transform.position.y + 4f;
		float xMinLeft = goal.transform.position.x - 4f;
		float yMinLeft = goal.transform.position.y - 4f;
		//Left and Right stand for position in Random.Range(*,*)
		float possibleXLeft = Random.Range (xMax - xRange, xMinLeft);
		float possibleXRight = Random.Range (xMinRight, xMax);
		float possibleYLeft = Random.Range (-yMax, yMinLeft);
		float possibleYRight = Random.Range (yMinRight, yMax);
		float randomX = cameraPos.x + Random.Range (possibleXLeft, possibleXRight);
		float randomY = Random.Range (possibleYLeft, possibleYRight);

		//Replace randomX and Y with range outside of goal
		if (randomX < 0) {
			randomX = possibleXLeft;
		}
		if (randomX >= 0) {
			randomX = possibleXRight;
		}
		if (randomY < 0) {
			randomY = possibleYLeft;
		}
		if (randomY >= 0) {
			randomY = possibleYRight;
		}

        // 2
        Vector3 hillPos = new Vector3(randomX,randomY, hillPrefab.transform.position.z);

        // 3 -- If the number of hills are not yet zero, spawn more
        if (hillcounter >= 1)
        {
            Instantiate(hillPrefab, hillPos, Quaternion.identity);
            Invoke("SpawnHill", Random.Range(minSpawnTime, maxSpawnTime));
            hillcounter--;
        }

    }


    // Update is called once per frame
    void Update () {
		if (hillNum >= maxHill && BugController.antsDead == (maxHill * BugSpawner.maxBug)) {
			hillsDead = true;
		}
	}
}
