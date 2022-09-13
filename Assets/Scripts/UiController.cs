using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class UiController : MonoBehaviour
{
    public enum _uiState
    {
        None,
        Transform,
        Material,
        Jump,
        Move,
        Color,
        Fade,
    }

    public _uiState UIState = _uiState.None;

    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private RectTransform _scrollviewRect;
    [SerializeField] private RectTransform _viewPort;

    [SerializeField] private RectTransform _menuButton;
    [SerializeField] private RectTransform _mainUI;
    [SerializeField] private RectTransform _transformUI;
    [SerializeField] private RectTransform _materialUI;
    [SerializeField] private RectTransform _jumpUI;
    [SerializeField] private RectTransform _moveUI;
    [SerializeField] private RectTransform _colorUI;
    [SerializeField] private RectTransform _fadeUI;
    

    private bool _isMenuLoading = false;

    private Stack<RectTransform> _menus = new Stack<RectTransform>();

    private Stack<_uiState> _uiStateStack = new Stack<_uiState>();

    public static Action<string> UIAction;

    string GetStateName(_uiState state)
    {
        switch (state)
        {
            case _uiState.Transform:
                return "transform";

            case _uiState.Material:
                return "material";
            
            case _uiState.Jump:
                return "transform.DOJump()";
            
            case _uiState.Move:
                return "transform.DOMove()";
            
            case _uiState.Color:
                return "meterial.DOColor()";
            
            case _uiState.Fade:
                return "meterial.DOFade()";
        }

        return "DOTween Simulator";
    }

    void MenuFoward(RectTransform newMenu)
    {
        if (_isMenuLoading == true)
            return;
        else
        {
            _isMenuLoading = true;
            RectTransform originMenu = _menus.Peek();

            _menus.Push(newMenu);
            
            // 현재 uiState를 스택에 저장
            _uiStateStack.Push(UIState);
            UIAction.Invoke(GetStateName(_uiStateStack.Peek()));

            newMenu.DOAnchorPosX(newMenu.rect.width + 100f, 0.1f)
                .OnComplete(() =>newMenu.gameObject.SetActive(true));
        
            originMenu.DOAnchorPosX(-originMenu.rect.width - 100f, 0.5f);
        
            newMenu.DOAnchorPosX(0, 0.5f)
                .SetDelay(0.1f)
                .OnComplete(() =>
                {
                    _scrollRect.content = newMenu;
                    originMenu.gameObject.SetActive(false);
                    _isMenuLoading = false;
                });
        }
    }

    void MenuBackward()
    {
        if (_isMenuLoading == true)
            return;
        else
        {
            _isMenuLoading = true;

            RectTransform originMenu = _menus.Pop();
            RectTransform newMenu = _menus.Peek();
            
            // 이전 state를 스택에서 pop
            _uiStateStack.Pop();
            UIAction.Invoke(GetStateName(_uiStateStack.Peek()));
        
            newMenu.DOAnchorPosX(-newMenu.rect.width - 100f, 0.1f)
                .OnComplete(() => newMenu.gameObject.SetActive(true));
        
            originMenu.DOAnchorPosX(originMenu.rect.width + 100f, 0.5f);
        
            newMenu.DOAnchorPosX(0, 0.5f)
                .SetDelay(0.1f)
                .OnComplete(() =>
                {
                    _scrollRect.content = newMenu;
                    originMenu.gameObject.SetActive(false);
                    _isMenuLoading = false;
                });
        }
        
    }
    
    public void ToTransformMenu()
    {
        UIState = _uiState.Transform;
        MenuFoward(_transformUI);
    }
    
    public void ToMaterialMenu()
    {
        UIState = _uiState.Material;
        MenuFoward(_materialUI);
    }
    
    public void ToJumpMenu()
    {
        UIState = _uiState.Jump;
        MenuFoward(_jumpUI);
    }
    
    public void ToMoveMenu()
    {
        UIState = _uiState.Move;
        MenuFoward(_moveUI);
    }
    
    public void ToColorMenu()
    {
        UIState = _uiState.Color;
        MenuFoward(_colorUI);
    }
    
    public void ToFadeMenu()
    {
        UIState = _uiState.Fade;
        MenuFoward(_fadeUI);
    }
    
    public void ToReturn()
    {
        MenuBackward();
    }

    private void Start()
    {
        _mainUI.gameObject.SetActive(true);
        _scrollRect.content = _mainUI;
        _transformUI.gameObject.SetActive(false);
        _menus.Push(_mainUI);
        
        _uiStateStack.Push(UIState);
    }
}
