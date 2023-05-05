using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Information/Monster", order = 0)]

public class MonsterInfo : ScriptableObject
{
    public enum MonsterType { Normal, Attack }

    private MonsterType m_monsterType;
    private Vector2 m_monsterPos;
    private GameObject m_normalMoster;
    private GameObject m_attackMoster;
    private float m_monsterSpeed;
    //private float m_monsterRespawnDelay;

    public MonsterType monsterType { get { return m_monsterType; } }
    public Vector2 monsterPos { get { return m_monsterPos; } }
    public GameObject m_normalMonster(MonsterType type) { return m_normalMoster; }
    public GameObject m_attackMonster(MonsterType type) { return m_attackMoster; }

    public float monsterSpeed { get { return m_monsterSpeed; } }
    //public float mosterRespawnDelay { get { return m_monsterRespawnDelay; } }

    private void OnEnable()
    {
        m_monsterType = MonsterType.Normal;
        m_monsterPos = Vector2.zero;
        m_normalMoster = null;
        m_attackMoster = null;
        m_monsterSpeed = 0f;
        //m_monsterRespawnDelay = 0f;
    }
}
