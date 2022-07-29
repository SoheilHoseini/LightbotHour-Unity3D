using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] List<MoveActions> inputActions = new List<MoveActions>();
    [SerializeField] List<GameObject> LevelsContainer = new List<GameObject>();
    [SerializeField] float speed;

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
        transform.position += transform.forward * Time.deltaTime * speed;
        Debug.LogWarning(transform.forward.ToString());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            Debug.Log("Hit the wall");
            speed = 0; // Stop the player to avoid it from shaking
        }
    }


}
