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

        //camera location(transforms)
        [SerializeField] private float speed = 5f;

        [SerializeField] private float rotationSpeed = 10f;
        
        
        private void Start()
        {
            _input = InputManager.instance;
            _controller = GetComponent<CharacterController>();
            _animationHandler = GetComponent<AnimationHandler>();
            _animationHandler.Initialize();
        }

        private void Update()
        {
            HandleMovement(Time.deltaTime);
            HandleRotation(Time.deltaTime);
            _animationHandler.UpdateAnimatorValues(_input.Move.x, _input.Move.y);
            Vector3 currentPosition = transform.position;
            currentPosition.y = 0;
            transform.position = currentPosition;
            
        }

        private void HandleMovement(float delta)
        {
            Vector3 movDir = (_input.Move.x * transform.right) + (_input.Move.y * transform.forward);
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