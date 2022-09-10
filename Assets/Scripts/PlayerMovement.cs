using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed, turnSpeed;
    public FloatingJoystick variableJoystick;
    private Vector3 direction;
    private Animator playerAnim;

    private void Awake()
    {
        playerAnim = gameObject.transform.GetChild(0).GetComponent<Animator>();
    }

    public void FixedUpdate()
    {
        direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        transform.position+=direction * Time.deltaTime * speed;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.fixedDeltaTime);
        // rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        if(variableJoystick.Vertical != 0 || variableJoystick.Horizontal != 0)
        {
            playerAnim.SetBool("Run", true);
        }
        else
        {
            playerAnim.SetBool("Run", false);
        }
        if (direction.z < 0)
        {
            speed = 7;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bridge"))
        {
            if (gameObject.transform.GetChild(0).GetComponent<StackScript>().StackCollectable.Count == 0)
            {
                if (direction.z > 0)
                {
                    speed = 0;
                    playerAnim.SetBool("Run", false);
                }
                else
                {
                    speed = 7;
                }
            }
        }
    }

}
