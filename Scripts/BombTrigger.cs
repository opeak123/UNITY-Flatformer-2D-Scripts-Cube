using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTrigger : MonoBehaviour
{
    FadeInOut m_fadeScript;
    private bool b_isFade = false;
    private int m_cnt = 0;
    private void Start()
    {
        m_fadeScript = FindObjectOfType<FadeInOut>();
    }

    private void Update()
    {
        if (b_isFade && m_cnt == 0)
        {
            ++m_cnt;
            m_fadeScript.fadeTime = 1.5f;
            StartCoroutine(m_fadeScript.FadeOut());
            StartCoroutine(GetFade());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "ARMOREDCRUSHER":
                FindObjectOfType<ArmoredCrusher>().b_crusherFire = false;
                SoundManager.Instance.PlaySFX("bridge-explosion-sfx", 1f);
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                b_isFade = true;
                SoundManager.Instance.PlayBGM("Intro-main-bgm", 1f);
                break;

            default:
                break;
        }
    }

    IEnumerator GetFade()
    {
        yield return new WaitForSeconds(3f);
        m_fadeScript.fadeTime = 3f;
        StartCoroutine(m_fadeScript.FadeIn());
        GameManager.Instance.isNextStage = true;

    }
}
