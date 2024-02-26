using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    //public Rigidbody rb;
    [SerializeField] public float moveSpeed = 10f;
    [SerializeField] public float jumpAmount = 35f;
    public CharacterController controller;

    private Vector3 moveDirection;
    [SerializeField] public float gravityScale;

    public float knockBackForce;
    public float knockBackTime; //how much time will be knocked back for
    private float knockBackCounter; //value used to control whether player is knocked back, and how long the knockback will last

    [SerializeField] AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        //rb = this.gameObject.GetComponent<Rigidbody>();
        controller = this.gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {

        if (knockBackCounter <= 0) //if player is not being knocked back
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);

            if (controller.isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    jumpSound.Play();
                    moveDirection.y = jumpAmount;
                }
            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime; //timer is counting downwards
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void Knockback(Vector3 direction)
    {
        knockBackCounter = knockBackTime;

        //direction = new Vector3(1f, 1f, 1f);

        moveDirection = direction * knockBackForce;
        moveDirection.y = knockBackForce; //ensures that the player will be knocked back into the air upon taking a hit
    }
}