using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rhodos.Core
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Level[] allLevels;
        [SerializeField] private Level testLevel;
        [SerializeField] private Transform levelHolder;
        [SerializeField] private ProceduralLevelGenerator proceduralLevelGenerator;
        
        [Tooltip("Used for giving player a fresh start")]
        [SerializeField] private float startBreatheRoom = 8f;
        
        public static Level ActiveLevel { get; private set; }

        private void Start()
        {
            ActiveLevel = CreateLevel();
        }
        
        private Level CreateLevel()
        {
            if (testLevel != null)
            {
                return Instantiate(testLevel,levelHolder);
            }

            var levelIndex = SaveLoadManager.GetLevel();
            if (levelIndex < allLevels.Length)
            {
                return Instantiate(allLevels[levelIndex], levelHolder);
            }

            return proceduralLevelGenerator.Generate(levelHolder, startBreatheRoom);
        }

        public static void RestartScene() => SceneManager.LoadScene("Game");
    }
}
