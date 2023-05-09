using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    //Door 애니메이터 
    Animator doorAni;
    //문이 열렸는지 체크
    public bool isDoorOpened = false;
    
    private void Start()
    {
        //할당
        doorAni = GetComponent<Animator>();
        //애니메이션 속도 초기화
        doorAni.speed = 0f;
    }
    public void TriggerDoorOpen()
    {
        //Open
        doorAni.speed = 1f;
        isDoorOpened = true;
        doorAni.SetTrigger("doorOpen");
        SoundManager.Instance.PlaySFX("door-open-sfx",.5f);
    }

    public void TriggerDoorClose()
    {
        //Close
        doorAni.speed = -1f;
        isDoorOpened = false;
        doorAni.SetTrigger("doorOpen");
    }

}
