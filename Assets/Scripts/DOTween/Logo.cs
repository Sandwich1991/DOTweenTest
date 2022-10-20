using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Logo : MonoBehaviour
{
    private Sequence _introSequence;

    private void Awake()
    {
        Intro.StepStart();
    }

    private void Start()
    {
        _introSequence = DOTween.Sequence()
            .SetAutoKill(false)
            .OnStart(() =>
            {
                transform.localScale = Vector3.zero;
                GetComponent<CanvasGroup>().alpha = 0;
            })
            .Append(transform.DOScale(1, 1).SetEase(Ease.OutBounce))
            .Join(GetComponent<CanvasGroup>().DOFade(1, 1))
            .AppendInterval(2f)
            .PrependInterval(0.5f)
            .Append(GetComponent<CanvasGroup>().DOFade(0, 2f))
            .AppendCallback(Intro.StepEnd);
    }
}
