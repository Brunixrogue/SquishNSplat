using UnityEngine;
using System.Collections;

public class BugSpawner : MonoBehaviour {

    private float minSpawnTime; //private since we will only edit this in the script
    private float maxSpawnTime;
    public Transform hill;
    public GameObject bugPrefab; 
	public GameObject hillPrefab;
	public static int hillDeaths;
	public static int maxBug;
	public float hillScaleX;
	public float hillScaleY;
	private int bugNum = 0;
    // Use this for initialization
    void Start()
    {
		hillScaleX = gameObject.transform.localScale.x;
		hillScaleY = gameObject.transform.localScale.y;
        //Level 1 Spawning
        if (Application.loadedLevel == 1)
        {
			hillDeaths = 0;
			maxBug = 3;
            minSpawnTime = 1.0f;
            maxSpawnTime = 6.0f;
        }
        //Level 2 Spawning
        if (Application.loadedLevel == 2)
        {
			hillDeaths = 0;
			maxBug = 6;
            minSpawnTime = 0.5f;
            maxSpawnTime = 8.0f;
        }
        //Level 3 Spawning
        if (Application.loadedLevel == 3)
        {
			hillDeaths = 0;
			maxBug = 5;
            minSpawnTime = 1.0f;
            maxSpawnTime = 9.0f;
        }
        //Level 4 Spawning
        if (Application.loadedLevel == 4)
        {
			hillDeaths = 0;
			maxBug = 13;
            minSpawnTime = 0.75f;
            maxSpawnTime = 5.0f;
        }


        Invoke("SpawnBug", minSpawnTime);
        
    }

    void SpawnBug()
    {

		if (bugNum < maxBug) {
			bugNum++;
			Instantiate (bugPrefab, new Vector3(hill.position.x, hill.position.y, hill.position.z -3), Quaternion.identity);

			Invoke ("SpawnBug", Random.Range (minSpawnTime, maxSpawnTime));
		}
	
    }

    // Update is called once per frame
    void Update () {
		if(bugNum==maxBug){
			hillDeaths++;
			hillScaleX -= 0.01f;
			hillScaleY -= 0.01f;
			gameObject.transform.localScale = new Vector3(hillScaleX, hillScaleY, 1);
			if(hillScaleX <= 0 && hillScaleY <= 0){
				Destroy (gameObject);
			}

		}
	}

}
