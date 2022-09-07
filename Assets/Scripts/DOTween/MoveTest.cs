using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    public void MoveForwad()
    {
        transform.DOMove(transform.position + Vector3.forward * 10f, 0.3f).SetEase(Ease.OutQuad);
    }
    
    public void MoveBack()
    {
        transform.DOMove(transform.position + Vector3.back * 10f, 0.3f).SetEase(Ease.OutQuad);
    }
    
    public void MoveLeft()
    {
        transform.DOMove(transform.position + Vector3.left * 10f, 0.3f).SetEase(Ease.OutQuad);
    }
    
    public void MoveRight()
    {
        transform.DOMove(transform.position + Vector3.right * 10f, 0.3f).SetEase(Ease.OutQuad);
    }
}
