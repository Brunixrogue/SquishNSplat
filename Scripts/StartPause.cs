using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class StartPause : MonoBehaviour {

	public GameObject pausePrefab;
	private Camera camera;
	private float cameraX;
	private float cameraY;
	public static bool canClick;
	public static bool isPaused;
	// Use this for initialization
	void Start () {
		isPaused = false;
		canClick = true;
		camera = Camera.main;
		cameraX = (camera.aspect * camera.orthographicSize) / 2;
		cameraY = camera.orthographicSize - 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	void OnMouseDown() {
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (Physics2D.OverlapCircle (mousePosition, 50f) && canClick) {
			GameObject pauseWindow = Instantiate (pausePrefab, new Vector3(0, 0, pausePrefab.transform.position.z), Quaternion.identity) as GameObject;
			pauseWindow.transform.SetAsLastSibling();
			pauseWindow.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
			Time.timeScale = 0;
			canClick = false;
			isPaused = true;
		}
	}

}
