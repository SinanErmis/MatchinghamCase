using System;
using UnityEngine;
using UnityEngine.Events;

namespace Rhodos.Mechanics.Runner
{
    public class DestructibleObstacle : Obstacle
    {
        [SerializeField] private int startingHp;
        [Tooltip("int parameter is remaining HP, use it to update UI")]
        [SerializeField] private UnityEvent<int> onHpChanged;
        [SerializeField] private UnityEvent onDestroyed;
        
        private int _hp;

        private int HP
        {
            get => _hp;
            set
            {
                _hp = value;
                onHpChanged.Invoke(value);
                if (value <= 0)
                {
                    Die();
                }
            }
        }

        private void Awake()
        {
            HP = startingHp;
        }

        private void Die()
        {
            //todo add juice
            onDestroyed.Invoke();
            Destroy(gameObject);
        }

        public override void OnGetShot()
        {
            HP--;
        }
    }
}