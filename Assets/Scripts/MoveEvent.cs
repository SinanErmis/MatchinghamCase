using DG.Tweening;
using UnityEngine;

namespace Rhodos
{
    public class MoveEvent : MonoBehaviour
    {
        [SerializeField] private Vector3 amount;
        [SerializeField] private float duration = 1f;
        
        public void MoveDown()
        {
            transform.DOMove(amount, duration).SetRelative(true).SetEase(Ease.Linear);
        }
    }
}