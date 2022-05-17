using UnityEngine;

namespace Rhodos.Mechanics.Runner
{
    /// <summary>
    /// Locates the components that are related to player
    /// </summary>
    public class PlayerServicesLocator : MonoBehaviour
    {
        public const string TAG = "Player";
        [field: SerializeField] public PlayerMovement PlayerMovement { get; private set; }
        [field: SerializeField] public PlayerAnimationController PlayerAnimationController { get; private set; }
        [field: SerializeField] public PlayerShootingHandler PlayerShootingHandler { get; private set; }
        [field: SerializeField] public Transform CameraTarget { get; private set; }
    }
}