using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_position_triggers : MonoBehaviour {

    private bool collision_bool = false;
    private GameObject collision_object = null;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hit!");
        collision_bool = true;
        collision_object = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Exit!");
        collision_bool = false;
        collision_object = null;
    }

    public bool collision_occuring()
    {
        return collision_bool;
    }

    public GameObject collision_gameobject()
    {
        return collision_object;
    }
    
}
