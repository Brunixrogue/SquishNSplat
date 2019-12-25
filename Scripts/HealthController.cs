using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {

	public float scaleX;
	public float scaleY;
	public float scaleZ;
	private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		sr.color = Color.green;
		scaleX = transform.localScale.x;
		scaleY = transform.localScale.y;
		scaleZ = transform.localScale.z;
	}
	
	// Update is called once per frame
	void Update () {
		scaleX = GoalController.hp*0.20f;
		if (scaleX <= 0) {
			scaleX = 0;
		}
		if(scaleX > .33 && scaleX <= .66) {
			sr.color = Color.yellow;
		}
		if(scaleX <= .33){
			sr.color = Color.red;
		}
		transform.localScale = new Vector3 (scaleX, scaleY, scaleZ);
	}
}
