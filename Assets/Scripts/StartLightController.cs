using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLightController : MonoBehaviour
{
    [SerializeField] GoddessController goddessController;
    [SerializeField] List<GameObject> objs;
    public float alpha = 1f;

    // Use this for initialization
    void Start()
    {
        ShowLight();
    }

    private void Update()
    {
        alpha = Mathf.Max(0, alpha - 0.005f);
        Color color = objs[0].GetComponent<MeshRenderer>().material.GetColor("_TintColor");

        for (int i = 0; i < objs.Count; i++)
        {
            objs[i].GetComponent<MeshRenderer>().material.SetColor("_TintColor", new Color(color.r, color.g, color.b, alpha));
        }
    }

    void ShowLight()
    {
        Tweener move = transform.DOMove(Camera.main.transform.forward * 10 - Vector3.up * 3, 2);

        move.onComplete = delegate
        {
            goddessController.gameObject.SetActive(true);//显示观音
            StartCoroutine(WaitStartHideLight());
        };
    }

    IEnumerator WaitStartHideLight()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(HideLight());
    }

    IEnumerator HideLight()
    {
        yield return null;
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0, transform.localScale.y, 0), 0.01f);

        if (!goddessController.isMoving && transform.localScale.x <= 0.2f)
        {
            goddessController.DoMove();
        }

        if (transform.localScale.x < 0.01f)
        {
            StopParticle();
            StopCoroutine(HideLight());
            transform.localScale = Vector3.zero;

        }
        else
        {
            StartCoroutine(HideLight());
        }
    }

    /// <summary>
    ///关闭粒子
    /// </summary>
    void StopParticle()
    {
        EllipsoidParticleEmitter[] ePe = GetComponentsInChildren<EllipsoidParticleEmitter>();

        for (int i = 0; i < ePe.Length; i++)
        {
            ePe[i].emit = false;
        }
    }
}
