using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resoulution : MonoBehaviour
{
    List<int> widths = new List<int>() { 1024, 1280, 1600 };
    List<int> heights = new List<int>() { 768, 768, 1200 };
    public Dropdown m_dropdown;

    public void SetResolution()
    {
        if (m_dropdown.value == 0)
        {
            Screen.SetResolution(1280, 768, Screen.fullScreenMode);
            
        }
        else if (m_dropdown.value == 1)
        {
            Screen.SetResolution(1024, 768, Screen.fullScreenMode);
        }
        else if (m_dropdown.value == 2)
        {
            Screen.SetResolution(1600, 1200, Screen.fullScreenMode);
        }

    }
}
