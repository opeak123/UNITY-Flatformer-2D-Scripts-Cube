using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InGamePopUI : MonoBehaviour
{
    private Animator m_ani;
    private bool b_onButton = false;
    [SerializeField]
    private Canvas m_canvasGroup;
    public GameObject m_seleted;
    public GameObject m_menu;
    public GameObject m_settings;


    private void Start()
    {
        m_ani = GetComponent<Animator>();
        m_canvasGroup = GetComponent<Canvas>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            b_onButton = !b_onButton;
        }
        PopupCanvas();
    }
    private void PopupCanvas()
    {

        if(b_onButton)
        {
            m_ani.enabled = true;
            Time.timeScale = 0f;
            m_canvasGroup.enabled = true;
            GameManager.Instance.pause = true;
            GameManager.Instance.canMove = false;
        }
        else if (!b_onButton) 
        {
            m_ani.enabled = false;
            Time.timeScale = 1f;
            m_canvasGroup.enabled = false;
            GameManager.Instance.pause = false;
            GameManager.Instance.canMove = true;
        }
    }

    public void OnButtonReturn()
    {
        b_onButton = false;
        SoundManager.Instance.PlaySFX("ui-click2-sfx", .5f);

    }

    public void OnButtonSave()
    {

    }

    public void OnButtonSetting()
    {
        m_seleted.SetActive(false);
        m_menu.SetActive(false);
        m_settings.SetActive(true);
    }

    public void SettingToOption()
    {
        m_seleted.SetActive(true);
        m_menu.SetActive(true);
        m_settings.SetActive(false);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
