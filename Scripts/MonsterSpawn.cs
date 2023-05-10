using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField]
    MonsterInfo monsterInfo;

    [SerializeField]
    private GameObject m_normalMonsterPrefab;
    [SerializeField]
    private GameObject m_attackMonsterPrefab;
}
