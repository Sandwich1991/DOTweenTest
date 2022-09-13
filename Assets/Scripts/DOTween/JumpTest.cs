using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class JumpTest : MonoBehaviour
{
    public static Action<string> JumpAction;
    
    private void Start()
    {
        transform.position = new Vector3(0, 1.5f, 0);
        transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));

        transform.DORotate(new Vector3(90, 0, -360), 3f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1);

        gameObject.GetComponent<MeshRenderer>().material.DOColor(Color.white, 0.1f);
    }

    public void Reset()
    {
        transform.position = new Vector3(0, 1.5f, 0);
        transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));

        gameObject.GetComponent<MeshRenderer>().material.DOColor(Color.white, 2f);
    }

    public void Jump()
    {
        JumpAction.Invoke("transform.DOJump(Vector3.up)");
        transform.DOJump(Vector3.up, 5f, 1, 0.5f, false);
    }

    public void JumpForward()
    {
        JumpAction.Invoke("transform.DOJump(Vector3.foward)");
        transform.DOJump(transform.position + Vector3.forward * 10f, 5f, 1, 0.5f, false);
    }
    
    public void JumpBackward()
    {
        JumpAction.Invoke("transform.DOJump(Vector3.back)");
        transform.DOJump(transform.position + Vector3.back * 10f, 5f, 1, 0.5f, false);
    }
    
    public void JumpLeft()
    {
        JumpAction.Invoke("transform.DOJump(Vector3.left)");
        transform.DOJump(transform.position + Vector3.left * 10f, 5f, 1, 0.5f, false);
    }
    
    public void JumpRight()
    {
        JumpAction.Invoke("transform.DOJump(Vector3.right)");
        transform.DOJump(transform.position + Vector3.right * 10f, 5f, 1, 0.5f, false);
    }
}
