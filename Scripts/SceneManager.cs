using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneManager : MonoBehaviour
{
    //first UI
    private GameObject m_intro;
    private GameObject m_edge;
    [SerializeField]
    public int m_currSceneNumber = 0;

    //loading Scene slider
    public GameObject m_loadingBox;
    public Slider slider;
    public Text Loadingtext;
    private float loadingtime;

    //options click
    [SerializeField]
    private GameObject m_options;

    //setting click
    public GameObject m_menu;
    public GameObject m_selected;
    public GameObject m_video;
   
    private void Awake()
    {
        m_intro = GameObject.Find("Intro").gameObject;
        m_edge = GameObject.Find("PlanetCube").gameObject;
    }

    private void Start()
    {
        SoundManager.Instance.PlayBGM("Main-Menu-bgm", 1f);
    }

    private void LateUpdate()
    {
        SceneUI();
    }

    private void SceneUI()
    {
        if (m_currSceneNumber == 0 && Input.anyKeyDown)
        {
            if (Input.GetKey(KeyCode.Backspace))
                return;

            m_currSceneNumber++;
            m_intro.SetActive(true);
            m_edge.SetActive(false);
            SoundManager.Instance.PlaySFX("ui-click-sfx", .5f);
        }
        else if (m_currSceneNumber == 1 && Input.GetKeyDown(KeyCode.Backspace))
        {
            m_currSceneNumber--;
            m_intro.SetActive(false);
            m_edge.SetActive(true);
            SoundManager.Instance.PlaySFX("ui-click-sfx", .5f);
        }
    }

    public void LoadScene(int SceneNumber)
    {
        StartCoroutine(LoadAsync(SceneNumber));
    }


    IEnumerator LoadAsync(int SceneNumber)
    {
        AsyncOperation op = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(SceneNumber);

        m_intro.SetActive(false);
        m_edge.SetActive(false);
        m_loadingBox.SetActive(true);
        op.allowSceneActivation = false;

        while (!op.isDone)
        {
            loadingtime += Time.deltaTime * 0.08f;
            slider.value = loadingtime;
            Loadingtext.text = loadingtime.ToString("P0");

            if (slider.value < 0.9f)
                slider.value = loadingtime;

            else
            {
                slider.value = Mathf.Clamp(slider.value, 0.9f, loadingtime);
                if (slider.value == 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
            yield return null;
        SoundManager.Instance.bgmSources[0].clip = SoundManager.Instance.clips[4];
        SoundManager.Instance.bgmSources[0].Play();
        }
    }

    public void OnClickOption()
    {
        m_currSceneNumber++;
        m_edge.SetActive(false);
        m_intro.SetActive(false);
        m_options.SetActive(true);
        SoundManager.Instance.PlaySFX("ui-click-sfx", .5f);
    }

    public void OptionToIntro()
    {
        m_currSceneNumber--;
        m_edge.SetActive(false);
        m_intro.SetActive(true);
        m_options.SetActive(false);
        SoundManager.Instance.PlaySFX("ui-click-sfx", .5f);
    }

    public void OnClickSetting()
    {
        m_currSceneNumber++;
        SoundManager.Instance.PlaySFX("ui-click-sfx", .5f);
        m_menu.SetActive(false);
        m_selected.SetActive(false);
        m_video.SetActive(true);
    }

    public void SettingToOption()
    {
        m_currSceneNumber--;
        SoundManager.Instance.PlaySFX("ui-click-sfx", .5f);
        m_menu.SetActive(true);
        m_selected.SetActive(true);
        m_video.SetActive(false);
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
