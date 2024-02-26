using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomlessPitDamage : MonoBehaviour
{

    HealthManager healthManager; 

    public int damageToGive;

    // Start is called before the first frame update
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        damageToGive = healthManager.getCurrentHealth();
        Debug.Log(damageToGive);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 hitDirection = other.transform.position - this.transform.position;
            hitDirection = hitDirection.normalized;
            healthManager.HurtPlayer(damageToGive, hitDirection);
        }
    }
}
