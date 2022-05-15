using System;
using DG.Tweening;
using MyBox;
using UnityEngine;

namespace Rhodos
{
    public class Patroller : MonoBehaviour
    {
        [SerializeField] private float minX, maxX;

        private void Start()
        {
            transform.position = transform.position.SetX(minX);
            DOTween.Sequence()
                .Append(transform.DOMoveX(maxX, 1f).SetEase(Ease.Linear).SetSpeedBased())
                .Append(transform.DOMoveX(minX, 1f).SetEase(Ease.Linear).SetSpeedBased())
                .SetLoops(-1, LoopType.Yoyo);
        }
    }
}