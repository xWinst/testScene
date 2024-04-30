using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{/*
    Writen by Windexglow 11-13-10.  Use it, edit it, steal it I don't care.  
    Converted to C# 27-02-13 - no credit wanted.
    Simple flycam I made, since I couldn't find any others made public.  
    Made simple to use (drag and drop, done) for regular keyboard layout  
    wasd : basic movement
    shift : Makes camera accelerate
    space : Moves camera on X and Z axis only.  So camera doesn't gain any height*/


    float mainSpeed = 0.25f; //regular speed
    float camSens = 0.25f; //How sensitive it with mouse
    private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)
    // private float totalRun = 1.0f;

    void Update()
    {

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            lastMouse = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            lastMouse = Input.mousePosition - lastMouse;
            lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
            lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
            transform.eulerAngles = lastMouse;
            lastMouse = Input.mousePosition;
        }


        if (Input.GetMouseButton(1))
        {
            lastMouse -= Input.mousePosition;

            transform.Translate(lastMouse * mainSpeed * Time.deltaTime);
            lastMouse = Input.mousePosition;
        }

        Vector3 p = GetBaseInput();

        p.z += Input.mouseScrollDelta.y * 3;

        transform.Translate(p * mainSpeed * 10 * Time.deltaTime);


    }



    private Vector3 GetBaseInput()
    { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            p_Velocity += new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            p_Velocity += new Vector3(0, -1, 0);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Vector3 rotation = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - camSens * 2, 0);
            transform.eulerAngles = rotation;
        }
        if (Input.GetKey(KeyCode.E))
        {
            Vector3 rotation = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + camSens * 2, 0);
            transform.eulerAngles = rotation;
        }
        if (Input.GetKey(KeyCode.R))
        {
            Vector3 rotation = new Vector3(transform.eulerAngles.x - camSens * 2, transform.eulerAngles.y, 0);
            transform.eulerAngles = rotation;
        }
        if (Input.GetKey(KeyCode.F))
        {
            Vector3 rotation = new Vector3(transform.eulerAngles.x + camSens * 2, transform.eulerAngles.y, 0);
            transform.eulerAngles = rotation;
        }
        return p_Velocity;
    }

}
