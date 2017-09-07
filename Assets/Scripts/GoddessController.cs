using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoddessController : MonoBehaviour
{
    [HideInInspector] public bool isMoving;

    public void DoMove()
    {
        isMoving = true;
        transform.DOMove(Camera.main.transform.position + Vector3.forward * 0.6f, 6);
    }
}
