using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MoveMode
{
    ToRight,
    ToLeft
}

public class CloudController : MonoBehaviour
{
    bool isRight;
    [SerializeField] MoveMode mode;

    void Awake()
    {
        switch (mode)
        {
            case MoveMode.ToRight:
                isRight = true;
                break;
            case MoveMode.ToLeft:
                isRight = false;
                break;
        }
    }

    // Use this for initialization
    void Start()
    {
        MoveCloud();
    }

    void MoveCloud()
    {
        if (isRight)
            transform.DOMove(new Vector3(20, transform.position.y, transform.position.z), 60).SetEase(Ease.OutQuad);
        else
            transform.DOMove(new Vector3(-20, transform.position.y, transform.position.z), 60).SetEase(Ease.OutQuad);
    }
}
