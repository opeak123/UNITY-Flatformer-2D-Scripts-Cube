using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatActive : MonoBehaviour
{
    //오브젝트 활성화 시간 
    [SerializeField]
    private float activeTime = 1f;

    //시간 체크 
    [SerializeField]
    private float timer = 0f;

    //오브젝트 자식 SpriteRenderer
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        //할당
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Repeat();
    }

    void Repeat()
    {
        //시간체크
        timer += Time.deltaTime;

        if (timer >= activeTime)
        {   
            //시간 초기화
            //오브젝트가 활성화 됐으면 비활성화
            //비활성화 됐다면 활성화
            spriteRenderer.enabled = !spriteRenderer.enabled; 
            timer = 0f;
        }
    }
}








