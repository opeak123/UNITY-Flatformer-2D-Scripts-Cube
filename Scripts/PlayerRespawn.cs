using System.Collections;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector2 m_respawnPos;
    private Transform m_playerPos;

    private void Start()
    {
        m_playerPos = GameObject.FindGameObjectWithTag("PLAYER").transform;
        m_respawnPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("PLAYER"))
        {
            StartCoroutine(SetPlayerPosition());
        }
    }

    IEnumerator SetPlayerPosition()
    {
        GameManager.Instance.dead = true;

        yield return new WaitForSeconds(1f);
        GameManager.Instance.dead = false;
        m_playerPos.position = m_respawnPos;
    }
}
