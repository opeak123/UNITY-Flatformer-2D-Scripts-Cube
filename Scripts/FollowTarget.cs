using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private CameraFollow cam;
    private float timer;
    private void Start()
    {
        cam = FindObjectOfType<CameraFollow>();
    }

    private void Update()
    {

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PLAYER"))
        {
            cam.m_target = GameObject.Find("RoadManager").transform;
            cam.m_smoothSpeed = 0.0005f;
            cam.followTarget = true;
            GameManager.Instance.canMove = false;
        }
    }

}
