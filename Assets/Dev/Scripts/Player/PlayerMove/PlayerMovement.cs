using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public FloatingJoystick joystick;
    public float movementSpeed;
    public GameObject playerModel;
    public PlayerAnimController anim;

    public bool isMove;
    private void Update()
    {
        Movement();
    }

    void RunRotate()
    {
        if (joystick.Horizontal == 0 || joystick.Vertical == 0) return;
        Vector3 movement = new Vector3(joystick.Horizontal, 0.0f, joystick.Vertical);
        playerModel.transform.rotation = Quaternion.LookRotation(movement);
    }


    public void SetRunAnim()
    {
        float totalSpeed = Mathf.Abs(joystick.Vertical) + Mathf.Abs(joystick.Horizontal);
        
        if (totalSpeed == 0)
        {
            anim.SetAnimBool("Run", false);
            anim.SetAnimBool("Walk", false);
            isMove = false;
            return;
        }

        if (!isMove)
        {
            isMove = true;
        }
        if (totalSpeed <= 0.6f)
        {
            anim.SetAnimBool("Run", false);
            anim.SetAnimBool("Walk", true);
            return;
        }
        

        anim.SetAnimBool("Run", true);
        anim.SetAnimBool("Walk", false);
    }


    public void Movement()
    {
        transform.Translate(new Vector3(joystick.Horizontal * movementSpeed, 0,
            joystick.Vertical * movementSpeed));
        RunRotate();
        SetRunAnim();
    }
}