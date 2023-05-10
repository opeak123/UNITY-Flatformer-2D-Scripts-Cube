using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{


    //SoundManager.Instance.PlaySFX("player-revive-sfx", 1f);


    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "OBSTACLE":
                GameManager.Instance.dead = true;

                break;


            default :
                break;
        }

    }
}