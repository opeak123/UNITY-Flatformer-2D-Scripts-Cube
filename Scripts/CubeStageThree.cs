using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStageThree : MonoBehaviour
{
    private Vector2 m_target;
    private float m_moveSpeed = 5f;

    private void Start()
    {
        m_target = GameObject.Find("TARGET").transform.GetChild(0).transform.position;

    }
    void LateUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, m_target, m_moveSpeed * Time.deltaTime);
        transform.parent = GameObject.Find("TARGET").transform;
    }
}
