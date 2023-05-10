using UnityEngine;
using UnityEngine.UI;
public class ScreenMode : MonoBehaviour
{
    public Toggle m_fullScreenselected;
    public Toggle m_windowedSeleceted;

    private void Start()
    {

        m_fullScreenselected.onValueChanged.AddListener(ScreenFull);
        m_windowedSeleceted.onValueChanged.AddListener(ScreenWidowed);
    }

    public void ScreenFull(bool isOn)
    {
        if (isOn)
        {
            SoundManager.Instance.PlaySFX("ui-click2-sfx", .5f);
            m_windowedSeleceted.isOn = false;
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
    }
    public void ScreenWidowed(bool isOn)
    {
        if (isOn)
        {
            SoundManager.Instance.PlaySFX("ui-click2-sfx", .5f);
            m_fullScreenselected.isOn = false;
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }
}
