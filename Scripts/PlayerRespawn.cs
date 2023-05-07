using System.Collections;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector2 m_respawnPos;
    private Transform m_playerPos;
    private ParticleSystem m_particle;

    private void Start()
    {
        m_playerPos = GameObject.FindGameObjectWithTag("PLAYER").transform;
        m_particle = m_playerPos.GetChild(0).GetComponent<ParticleSystem>();
        m_respawnPos = this.transform.position;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PLAYER"))
        {
            //m_playerPos.position = m_respawnPos;
            StartCoroutine(PlayerRevive());
        }
    }

    IEnumerator PlayerRevive()
    {
        GameManager.Instance.dead = true;
        GameManager.Instance.canMove = false;
        m_particle.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);
        GameManager.Instance.dead = false;
        GameManager.Instance.canMove = true;
        m_particle.gameObject.SetActive(false);
        m_playerPos.position = m_respawnPos;
    }
}
