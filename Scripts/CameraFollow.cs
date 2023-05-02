using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //카메라가 따라갈 타겟
    public Transform m_target;

    //카메라의 추적 속도 
    public float m_smoothSpeed = 0.125f;

    //카메라가 추적중인지 여부 
    public bool followTarget = true;
    private bool b_cameraStop = true;
    void LateUpdate()
    {
        if (followTarget)
        {   // 카메라가 따라갈 위치
            Vector3 desiredPosition = m_target.position + new Vector3(0, 0, -10);
            // 부드러운 이동을 위한 보간 계산
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, m_smoothSpeed);
            transform.position = smoothedPosition; 
        }

        if (GameManager.Instance.currentStageNum == 2 && b_cameraStop)
        {
            Camera.main.transform.position = new Vector3(transform.position.x + 4, transform.position.y, transform.position.z);
            b_cameraStop = false;
        }
    }
}
