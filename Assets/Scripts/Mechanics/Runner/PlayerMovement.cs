using System;
using UnityEngine;

namespace Rhodos.Mechanics.Runner
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float forwardSpeed;
        [SerializeField] private float horizontalBorder;
        public bool IsMovingForward { get; set; }
        public void MoveHorizontal(float movement)
        {
            transform.position += new Vector3(movement, 0, 0);
            ClampHorizontalPosition();
        }

        private void ClampHorizontalPosition()
        {
            var position = transform.position;
            position.x = Mathf.Clamp(position.x, -horizontalBorder, horizontalBorder);
            transform.position = position;
        }

        private void MoveForward()
        {
            var movement = Vector3.forward * (forwardSpeed * Time.deltaTime);
            transform.position += movement;
        }

        private void Update()
        {
            if(!IsMovingForward) return;
            MoveForward();
        }
    }
}