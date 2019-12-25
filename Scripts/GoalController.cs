using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {

	public static int hp; //health of goal
	public static bool isAlive; //Check if goal is still alive

	// Use this for initialization
	void Start () {
		hp = 5;
		isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Gets called by the Attack() function from bugcontroller whenever it attacks
	public static void isAttacked(int damage)
	{
		hp -= damage;
		Debug.Log ("Goal Health = " + hp);
		//Animation + Sound
		//HP Bar Change
		deadCheck ();
	}


	public static void deadCheck()
	{
		if (hp <= 0)
		{
			isAlive = false;
			Debug.Log("isAlive set to false! Game Over");
            
		}


	}



}
