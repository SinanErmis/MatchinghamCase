using MyBox;
using UnityEngine;

namespace Rhodos.Core
{
    [CreateAssetMenu(fileName = "Procedural Level Generator", menuName = "Scriptables/Procedural Level Generator")]
    public class ProceduralLevelGenerator : ScriptableObject
    {
        [SerializeField] private LevelStage[] stages;
        [SerializeField] private int maxObstacleCount = 220, minObstacleCount = 180;
        
        public Level Generate(Transform holder, float startSpace)
        {
            var level = new GameObject("Procedural Level").AddComponent<Level>();
            level.transform.parent = holder;
            var targetObstacleCount = UnityEngine.Random.Range(minObstacleCount, this.maxObstacleCount);
            var length = startSpace;
            var currentObstacleCount = 0;
            while (currentObstacleCount < targetObstacleCount) 
            {
                var stageToInstantiate = stages.GetRandom();
                var stage = Instantiate(stageToInstantiate, level.transform);
                stage.transform.position = Vector3.forward * length;
                length += stage.Length;
                currentObstacleCount += stage.ObstacleCount;
            }
            return level;
        }
    }
}