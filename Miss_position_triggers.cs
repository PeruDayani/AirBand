using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miss_position_triggers : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Missed!!!");
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
