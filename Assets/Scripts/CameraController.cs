using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Fields
    [SerializeField] public GameObject ObjectToFocus;

    private Vector3 _deltaPos = new Vector3(0, 3.6f, -5);

    private void Start()
    {
        transform.position = ObjectToFocus.transform.position + _deltaPos;
        transform.rotation = Quaternion.Euler(new Vector3(27, 0, 0));
    }

    void LateUpdate()
    {
        transform.DOMove(ObjectToFocus.transform.position + _deltaPos, 0.1f).SetEase(Ease.Flash);
        transform.rotation = Quaternion.Euler(new Vector3(27, 0, 0));
    }
}