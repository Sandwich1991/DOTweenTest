using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MeterialTest : MonoBehaviour
{
    private Color _orange = new Color(255 / 255f, 136 / 255f, 100 / 255f);
    private Color _navy = new Color(21 / 255f, 96 / 255f, 189 / 255f);
    private Color _purple = new Color(131 / 255f, 89 / 255f, 163 / 255f);

    private Material _material;

    public void ToRed(float time = 0.5f)
    {
        _material.DOColor(Color.red, time);
    }

    public void ToOrange(float time = 0.5f)
    {
        _material.DOColor(_orange, time);
    }
    
    public void ToYellow(float time = 0.5f)
    {
        _material.DOColor(Color.yellow, time);
    }
    
    public void ToGreen(float time = 0.5f)
    {
        _material.DOColor(Color.green, time);
    }
    
    public void ToBlue(float time = 0.5f)
    {
        _material.DOColor(Color.blue, time);
    }
    
    public void ToNavy(float time = 0.5f)
    {
        _material.DOColor(_navy, time);
    }
    
    public void ToPurple(float time = 0.5f)
    {
        _material.DOColor(_purple, time);
    }

    private void Start()
    {
        _material = gameObject.GetComponent<MeshRenderer>().material;
    }
}
