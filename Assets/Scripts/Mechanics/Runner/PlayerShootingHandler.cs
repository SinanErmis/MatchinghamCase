using System;
using System.Collections;
using UnityEngine;

namespace Rhodos.Mechanics.Runner
{
    public class PlayerShootingHandler : MonoBehaviour
    {
        [SerializeField] private Transform bulletStartingPoint;
        [SerializeField] [Tooltip("Meters per second")] private float bulletSpeed;
        [SerializeField] private float salvoInterval = 0.4f, firingInterval = 0.1f;
        
        private int _bulletCount = 1; //todo add upgrades
        private bool _isShooting;
        private WaitForSeconds _waitForSalvoInterval;
        private WaitForSeconds _waitForBulletFiringInterval;
        
        private void Awake()
        {
            Bullet.InitializePool();
            _waitForSalvoInterval = new WaitForSeconds(salvoInterval);
            _waitForBulletFiringInterval = new WaitForSeconds(firingInterval);
        }

        public IEnumerator ShootContinuously()
        {
            _isShooting = true;
            while (_isShooting) 
            {
                yield return _waitForSalvoInterval;
                StartCoroutine(ShootMultipleTimes(_bulletCount));
            }
        }

        private IEnumerator ShootMultipleTimes(int times)
        {
            for (int i = 0; i < times; i++)
            {
                ShootOnce();
                yield return _waitForBulletFiringInterval;
            }
        }
        private void ShootOnce()
        {
            var bullet = Bullet.Pool.Get();
            bullet.transform.position = bulletStartingPoint.position;
            bullet.transform.rotation = Quaternion.LookRotation(Vector3.forward);
            bullet.StartForwardMove(bulletSpeed);
        }

        public void StopShooting()
        {
            _isShooting = false;
        }
    }
}