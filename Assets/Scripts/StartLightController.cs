using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLightController : MonoBehaviour
{
    [SerializeField] GoddessController goddessController;
    [SerializeField] Material mat;
    [SerializeField] float alpha = 0;
    Color color;

    void Awake()
    {
        color = mat.GetColor("_TintColor");
        StartCoroutine(ShowLight());
    }

    IEnumerator ShowLight()
    {
        yield return null;
        alpha += 0.003f;
        var a = Mathf.Clamp(alpha, 0, 1);
        mat.SetColor("_TintColor", new Color(color.r, color.g, color.b, a));

        if (a == 1)
        {
            StopCoroutine(ShowLight());
            StopParticle();
            goddessController.gameObject.SetActive(true);
            goddessController.DoMove();
            StartCoroutine(HideLight());
        }
        else
        {
            StartCoroutine(ShowLight());
        }
    }

    IEnumerator HideLight()
    {
        yield return null;
        alpha -= 0.002f;
        var a = Mathf.Clamp(alpha, 0, 1);
        mat.SetColor("_TintColor", new Color(color.r, color.g, color.b, a));

        if (a == 0)
        {
            StopCoroutine(HideLight());
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
