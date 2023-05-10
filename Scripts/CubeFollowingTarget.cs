using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CubeFollowingTarget : MonoBehaviour
{
    //큐브 애니메이션
    private Animator m_cubeAni;

    //큐브가 따라갈 타겟배열
    public GameObject[] m_targets = new GameObject[3];
    //큐브 SpriteRenderer
    private SpriteRenderer m_spriteRenderer;
    //큐브 Rigidbody2D
    private Rigidbody2D m_rigidbody;

    //타겟 배열의 인덱스 
    private int m_currentTargetIndex = 0;
    //큐브의 이동속도
    private float m_moveSpeed; //랜덤 0.5~ 0.8
    //타겟과의 거리 추적
    Vector2 m_dir;
    private void Start()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_cubeAni = GetComponent<Animator>();
        for(int i= 0; i < m_targets.Length; i++) 
        {
            m_targets[i] = GameObject.Find("TARGET").transform.GetChild(i).gameObject;
        }
    }

    private void LateUpdate()
    {
        FollowingTarget();
    }

    private void FollowingTarget()
    {
        if (m_currentTargetIndex >= m_targets.Length)
        {
            m_currentTargetIndex = 0;
        }

        m_dir = transform.position - m_targets[m_currentTargetIndex].transform.position;
        this.transform.position = Vector2.MoveTowards(transform.position, m_targets[m_currentTargetIndex].transform.position, 0.01f * m_moveSpeed * Time.deltaTime);

        if (m_dir.x > 0)
        {
            m_spriteRenderer.flipX = true;
        }
        else if (m_dir.x < 0)
        {
            m_spriteRenderer.flipX = false;
        }

        if (Vector2.Distance(transform.position, m_targets[m_currentTargetIndex].transform.position) < 0.05f)
        {
            m_currentTargetIndex++;
        }
        m_moveSpeed = Random.Range(300f, 500f);
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {

            case "GROUND":
                m_cubeAni.SetTrigger("run");
                break;

            default:
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        switch(col.gameObject.tag)
        {
            case "LADDER":
                m_cubeAni.SetTrigger("down");
                m_rigidbody.gravityScale = 0.2f;
                break;

            default:
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "GROUND":
                m_cubeAni.SetTrigger("run");
                break;

            default:
                break;
        }
    }
}
