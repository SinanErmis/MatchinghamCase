using UnityEngine;

namespace Rhodos.Mechanics.Runner
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform model;
        [SerializeField] private Transform bulletStartingPoint;
        [SerializeField] private int bulletCount;
        public const string GATE_TAG = "WeaponGate";

        public void Activate(out Transform bulletStartingPoint, out int bulletCount)
        {
            model.gameObject.SetActive(true);
            bulletStartingPoint = this.bulletStartingPoint;
            bulletCount = this.bulletCount;
        }

        public void Deactivate()
        {
            model.gameObject.SetActive(false);
        }
    }
}