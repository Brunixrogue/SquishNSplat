using UnityEngine;
using System.Collections;

public class FlySpawner : MonoBehaviour {
		
		public enum ScreenEdge {LEFT, RIGHT, TOP, BOTTOM};
		private ScreenEdge screenEdge;
		public float yOffset;
		public float xOffset;
		
		public float minSpawnTime;
		public float maxSpawnTime;
		
		public Transform Cube;
		public GameObject flyPrefab;

		private int flysNum;
		private int maxFlys;
		public static bool flysDead;
		
		private bool isTop;
		

		
		void Start() {
		if (Application.loadedLevel == 1) {
			flysDead = true;
			maxFlys = 0;
			flysNum = 0;
		}
		if (Application.loadedLevel == 2) {
			flysDead = true;
			maxFlys = 0;
			flysNum = 0;
		}
		if (Application.loadedLevel == 3) {
			flysDead = false;
			BugController.flysDead = 0;
			maxFlys = 15;
			flysNum = 0;
		}
		if (Application.loadedLevel == 4) {
			flysDead = false;
			BugController.flysDead = 0;
			maxFlys = 20;
			flysNum = 0;
		}
        if (Application.loadedLevel == 5)
        {
            flysDead = false;
            BugController.flysDead = 0;
            maxFlys = 20;
            flysNum = 0;
        }

        Invoke("moveSpawn", minSpawnTime);
			
			
		}
		
		
		//Moves the spawner to a random edge of the screen and Instantiates a Beetle Spawn.
		void moveSpawn () {
			
			Vector3 newPosition = transform.position;
			Camera camera = Camera.main;
			
			ScreenEdge screenEdge = (ScreenEdge)Random.Range (0, 4);
			
			// 2
			switch (screenEdge) {
				// 3
			case ScreenEdge.RIGHT:
				newPosition.x = camera.aspect * camera.orthographicSize + xOffset;
				newPosition.y = yOffset;
				isTop = false;
				break;
				
				// 4
			case ScreenEdge.TOP:
				newPosition.y = camera.orthographicSize + yOffset;
				newPosition.x = xOffset;
				isTop = true;
				break;
				
			case ScreenEdge.LEFT:
				newPosition.x = -camera.aspect * camera.orthographicSize + xOffset;
				newPosition.y = yOffset;
				isTop = false;
				break;
				
			case ScreenEdge.BOTTOM:
				newPosition.y = -camera.orthographicSize + yOffset;
				newPosition.x = xOffset;
				isTop = true;
				break;
			}
			// 5
			transform.position = newPosition;
			spawnFly ();
			
			Invoke("moveSpawn", Random.Range(minSpawnTime, maxSpawnTime));
			
			
			
		}
		
		
		//Spawns an object at the spawner with a random x or y range depending on the edge of the screen.
		void spawnFly ()
		{
			if (flysNum < maxFlys) {

			flysNum ++;
			
			float yMax = Camera.main.orthographicSize;
			float xMax = Camera.main.aspect * Camera.main.orthographicSize;

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
				randomX = Random.Range (-xMax, xMax);
				randomY = yMax;
			}
			if (randomVar == 3) {
				randomX = Random.Range (-xMax, xMax);
				randomY = -yMax;
			}
			
			Vector3 flyPosLeftRight = 
				new Vector3 (randomX,randomY, transform.position.z);
			
			Vector3 flyPosTopBottom = 
				new Vector3 (Random.Range (-xMax, xMax),
				             Cube.position.y,
				             transform.position.z);
			if (isTop == true) {
				Instantiate (flyPrefab, flyPosTopBottom, Quaternion.identity);
			} else if (isTop == false) {
				Instantiate (flyPrefab, flyPosLeftRight, Quaternion.identity);
				
			}

			}
			
		}
		
		
		
		
		
		
		void Update () {
		if (BugController.flysDead >= maxFlys) {
			flysDead = true;
			}
		}
		
		
		
		
	}