﻿using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using MyBox;
using UnityEngine.UI;
using Rhodos.Core;

namespace Rhodos.UI
{
    [RequireComponent(typeof(Canvas), typeof(CanvasScaler))]
    public abstract class UIScreen : MonoBehaviour
    {
        public abstract IEnumerator PlayInAnimation();

        public abstract IEnumerator PlayOutAnimation();

        [ButtonMethod]
        public void ActivateThisScreen() => Managers.I.UIManager.ChangeUI(this).StartCoroutine();
    }
}