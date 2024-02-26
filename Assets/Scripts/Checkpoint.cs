using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public HealthManager healthManager;

    public Renderer renderer;

    public Material cpOff;
    public Material cpOn;

    [SerializeField] AudioSource checkpointSound;

    // Start is called before the first frame update
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckpointOn()
    {
        Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();
        foreach(Checkpoint checkpoint in checkpoints)
        {
            checkpoint.CheckpointOff();
        }

        renderer.material = cpOn;
    }

    public void CheckpointOff()
    {
        renderer.material = cpOff;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            checkpointSound.Play();
            healthManager.SetSpawnPoint(transform.position);
            CheckpointOn();
        }
    }
}
