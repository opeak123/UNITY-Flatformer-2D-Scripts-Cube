using System.Collections;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private CameraFollow cam;
    private float timer;
    private void Start()
    {
        cam = FindObjectOfType<CameraFollow>();
    }

    private void LateUpdate()
    {
        StartCoroutine(CameraTracePlayer());
    }
    
    IEnumerator CameraTracePlayer()
    {
        timer = Time.time;
        if(timer > 7)
        {
            cam.m_target = FindObjectOfType<PlayerController>().transform;
            cam.m_smoothSpeed = 0.125f;
        }
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PLAYER"))
        {
            cam.m_target = GameObject.Find("RoadManager").transform;
            cam.m_smoothSpeed = 0.003f;
            cam.followTarget = true;
        }
    }

}
