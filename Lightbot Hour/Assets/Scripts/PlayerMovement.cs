using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] List<MoveActions> inputActions = new List<MoveActions>();
    [SerializeField] List<GameObject> LevelsContainer = new List<GameObject>();
    [SerializeField] float speed;
    
    // There are five different moving actions
    public enum MoveActions
    {
        Forward,
        Jump,
        LightUp,
        RotateLeft,
        RotateRight
    }

    void Start()
    {
    }

    void Update()
    {
        //transform.Translate(transform.right * speed * Time.deltaTime);
        //Debug.LogWarning(transform.forward.ToString());

        if(Input.GetKeyDown(KeyCode.Space))
        {
            MoveForward();
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            MoveBackward();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            TurnLeft();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            TurnRight();
        }
    }

    private void MoveBackward()
    {
        transform.position -= transform.forward * speed;
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            Debug.Log("Hit the wall");
            speed = 0; // Stop the player to avoid it from shaking
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }

        // Keep the player from flowing in the air when it hits the normal cubes
        if (collision.gameObject.tag == "NormalCube")
        {
            Debug.Log("Hit Normal Cube");
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }
    }

    // To make the player move forward
    public void MoveForward()
    {
        Debug.Log("Initial Position: " + transform.position.ToString());
        transform.position += transform.forward * speed;
        Debug.Log("Final Position: " + transform.position.ToString());
    }

    // To make the player turn 90 degrees counter-clockwise
    public void TurnLeft()
    {
        transform.Rotate(0,-90,0);
        Debug.Log("Rotate Left!");
    }

    // To make the player turn 90 degrees clockwise
    public void TurnRight()
    {
        transform.Rotate(0, 90, 0);
        Debug.Log("Rotate Right!");
    }

    // To make the player jump up and forward(simultaneously)
    public void Jump()
    {

    }

    // When the player gets to a goal cube, it can light up and go to the next state
    public void LightUp()
    {

    }
}
