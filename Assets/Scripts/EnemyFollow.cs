using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{ 
    public Transform targetObj;
    public float moveSpeed = 8.0f;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(this.transform.position, targetObj.transform.position) < 20)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, moveSpeed * Time.deltaTime);

        }

    }
}
