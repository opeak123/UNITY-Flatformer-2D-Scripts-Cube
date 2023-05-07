using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private PlayerRespawn m_respawn;
    private void Awake()
    {
        m_respawn = GameObject.FindGameObjectWithTag("RESPAWN").GetComponent<PlayerRespawn>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PLAYER"))
        {
            m_respawn.m_respawnPos = this.gameObject.transform.position;
        }
    }
}