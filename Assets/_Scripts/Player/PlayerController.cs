using System;
using UnityEngine;
using UnityEngine.XR;

namespace _Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        private InputManager _input;
        private CharacterController _controller;
        private AnimationHandler _animationHandler;
        private float minX = -9.5f;
        private float maxX = 9.5f;
        private float minZ = -2.5f;
        private float maxZ = 2.5f;
        private Vector3 previousPosition;
        private Vector3 velocity;
        private Vector3 movDir;


        //camera location(transforms)
        [SerializeField] private float speed = 5f;

        [SerializeField] private float rotationSpeed = 10f;
        
        
        private void Start()
        {
            _input = InputManager.instance;
            _controller = GetComponent<CharacterController>();
            _animationHandler = GetComponent<AnimationHandler>();
            _animationHandler.Initialize();
            previousPosition = transform.position;
        }

        private void Update()
        {
            HandleMovement(Time.deltaTime);
            HandleRotation(Time.deltaTime);
            _animationHandler.UpdateAnimatorValues(_input.Move.x, _input.Move.y);
            Vector3 currentPosition = transform.position;
            currentPosition.y = 0;
            currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);
            currentPosition.z = Mathf.Clamp(currentPosition.z, minZ, maxZ);
            transform.position = currentPosition;
            LookWayMoving();

        }

        private void LookWayMoving()
        {
            Vector3 direction = (transform.position - previousPosition).normalized;
            previousPosition = transform.position;
            if (direction.magnitude > 1)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation =
                    Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }


        }

        private void HandleMovement(float delta)
        {
            movDir = (_input.Move.x * transform.right) + (_input.Move.y * transform.forward);
            _controller.Move(movDir * speed * delta);
        }

        private void HandleRotation(float delta)
        {
            Vector3 targetDir;
            targetDir = transform.forward * _input.Move.y;
            targetDir += transform.right * _input.Move.x;
            targetDir.Normalize();

            targetDir.y = 0;

            if (targetDir == Vector3.zero)
            {
                targetDir = transform.forward;
            }

            Quaternion targetRot = Quaternion.LookRotation(targetDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * delta);
        }
    }
    
    
}