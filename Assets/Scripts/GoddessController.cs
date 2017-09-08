using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoddessController : MonoBehaviour
{
    public void DoMove()
    {
        transform.DOMove(new Vector3(transform.position.x, -1.5f, transform.position.z), 5).SetEase(Ease.OutQuad);
    }
}
