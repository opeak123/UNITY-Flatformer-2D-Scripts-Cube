using System.Collections;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private CameraFollow m_cam;
    private float m_timer;
    private bool b_isArrived = false;
    private int m_cnt = 0;
    private void Start()
    {
        m_cam = FindObjectOfType<CameraFollow>();
    }

    private void Update()
    {
        if (b_isArrived)
        {
            float elapsedTime = Time.time - m_timer;
            Debug.Log("Elapsed time: " + elapsedTime);
        }
    }

    private void LateUpdate()
    {
        StartCoroutine(CameraTracePlayer());
    }

    IEnumerator CameraTracePlayer()
    {
        if (b_isArrived)
        {
            if (Time.time - m_timer > 7)
            {
                m_cam.m_target = FindObjectOfType<PlayerController>().transform;
                m_cam.m_smoothSpeed = 0.125f;
            }
            yield return null;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PLAYER") && m_cnt ==0)
        {
            ++m_cnt;
            b_isArrived = true;
            m_timer = Time.time;
            m_cam.m_target = GameObject.Find("RoadManager").transform;
            m_cam.m_smoothSpeed = 0.0015f;
            m_cam.followTarget = true;
        }
    }
}
