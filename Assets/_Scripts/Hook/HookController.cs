using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private InputManager _input;
    private CharacterController _controller;
    [SerializeField] private int UpDownSpeed = 5;
    
    
    [SerializeField] private float speed = 5;
    private 
    void Start()
    {
        _input = InputManager.instance;
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement(Time.deltaTime);
       
    }

    private void HandleMovement(float delta)
    {
        // create a movement vector that is RELATIVE TO THE DIRECTION THE PLAYER IS FACING
        
        Vector3 movdir = (_input.Move.x * transform.right) + (_input.Move.y * transform.forward) + (_input.Up.y * transform.up);
        // tell the controller to move
        _controller.Move(movdir * (speed * delta));
    }

    
}
