using UnityEngine;
using System.Collections;

public class TableAddGravity : MonoBehaviour {


   

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        
	}

    void OnTriggerEnter() {

        if (tag == "Player")
            Debug.Log("Hej");
    }
}
