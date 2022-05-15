using UnityEngine;

namespace Rhodos
{
    public class LevelStage : MonoBehaviour
    {
        [field: SerializeField] public float Length { get; private set; }
        [field: SerializeField] public int ObstacleCount { get; private set; }
    }
}