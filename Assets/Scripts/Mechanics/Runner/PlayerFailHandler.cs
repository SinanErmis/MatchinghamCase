using System;
using Rhodos.Core;
using UnityEngine;

namespace Rhodos.Mechanics.Runner
{
    public class PlayerFailHandler : MonoBehaviour
    {
        [SerializeField] private Collider failCollider;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Obstacle.TAG)) return;
            
            failCollider.enabled = false;
            GameManager.I.OnFail();
            Debug.Log("FAIL");
        }
    }
}