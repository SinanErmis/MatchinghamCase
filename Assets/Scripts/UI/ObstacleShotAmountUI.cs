using TMPro;
using UnityEngine;

namespace Rhodos.UI
{
    /// <summary>
    /// Simple UI shows how many times the obstacle needs to be hit to destroy it.
    /// </summary>
    public class ObstacleShotAmountUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        
        public void SetRemainingAmount(int amount)
        {
            text.text = amount.ToString();
        }
    }
}