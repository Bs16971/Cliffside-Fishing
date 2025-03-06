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
    private Vector3 velocity;
    private Vector3 targetPosition;
    private Vector3 currentVelocity;
    private bool caughtFish = false;
    private float hookSpeed = 2f;
    
    
    
   
    
    void Start()
    {
        _input = InputManager.instance;
        if (_controller == null)
        {
            _controller = GetComponent<CharacterController>();
        }
        GameObject targetObject = GameObject.FindGameObjectWithTag("TargetPos");

        
            targetPosition = targetObject.transform.position;

            caughtFish = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (caughtFish)
        {
            MovePlayer2();
        }
        else
        {
            
            HandleMovement(Time.deltaTime);
        }  

    }

    private void HandleMovement(float delta)
    {
        // create a movement vector that is RELATIVE TO THE DIRECTION THE PLAYER IS FACING
        
        Vector3 movdir = (_input.Move.x * transform.right) + (_input.Move.y * transform.forward) + (_input.Up.y * transform.up);
        // tell the controller to move
        _controller.Move(movdir * (hookSpeed * delta));
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fish"))
        {
            
            //this.enabled = false;
            //Invoke(nameof(MovePlayer2), 5f);
            caughtFish = true;
            
        }
    }

   

    void MovePlayer2()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, targetPosition);
        if (distance > 0.1f)
        {
            
            _controller.Move(direction * 2f * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                caughtFish = false;
            }
        }
    }
    
    

    
}
