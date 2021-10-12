using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lap_count : MonoBehaviour
{
    public GameObject full_trigger;
    public GameObject half_trigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            half_trigger.SetActive(false);
            full_trigger.SetActive(true);
        }
    }
}
