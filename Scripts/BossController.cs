using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {


	public Transform target;
	public float moveSpeed;
	public int health;
	public int damage;
	private bool isAttacking = false;
	public static bool bossDead = false;
	public static int bossDeath;
	private bool collided;
	public GameObject bossDeathPrefab;
	private Rigidbody2D rb;
	public Camera camera;
	public Vector3 cameraPos;
	public float xMax;
	public float xRange;
	public float yMax;
	public float xMinRight;
	public float yMinRight;
	public float xMinLeft;
	public float yMinLeft;
	public float possibleXLeft;
	public float possibleXRight;
	public float possibleYLeft;
	public float possibleYRight;
	public float randomX;
	public float randomY;
	public bool moveNewPos = false;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("goal").transform;
		rb = GetComponent<Rigidbody2D> ();
		float step = moveSpeed * Time.deltaTime;
		//ROTATION
		float angle = Mathf.Atan2(target.position.y - transform.position.y,target.position.x - transform.position.x)*Mathf.Rad2Deg + 180;
		Quaternion rotation = new Quaternion ();
		rotation.eulerAngles = new Vector3(0,0,angle-90);
		transform.rotation = rotation;
		//END ROTATION
		if (!moveNewPos) {
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);
		}

	}
	
	// Update is called once per frame
	void Update () {
		//ROTATION
		float angle = Mathf.Atan2(target.position.y - transform.position.y,target.position.x - transform.position.x)*Mathf.Rad2Deg + 180;
		Quaternion rotation = new Quaternion ();
		rotation.eulerAngles = new Vector3(0,0,angle-90);
		transform.rotation = rotation;
		//END ROTATION

		float step = moveSpeed * Time.deltaTime;
		if (!moveNewPos) {
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);
		

			camera = Camera.main;
			cameraPos = camera.transform.position;
			xMax = camera.aspect * camera.orthographicSize;
			xRange = camera.aspect * camera.orthographicSize * 1.75f;
			yMax = camera.orthographicSize - 0.5f;
			xMinRight = target.position.x + 4f;
			yMinRight = target.position.y + 4f;
			xMinLeft = target.position.x - 4f;
			yMinLeft = target.position.y - 4f;
			//Left and Right stand for position in Random.Range(*,*)
			possibleXLeft = Random.Range (xMax - xRange, xMinLeft);
			possibleXRight = Random.Range (xMinRight, xMax);
			possibleYLeft = Random.Range (-yMax, yMinLeft);
			possibleYRight = Random.Range (yMinRight, yMax);
			randomX = cameraPos.x + Random.Range (possibleXLeft, possibleXRight);
			randomY = Random.Range (possibleYLeft, possibleYRight);
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
		}
		if (moveNewPos) {
			Vector3 newPos = new Vector3(randomX, randomY, transform.position.z);
			transform.position = Vector3.MoveTowards(transform.position, newPos, moveSpeed * 3);
			if(Mathf.Abs (Vector3.Distance (transform.position, newPos)) < 1f){
				moveNewPos = false;
			}
		}

	}

	void OnMouseDown() {
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		if (Physics2D.OverlapCircle (mousePosition, 50f)) {
			if(health >= 1) //If health is not 0, then each click takes off one health
			{
				health -= 1;
				AudioSource audio = GetComponent<AudioSource>();
				if (!audio.isPlaying){
				audio.Play();
				}
				moveNewPos = true;

			}
			if (health == 0) //If health is 0, bug dies
			{

				Instantiate (bossDeathPrefab, transform.position, transform.rotation);
				Death ();
			}
		}
		
		
	}



	IEnumerator OnTriggerEnter2D(Collider2D other)
	{

			if (other.gameObject.tag == "goal") {
				collided = true;
				Debug.Log ("Collided is" + collided);
				yield return new WaitForSeconds (2);
				if (collided) {
					Attack ();
		
				}


			}

	}


	void OnTriggerExit2D(Collider2D other)
	{
		collided = false;

	}






	/*
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "goal") {
			//Debug.Log("Trigger Attack Mode");
			Attack ();
		}
	}
	
	*/
	
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


	void Death() {
		Destroy (gameObject);
		bossDeath += 1;
	}
}
