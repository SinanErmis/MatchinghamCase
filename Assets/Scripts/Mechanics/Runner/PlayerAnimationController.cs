using System;
using System.Collections;
using UnityEngine;

namespace Rhodos.Mechanics.Runner
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private float inputNormalizationFactorForAnimation = 20f;
        [SerializeField] private float horizontalMovementSmoothingFactor = 10f;
        
        private static readonly int ForwardMovementHash = Animator.StringToHash("ForwardMovement");
        private static readonly int HorizontalMovementHash = Animator.StringToHash("HorizontalMovement");
        private float _horizontalMovement;
        private bool _isHorizontalMovementSetThisFrame;
        public void HandleHorizontalAnimation(float horizontalMovement)
        {
            var normalizedHorizontalMovement = horizontalMovement / inputNormalizationFactorForAnimation;
            
            _horizontalMovement = Mathf.Lerp(_horizontalMovement, normalizedHorizontalMovement,
                Time.deltaTime * horizontalMovementSmoothingFactor);
            
            _horizontalMovement = Mathf.Clamp(_horizontalMovement, -1f, 1f);
            
            SetHorizontalMovement(_horizontalMovement);
            _isHorizontalMovementSetThisFrame = true;
        }
        private void SetHorizontalMovement(float normalizedAmount)
        {
            animator.SetFloat(HorizontalMovementHash, normalizedAmount);
        }
        public void SetForwardMovement(bool isMoving)
        {
            animator.SetFloat(ForwardMovementHash, isMoving ? 1f : 0f);
        }

        public void SetTrigger(Trigger trigger)
        {
            animator.SetTrigger(trigger.ToString());
        }

        //todo: rewrite this logic in a more elegant way
        private void LateUpdate()
        {
            if (_isHorizontalMovementSetThisFrame)
            {
                //set the variable to false so that the next frame movement will be interpolated to 0
                _isHorizontalMovementSetThisFrame = false;
                return;
            }
            
            _horizontalMovement = Mathf.Lerp(_horizontalMovement, 0f, Time.deltaTime * horizontalMovementSmoothingFactor);
            SetHorizontalMovement(_horizontalMovement);
        }

        public enum Trigger
        {
            Die,
        }
    }
}