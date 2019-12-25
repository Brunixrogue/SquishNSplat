using UnityEngine;
using System.Collections;

public class HillController : MonoBehaviour {

    public float hp;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Death()
    {     
        Destroy(gameObject);
    }




}
