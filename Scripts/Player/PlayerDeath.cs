using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem m_particle;

    private void Start()
    {
        m_particle = this.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>();  
        GameManager.OnPlayerDeath += OnPlayerDeath;
    }

    private void OnDestroy()
    {
        GameManager.OnPlayerDeath -= OnPlayerDeath;
    }

    void OnPlayerDeath()
    {
        StartCoroutine(DeathCoroutine());
    }

    IEnumerator DeathCoroutine()
    {
        GameManager.Instance.canMove = false;
        SoundManager.Instance.PlaySFX("player-revive-sfx", 1f);
        m_particle.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);
        GameManager.Instance.canMove = true;
        m_particle.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.layer)
        {
            case 12:    //Obstacle
                break;

            default:
                break;
        }

    }
}
