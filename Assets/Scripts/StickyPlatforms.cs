using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatforms : MonoBehaviour
{

    public Rigidbody rb;
    public CharacterController cc;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.transform.parent = transform;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.transform.parent = null;
        }
       
    }
}
