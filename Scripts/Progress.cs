using UnityEngine;
using System.Collections;

public class Progress : MonoBehaviour {
	public GameObject healthBarPrefab;
	private GameObject goal;
	private GUIStyle currentStyle = null;
	void Start() {
		goal = GameObject.FindGameObjectWithTag ("goal");

		Instantiate (healthBarPrefab, new Vector3 (goal.transform.position.x, goal.transform.position.y - 2f, 9), Quaternion.identity);
		

	}

}