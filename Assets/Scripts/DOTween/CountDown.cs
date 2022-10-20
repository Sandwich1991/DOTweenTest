using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    [SerializeField] private TMP_Text textComp;

    private int _count = 5;
    private bool _isCheck;
    private Sequence _countDown;
    private void Awake()
    {
        Intro.StepStart();
        
        textComp.text = _count.ToString();

        _countDown = DOTween.Sequence()
            .AppendCallback(() => transform.DOMove(Vector3.zero, 3f).From(Vector3.up * 15))
            .AppendInterval(3f)
            .AppendCallback(() =>
            {
                transform.DOLocalRotate(new Vector3(0, -360, 0), 2, RotateMode.FastBeyond360).SetLoops(5)
                    .OnUpdate(() =>
                    {
                        if (Mathf.Abs(transform.localRotation.eulerAngles.y - 180) <= 10)
                        {
                            CountDownAndChangeNum();
                        }

                        if (Mathf.Abs(transform.localRotation.eulerAngles.y - 0) <= 20)
                        {
                            _isCheck = false;
                        }
                    })
                    .OnComplete(() =>
                    {
                        Invoke("StepEnd", 1f);
                    });
            });
    }
    
    void CountDownAndChangeNum()
    {
        if (_isCheck)
        {
            return;
        }

        _count--;

        if (_count > 0)
        {
            textComp.text = _count.ToString();
        }
        else
        {
            textComp.fontSize = 200;
            textComp.text = "START!";
        }

        _isCheck = true;
    }

    void StepEnd()
    {
        Intro.StepEnd();
        Destroy(gameObject);
    }
}
