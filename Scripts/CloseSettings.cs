using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CloseSettings : MonoBehaviour {
	GameObject settingsWindow;
	// Use this for initialization
	void Start () {
		
		
	}
	
	
	// Update is called once per frame
	void Update () {
		settingsWindow = GameObject.FindGameObjectWithTag ("settings");
	}
	
	void OnMouseDown() {
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (Physics2D.OverlapCircle (mousePosition, 50f)) {
			Destroy (settingsWindow);
		}
	}
}
