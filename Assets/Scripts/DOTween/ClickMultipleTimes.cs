using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ClickMultipleTimes : MonoBehaviour, IPointerClickHandler
{
    private Text _textComp;
    private RectTransform _rect;
    private RectTransform _canvas;
    private int _clicked = 0;
    private bool _isMoving = false;

    private void Awake()
    {
        Intro.StepStart();

        _canvas = transform.parent.GetComponent<RectTransform>();
        _rect = GetComponent<RectTransform>();
        
        _textComp = GetComponent<Text>();
        _textComp.text = "이번엔 진짜 클릭!";
    }

    private void Update()
    {
        switch (_clicked)
        {
            case int n when n > 0 && n <= 1:
                ChangePosAndText("힝 속았징");
                break;
            
            case int n when n > 1 && n <= 2:
                ChangePosAndText("또 속다니");
                break;
            
            case 3:
                ChangePosAndText("진짜 마지막");
                break;
            
            case 4:
                FadeOutAndEndStep();
                break;
        }
    }

    void ChangePosAndText(string text)
    {
        if (_isMoving)
        {
            return;
        }

        _textComp.text = text;

        float xPos = (_canvas.rect.size.x / 2) - 200; 
        float yPos = (_canvas.rect.size.y / 2) - 50;

        float x = (Random.Range(-xPos, xPos));
        float y = (Random.Range(-yPos, yPos));

        _isMoving = true;

        _rect.DOAnchorPos(new Vector2(x, y), 0.5f);
    }

    void FadeOutAndEndStep()
    {
        GetComponent<CanvasGroup>().DOFade(0, 2f)
            .OnComplete(() =>
            {
                Intro.StepEnd();
                Destroy(gameObject);
            });
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _clicked++;
        _isMoving = false;
    }
}
