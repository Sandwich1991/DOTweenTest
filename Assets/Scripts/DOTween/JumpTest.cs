using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class JumpTest : MonoBehaviour
{
    float _spinSpeed = 3f;
    private void Start()
    {
        transform.position = new Vector3(0, 1.5f, 0);
        transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
        
        transform.DORotate(new Vector3(90, 360, 0), _spinSpeed, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        
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
        transform.DOJump(Vector3.up, 5f, 1, 0.5f, false);
    }

    public void JumpForward()
    {
        transform.DOJump(transform.position + Vector3.forward * 10f, 5f, 1, 0.5f, false);
    }
    
    public void JumpBackward()
    {
        transform.DOJump(transform.position + Vector3.back * 10f, 5f, 1, 0.5f, false);
    }
    
    public void JumpLeft()
    {
        transform.DOJump(transform.position + Vector3.left * 10f, 5f, 1, 0.5f, false);
    }
    
    public void JumpRight()
    {
        transform.DOJump(transform.position + Vector3.right * 10f, 5f, 1, 0.5f, false);
    }
}
