using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] List<MoveActions> inputActions = new List<MoveActions>();

    void Start()
    {
        
    }

    void Update()
    {

    }

    public enum MoveActions
    {
        Forward,
        Jump,
        LightUp,
        RotateLeft,
        RotateRight
    }

}
