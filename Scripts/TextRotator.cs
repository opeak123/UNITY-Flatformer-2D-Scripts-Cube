using UnityEngine;
using UnityEngine.UI;

public class TextRotator : MonoBehaviour
{
    public Text m_textOriginal;

    [TextArea(1,5)]
    public string[] m_textArray;

    private int m_currentIndex = 0;
    private float m_timeToChangeText = 1f;
    private float m_timer = 0f;

    private void Start()
    {
        m_textOriginal.text = m_textArray[0];
    }

    private void Update()
    {
        m_timer += Time.deltaTime;
        if (m_timer >= m_timeToChangeText)
        {
            m_timer = 0f;
            m_currentIndex = (m_currentIndex + 1) % m_textArray.Length;
            m_textOriginal.text = m_textArray[m_currentIndex];
        }
    }
}
