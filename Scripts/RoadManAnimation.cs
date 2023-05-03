using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManAnimation : MonoBehaviour
{
    private Rigidbody2D m_rigidbody;
    private Animator m_animator;
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    public void BooleanFly()
    {
        m_animator.SetBool("fly", true);
        m_rigidbody.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
    }
}
