using UnityEngine;
using System.Collections;

public class FlyController : MonoBehaviour {

	public float moveSpeed = -2.0f;
	public int damage = 1;
	private bool isAttacking = false;
	private Transform target;
	//public GoalController goal;
	
	//public Vector3 moveDirection;
	//float step = moveSpeed * Time.deltaTime;
	
	
	
	// Use this for initialization
	void Start () {
		//moveDirection = new Vector3(0, 0, 0);
		target = GameObject.FindGameObjectWithTag("goal").transform;
		float step = moveSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		
		//StartCoroutine (Attack());
		
		
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 currentPosition = transform.position;
		
		//TODO Movement Function toward the x and y position of goal object
		//OnClick death and remove object  (consider object pooling)
		float step = moveSpeed * Time.deltaTime;
		
		//Vector3 target = moveDirection * moveSpeed + currentPosition;
		//transform.position = Vector3.Lerp(currentPosition, target, Time.deltaTime);
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		
	}
	
	void OnMouseDown() {
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		if (Physics2D.OverlapCircle (mousePosition, 50f)) {
			
			Death();
			
		}
		//Move mouse controls to gamecontroller
		//Death Animation
		//Death Sound (Might go in Death()
		//Death();
		
	}
	
	void OnHit() {
		//IF hit this will trigger from the gamecontroller
		//reduce hp until 0 then call Death()
	}
	
	void Death() {
		Destroy (gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "goal") {
			//Debug.Log("Trigger Attack Mode");
			Attack ();
		}
	}
	
	
	
	void Attack()
	{
		//Set the isAttacking flag to true, wait for 2 seconds (attack speed) call isAttacked on goalcontroller then loop until the object dies
		isAttacking = true;
		//Debug.Log ("Attack Mode");
		
		//yield return new WaitForSeconds (2);
		
		//Debug.Log ("Waited 2 seconds and DEbugged");
		GoalController.isAttacked(damage);
		Destroy (gameObject);
		//Attack ();
		
	}
}
