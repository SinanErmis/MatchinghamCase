using System;
using UnityEngine;

namespace Rhodos.Mechanics.Runner
{
    public class WeaponUpgradeHandler : MonoBehaviour
    {
        [SerializeField] private PlayerShootingHandler shootingHandler;
        [SerializeField] private Weapon[] weapons;
        [SerializeField] private int maxLevel = 2;
        private int _currentLevel;

        private void Upgrade()
        {
            if (_currentLevel == maxLevel)
                return;
            _currentLevel++;
            ChangeWeaponLook(_currentLevel);
        }

        private void ChangeWeaponLook(int currentLevel)
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                if (i == currentLevel)
                {
                    weapons[i].Activate(out var bulletStartingPoint, out int bulletCount);
                    shootingHandler.SetBulletStartingPoint(bulletStartingPoint);
                    shootingHandler.SetShotCount(bulletCount);
                }
                else weapons[i].Deactivate();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Weapon.GATE_TAG)) return;
            Upgrade();
        }
    }
}