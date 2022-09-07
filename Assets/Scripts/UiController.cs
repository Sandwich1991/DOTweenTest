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
    [SerializeField] private Text _command;

    private bool _isMenuLoading = false;

    private Stack<RectTransform> _menus = new Stack<RectTransform>();
    private Stack<string> _commandStack = new Stack<string>();
    
    void MenuFoward(RectTransform newMenu, string command)
    {
        if (_isMenuLoading == true)
            return;
        else
        {
            _isMenuLoading = true;
            _commandStack.Push(command);
            _command.DOText(_commandStack.Peek(), 0.8f);
            RectTransform originMenu = _menus.Peek();
            _menus.Push(newMenu);

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

            _commandStack.Pop();
            _command.DOText(_commandStack.Peek(), 0.5f);
            
            RectTransform originMenu = _menus.Pop();
            RectTransform newMenu = _menus.Peek();
        
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
        MenuFoward(_transformUI, "transform");
        
    }
    
    public void ToMaterialMenu()
    {
        MenuFoward(_materialUI, "material");
    }
    
    public void ToJumpMenu()
    {
        MenuFoward(_jumpUI, "transform.DOJump()");
    }
    
    public void ToMoveMenu()
    {
        MenuFoward(_moveUI, "transform.DOMove()");
    }
    
    public void ToColorMenu()
    {
        MenuFoward(_colorUI, "material.DOColor()");
    }
    
    public void ToFadeMenu()
    {
        MenuFoward(_fadeUI, "material.DOFade()");
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
        _commandStack.Push("DOTween Simulator");
        _command.DOText(_commandStack.Peek(), 0.7f).SetDelay(0.5f);
    }
}
