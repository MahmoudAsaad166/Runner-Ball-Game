using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
  public float  speed=10;
    public float powerJump = 3;
    Vector3 MoveDiriction;
    float gravty = 6.8f;
    CharacterController controller;

         

    // Update is called once per frame
    void Update()
    {
        controller = GetComponent<CharacterController>();

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float ydiriction = MoveDiriction.y;
        MoveDiriction = transform.right * horizontal + transform.forward * vertical;


        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            MoveDiriction.y = powerJump;
        }
        else
            MoveDiriction.y = ydiriction;

        if(  !controller.isGrounded )
        {
            MoveDiriction.y -= gravty*Time.deltaTime;
        }

        controller.Move(MoveDiriction * speed * Time.deltaTime);


    }
}
