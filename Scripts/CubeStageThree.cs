using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStageThree : MonoBehaviour
{
    private Vector2 m_target;
    private float m_random;

    private void Start()
    {
        m_target = GameObject.Find("TARGET").transform.GetChild(0).transform.position;

    }
    void LateUpdate()
    {
        m_random = Random.Range(0.015f, 0.03f);
        transform.position = Vector2.MoveTowards(transform.position, m_target, m_random);
        transform.parent = GameObject.Find("TARGET").transform;
    }
}
