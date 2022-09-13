using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    public static Action<string> MoveAction;
    
    public void MoveForwad()
    {
        MoveAction.Invoke("transform.DOMove(Vector3.forward)");
        transform.DOMove(transform.position + Vector3.forward * 10f, 0.3f).SetEase(Ease.OutQuad);
    }
    
    public void MoveBack()
    {
        MoveAction.Invoke("transform.DOMove(Vector3.back)");
        transform.DOMove(transform.position + Vector3.back * 10f, 0.3f).SetEase(Ease.OutQuad);
    }
    
    public void MoveLeft()
    {
        MoveAction.Invoke("transform.DOMove(Vector3.left)");
        transform.DOMove(transform.position + Vector3.left * 10f, 0.3f).SetEase(Ease.OutQuad);
    }
    
    public void MoveRight()
    {
        MoveAction.Invoke("transform.DOMove(Vector3.right)");
        transform.DOMove(transform.position + Vector3.right * 10f, 0.3f).SetEase(Ease.OutQuad);
    }
}
