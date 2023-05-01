using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    //FadeInout 스크립트 
    private FadeInOut m_fadeInOut;
    private void Start()
    {
        //할당
        m_fadeInOut = GetComponent<FadeInOut>();
    }

    public void FadeOutIn()
    {
        StartCoroutine(FadeOutInCoroutine());
    }

    //FadeIn , FadeOut 동시실행 
    private IEnumerator FadeOutInCoroutine()
    {
        GameManager.Instance.canMove = false;
        m_fadeInOut.m_faderenderer.sortingOrder = 10;

        // Fade Out
        Color color = m_fadeInOut.m_faderenderer.color;
        while (color.a <= 1f)
        {
            color.a += Time.deltaTime / m_fadeInOut.fadeTime;
            m_fadeInOut.m_faderenderer.color = color;
            yield return null;
        }

        yield return StartCoroutine(m_fadeInOut.FadeIn());

        m_fadeInOut.m_faderenderer.sortingOrder = -10;
        GameManager.Instance.canMove = true;
    }
}

