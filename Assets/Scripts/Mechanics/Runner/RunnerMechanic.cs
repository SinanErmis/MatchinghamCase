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

        public override IEnumerator OnStart()
        {
            StartTakingInput();
            BindCameraToPlayer();
            player.PlayerMovement.IsMovingForward = true;
            
            yield break;
        }

        protected override void SwipeAction(Vector2 swipe)
        {
            //! don't multiply swipe.x by Time.deltaTime because
            //! the swipe vector represents the difference since the last frame 

            var horizontalMovement = swipe.x * sensitivity;
            player.PlayerMovement.MoveHorizontal(horizontalMovement);
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
    }
}