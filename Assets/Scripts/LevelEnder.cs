using System;
using Rhodos.Core;
using Rhodos.Mechanics.Runner;
using UnityEngine;

namespace Rhodos
{
    public class LevelEnder : MonoBehaviour
    {
        private bool _isUsedOnce;
        private void OnTriggerEnter(Collider other)
        {
            if (_isUsedOnce) return;
            if(!other.CompareTag(PlayerServicesLocator.TAG)) return;
            _isUsedOnce = true;
            GameManager.I.OnSuccess();
        }
    }
}