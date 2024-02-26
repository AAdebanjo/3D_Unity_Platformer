using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    int currentScore;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Hit")
        {
            ++currentScore;
            Debug.Log("You've bumped into a thing this many times: " + currentScore);
        }
    }
}
