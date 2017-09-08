using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    bool startMove = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startMove)
        {
            startMove = false;
            transform.DOMove(new Vector3(20, transform.position.y, transform.position.z), 40).SetEase(Ease.OutQuad);
        }
    }
}
