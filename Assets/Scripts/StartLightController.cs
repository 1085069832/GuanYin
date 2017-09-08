using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLightController : MonoBehaviour
{
    [SerializeField] GoddessController goddessController;//观音
    [SerializeField] Material mat;
    [SerializeField] float alpha = 0;
    Color color;

    void Awake()
    {
        color = mat.GetColor("_TintColor");
        StartCoroutine(ShowLight());
    }

    /// <summary>
    /// 显示
    /// </summary>
    /// <returns></returns>
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
            StartCoroutine(HideLight());

            goddessController.gameObject.SetActive(true);//移动观音
            goddessController.DoMove();
        }
        else
        {
            StartCoroutine(ShowLight());
        }
    }

    /// <summary>
    /// 隐藏
    /// </summary>
    /// <returns></returns>
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
