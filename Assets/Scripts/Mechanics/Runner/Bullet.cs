using Rhodos.Core;
using UnityEngine;
using UnityEngine.Pool;

namespace Rhodos.Mechanics.Runner
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private new Rigidbody rigidbody;
        
        #region Pooling
        public static ObjectPool<Bullet> Pool { get; private set; }
        
        public static void InitializePool()
        {
            if (Pool != null) return;
            
            Pool = new ObjectPool<Bullet>(
                InstantiateBullet,
                (b) => b.gameObject.SetActive(true),
                (b) => b.gameObject.SetActive(false),
                defaultCapacity: 100);
        }

        private static Bullet InstantiateBullet() => Instantiate<Bullet>(Assets.I.BulletPrefab);
        
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            // no need to check since bullets can't collide anything other than obstacles.
            // if any further changes are made, this should be changed smt like that:
            //if (!other.CompareTag(Obstacle.TAG)) return;
            
            var obstacle = other.GetComponent<Obstacle>();
            obstacle.OnGetShot();
            Pool.Release(this);
        }

        public void StartForwardMove(float speed)
        {
            rigidbody.velocity = Vector3.forward * speed;
        }
    }
}