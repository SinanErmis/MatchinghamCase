using MyBox;
using UnityEngine;

namespace Rhodos.Core
{
    [CreateAssetMenu(fileName = "Procedural Level Generator", menuName = "Scriptables/Procedural Level Generator")]
    public class ProceduralLevelGenerator : ScriptableObject
    {
        [SerializeField] private LevelStage[] stages;
        [SerializeField] private LevelStage endStage;
        [SerializeField] private LevelStage[] weaponUpgradeStages;
        
        [SerializeField] private int maxObstacleCount = 220, minObstacleCount = 180;
        
        public Level Generate(Transform parentOfLevel, float startSpace)
        {
            var level = CreateLevelObject(parentOfLevel);
            var parentOfStages = level.transform;
            var targetObstacleCount = Random.Range(minObstacleCount, maxObstacleCount);
            var distance = startSpace;
            
            //flooring the interval to avoid any approximation errors
            var obstacleUntilPerWeaponGate = Mathf.FloorToInt((float)targetObstacleCount / (weaponUpgradeStages.Length + 1));
            var createdWeaponUpgradeGateCount = 0;
            
            var currentObstacleCount = 0;
            while (currentObstacleCount < targetObstacleCount) 
            {
                var stage = CreateRandomStage(parentOfStages, distance);
                distance += stage.Length;
                currentObstacleCount += stage.ObstacleCount;
                CheckDistanceToWeaponUpgradeGate();
            }

            CreateEndStage(parentOfStages, distance);
            
            return level;
            
            // Local function to capture variables from method
            void CheckDistanceToWeaponUpgradeGate()
            {
                if (createdWeaponUpgradeGateCount == weaponUpgradeStages.Length) return;
                
                var enoughObstacleCreatedForNextDoor = 
                    currentObstacleCount >= obstacleUntilPerWeaponGate * (createdWeaponUpgradeGateCount + 1);
                
                if (!enoughObstacleCreatedForNextDoor) return;
                
                CreateWeaponUpgradeStage();
                createdWeaponUpgradeGateCount++;
            }
            void CreateWeaponUpgradeStage()
            {
                var stage = Instantiate(weaponUpgradeStages[createdWeaponUpgradeGateCount], parentOfStages);
                stage.transform.position = Vector3.forward * distance;
                distance += stage.Length;
            }
        }


        private LevelStage CreateRandomStage(Transform parent, float distance)
        {
            var stageToInstantiate = stages.GetRandom();
            var stage = Instantiate(stageToInstantiate, parent);
            stage.transform.position = Vector3.forward * distance;
            return stage;
        }

        private void CreateEndStage(Transform parent, float atDistance)
        {
            Instantiate(endStage, parent).transform.position = Vector3.forward * atDistance;
        }

        private Level CreateLevelObject(Transform holder)
        {
            var level = new GameObject("Procedural Level").AddComponent<Level>();
            level.transform.parent = holder;
            return level;
        }
    }
}