using System;
using System.Collections;
using Rhodos.Core;
using Rhodos.Mechanics.Bases;
using UnityEngine;

namespace Rhodos.Mechanics.Runner
{
    /// <summary>
    /// Handles input and calls player movement
    /// </summary>
    public class RunnerMechanic : InstantVectorSwipeMechanic
    {
        [SerializeField] private float sensitivity;
        [SerializeField] private PlayerServicesLocator player;
        [SerializeField] private float animationThreshold = 20f;
        
        public override IEnumerator OnStart()
        {
            StartTakingInput();
            BindCameraToPlayer();
            StartMovingPlayerForward();
            StartCoroutine(player.PlayerShootingHandler.ShootContinuously());
            StartCoroutine(Managers.I.UIManager.ChangeUI(null));
            yield break;
        }

        public override IEnumerator OnFail()
        {
            CanPlay = false;
            player.PlayerAnimationController.SetTrigger(PlayerAnimationController.Trigger.Die);
            StopMovingPlayerForward();
            yield break;
        }

        protected override void SwipeAction(Vector2 swipe)
        {
            var horizontalMovement = swipe.x;
            HandlePlayerHorizontalMovement(horizontalMovement);
            if(horizontalMovement > animationThreshold) player.PlayerAnimationController.HandleHorizontalAnimation(horizontalMovement);
        }

        private void HandlePlayerHorizontalMovement(float horizontalMovement)
        {
            //! don't multiply swipe.x by Time.deltaTime because
            //! the swipe vector represents the difference since the last frame 
            
            player.PlayerMovement.MoveHorizontal(horizontalMovement * sensitivity);

        }

        private void StartTakingInput()
        {
            //? CanPlay parameter activates input taking, maybe should be renamed to TakeInput later
            CanPlay = true;
        }

        private void BindCameraToPlayer()
        {
            // Given an arbitrary speed, 5f is fine
            StartCoroutine(Managers.I.CameraManager.BindTargetTransform(player.CameraTarget, 5f));
        }
        
        private void StartMovingPlayerForward()
        {
            player.PlayerAnimationController.SetForwardMovement(true);
            player.PlayerMovement.IsMovingForward = true;
        }        
        private void StopMovingPlayerForward()
        {
            player.PlayerAnimationController.SetForwardMovement(false);
            player.PlayerMovement.IsMovingForward = false;
        }
    }
}