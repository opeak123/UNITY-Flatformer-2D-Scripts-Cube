using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MonsterSpawn : MonoBehaviour
{
    MonsterInfo monsterInfo;

    [SerializeField]
    private GameObject m_normalMonsterPrefab;
    [SerializeField]
    private GameObject m_attackMonsterPrefab;
    private void Awake()
    {

    }

    private void MonsterSpawner()
    {
        Vector2 spawnPos = monsterInfo.monsterPos;
        MonsterInfo.MonsterType type = MonsterInfo.MonsterType.Normal;
        float monsterSpeed = monsterInfo.monsterSpeed;
    }
}
