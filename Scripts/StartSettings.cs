using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartSettings : MonoBehaviour {

	public GameObject settingsPrefab;
	public GameObject menuCanvas;


	// Use this for initialization
	void Start () {

		Camera camera = Camera.main;

		Vector3 cameraPos = camera.transform.position;

		Button settingsBtn = gameObject.GetComponent<Button> ();
		settingsBtn.onClick.AddListener (delegate() {
			GameObject settingsWindow = Instantiate (settingsPrefab, new Vector3(cameraPos.x,cameraPos.y,settingsPrefab.transform.position.z), Quaternion.identity) as GameObject;
			settingsWindow.transform.parent = menuCanvas.transform;
		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
