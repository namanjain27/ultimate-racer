using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cp_reach_signal : MonoBehaviour
{
    public checkpoint_manager manager;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            manager.reached = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            
        }
    }
}
