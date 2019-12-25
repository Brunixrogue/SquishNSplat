using UnityEngine;
using System.Collections;

public class BugController : MonoBehaviour {

    public float moveSpeed;
	public int damage;
    public int health; //health of bug
	private bool isAttacking = false;
	private Transform target;
    public static int killCount;
	public static int beetlesDead;
	public GameObject bloodPrefab;
	public GameObject bugDeadPrefab;
	public GameObject beetleDeadPrefab;
	public GameObject flyDeadPrefab;
	public static int flysDead;
	public static int antsDead;
	//public GoalController goal;

    //public Vector3 moveDirection;
    //float step = moveSpeed * Time.deltaTime;



    // Use this for initialization
    void Start () {
        //moveDirection = new Vector3(0, 0, 0);
        target = GameObject.FindGameObjectWithTag("goal").transform;
		float step = moveSpeed * Time.deltaTime;
		//ROTATION
		float angle = Mathf.Atan2(target.position.y - transform.position.y,target.position.x - transform.position.x)*Mathf.Rad2Deg;
		Quaternion rotation = new Quaternion ();
		rotation.eulerAngles = new Vector3(0,0,angle-90);
		transform.rotation = rotation;
		//END ROTATION


        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

		//StartCoroutine (Attack());


    }

    // Update is called once per frame
    void Update () {
        //Vector3 currentPosition = transform.position;

		//ROTATION
		float angle = Mathf.Atan2(target.position.y - transform.position.y,target.position.x - transform.position.x)*Mathf.Rad2Deg;
		Quaternion rotation = new Quaternion ();
		rotation.eulerAngles = new Vector3(0,0,angle-90);
		transform.rotation = rotation;
		//END ROTATION


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
            if(health >= 1) //If health is not 0, then each click takes off one health
            {
                health -= 1;
            }
            if (health == 0) //If health is 0, bug dies
            {
                Death();
                killCount += 1;
            }
		}
		

    }

	void OnHit() {
		//IF hit this will trigger from the gamecontroller
		//reduce hp until 0 then call Death()
	}

    void Death() {
		Destroy (gameObject);
		if (gameObject.tag == "bug") {
			antsDead++;
			Instantiate (bloodPrefab,  new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 2f), gameObject.transform.rotation);
			Instantiate (bugDeadPrefab,  new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 1f), gameObject.transform.rotation);

		}
		if (gameObject.tag == "beetle") {
			beetlesDead++;
			Destroy (gameObject);

			Instantiate (beetleDeadPrefab,  new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 1f), gameObject.transform.rotation);
			Instantiate (bloodPrefab,  new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 2f), gameObject.transform.rotation);
		}
		if (gameObject.tag == "fly") {
			flysDead++;
			Destroy (gameObject);

			Instantiate (flyDeadPrefab,  new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 1f), gameObject.transform.rotation);
			Instantiate (bloodPrefab,  new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 2f), gameObject.transform.rotation);
		}
        
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
		if (gameObject.tag == "bug") {
			antsDead++;
		}
		if (gameObject.tag == "beetle") {
			beetlesDead++;
		}
		if (gameObject.tag == "fly") {
			flysDead++;
		}
		Destroy (gameObject);
		//Attack ();

	}


}
