using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoredCrusher : MonoBehaviour
{
    public GameObject m_bulletPrefab;
    private Transform m_firePos;

    private Animator m_dustAni;
    private Transform m_crucherTransform;
    private Transform m_playerTransform;
    private float m_moveSpeed = 3f;
    private bool b_crusherisGround = false;
    private bool b_crusherFloowing = false;
    public bool b_crusherFire = false;
    Coroutine firingCoroutine;

    private void Start()
    {
        m_firePos = gameObject.transform.GetChild(0).gameObject.GetComponent<Transform>();
        m_crucherTransform = transform;
        m_playerTransform = FindObjectOfType<PlayerController>().transform;
        m_dustAni = transform.GetChild(1).GetComponent<Animator>();
    }

    private void Update()
    {
        CrusherTracePlayer();

        if (b_crusherFire)
        {
            CrusherAttack();
        }
    }

    void CrusherTracePlayer()
    {
        Vector2 targetPosition = new Vector2(m_playerTransform.position.x, m_crucherTransform.position.y);
        if (b_crusherisGround && b_crusherFloowing && !DialogueManager.Instance.pb_isTalking)
        {
            m_crucherTransform.position = Vector2.MoveTowards(m_crucherTransform.position, targetPosition, m_moveSpeed * Time.deltaTime);
        }
    }
    void CrusherAttack()
    {
        if (firingCoroutine == null && !DialogueManager.Instance.pb_isTalking)
        {
            firingCoroutine = StartCoroutine(FireBullets());
        }
    }

    IEnumerator FireBullets()
    {
        while (true)
        {
            GameObject go = Instantiate(m_bulletPrefab, m_firePos.position, Quaternion.identity);
            go.gameObject.transform.parent = m_firePos.transform;
            Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
            rb.velocity = BulletParabola();
            if(b_crusherFire)
            {
                SoundManager.Instance.PlaySFX("armoredCrusher-fire-sfx", 1f);
            }
            yield return new WaitForSeconds(1f);
            Destroy(go);
        }
    }

    Vector2 BulletParabola()
    {
        float angle = -20f; // 발사 각도
        float speed = 3.5f; // 발사 속력
        float gravity = Physics2D.gravity.magnitude; // 중력 가속도

        // x 방향으로 일정한 속력
        // y 방향으로 중력 가속도
        float radian = angle * Mathf.Deg2Rad;
        float xSpeed = speed * Mathf.Cos(radian);
        float ySpeed = speed * Mathf.Sin(radian);

        float totalTime = (2f * ySpeed) / gravity;
        float maxHeight = (ySpeed * ySpeed) / (2f * gravity);

        Vector2 velocity = new Vector2(-xSpeed, ySpeed - (gravity * totalTime));

        return velocity;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "GROUND":
                SoundManager.Instance.PlaySFX("armoredCrusher-hit-ground-sfx", 1f);
                b_crusherisGround = true;
                transform.GetChild(1).gameObject.SetActive(true);
                RoadManAnimation.FindObjectOfType<RoadManAnimation>().BooleanFly();
                StartCoroutine(Active());
                GameObject.Find("TARGET").gameObject.SetActive(false);
                break;

            default:
                break;
        }
    }

    IEnumerator Active()
    {
        yield return new WaitForSeconds(0.5f);
        transform.GetChild(1).gameObject.SetActive(false);

        yield return new WaitForSecondsRealtime(4.2f);
        SoundManager.Instance.PlaySFX("armoredCrusher-follwing-sfx", 1f);
        b_crusherFloowing = true;

        yield return new WaitForSecondsRealtime(1f);
        b_crusherFire = true;
    }

}