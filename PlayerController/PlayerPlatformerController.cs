using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerPlatformerController Script by Pycrypt

public class PlayerPlatformerController : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    [SerializeField] private GameObject graphic;
    [SerializeField] private Animator animator;
    [SerializeField] private bool jumping;
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip[] stepSounds;
    [SerializeField] private AudioClip[] jumpSounds;

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        if(graphic){
            if (move.x > 0.01f)
            {
                if (graphic.transform.localScale.x == -1)
                {
                    graphic.transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                }
            }
            else if (move.x < -0.01f)
            {
                if(graphic.transform.localScale.x == 1)
                {
                    graphic.transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                }
            }
        }

        if(animator)
        {
            animator.SetBool("grounded", grounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
        }

        targetVelocity = move * maxSpeed;
    }

    void Footstep()
    {
        if(audio)
        {
            audio.PlayOneShot(stepSounds[Random.Range(0,stepSounds.Length)]);
            Debug.Log("playFootstep");
        }
    }

    void Jump()
    {
        if(audio)
        {
            audio.PlayOneShot(jumpSounds[Random.Range(0,jumpSounds.Length)]);
            Debug.Log("playJumpSounds");
        }
    }
}
