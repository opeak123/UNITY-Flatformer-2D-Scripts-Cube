using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCUBE : MonoBehaviour
{
    public GameObject cube;
    private int m_time;
    private float m_elapsedTime = 0f;

    void LateUpdate()
    {
        m_elapsedTime += Time.deltaTime; 

        if (m_elapsedTime >= m_time)
        {
            int count = (int)(m_elapsedTime / m_time);

            for (int i = 0; i < count; i++)
            {
                Instantiate(cube, transform.position, Quaternion.identity);
            }

            m_elapsedTime -= count * m_time;
            m_time = Random.Range(3, 5);
        }
    }

}
