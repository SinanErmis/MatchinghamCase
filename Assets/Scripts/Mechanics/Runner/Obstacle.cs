using UnityEngine;

namespace Rhodos.Mechanics.Runner
{
    public abstract class Obstacle : MonoBehaviour
    {
        public const string TAG = "Obstacle";
        
        public abstract void OnGetShot();
    }
}