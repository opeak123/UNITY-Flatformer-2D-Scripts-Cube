using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadUpTrigger : MonoBehaviour
{
    private Animator m_ani;
    private SpriteRenderer m_spriteRenderer;
    public NextStage stage_script;
    public bool pb_triggerEnd = false;
    int m_count = 0;

    private void Start()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_ani = GetComponent<Animator>();
    }
    private void Update()
    {
        if (pb_triggerEnd)
            transform.position = new Vector2(1.16f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PLAYER"))
        {
            m_spriteRenderer.enabled = true;
            m_ani.enabled = true;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!pb_triggerEnd && m_count == 0)
        {
            if (collision.gameObject.CompareTag("PLAYER")
            && Input.GetKey(KeyCode.UpArrow))
            {
                if (PlayerController.FindObjectOfType<PlayerController>().pb_isCrouch == false)
                {
                    DialogueManager.Instance.pb_isTalking = true;
                    m_count++;
                    Interact();
                }
            }
        }
        if (collision.gameObject.CompareTag("PLAYER") && pb_triggerEnd && Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("pressed");
            FadeController.FindObjectOfType<FadeController>().FadeOutIn();
            StartCoroutine(NextSceneDelay());
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PLAYER"))
        {
            m_spriteRenderer.enabled = false;
            m_ani.enabled = false;
        }
    }

    private void Interact()
    {
        PlayerController.FindObjectOfType<PlayerController>().pb_isCrouch = false;
        ScreenAnimation.FindObjectOfType<ScreenAnimation>().TriggerMove();
        PlayerAnimation playerAni = FindObjectOfType<PlayerAnimation>();
        playerAni.SetIsGrounded(false);
        playerAni.TriggerLookingUp();

        m_spriteRenderer.enabled = false;
    }

    IEnumerator NextSceneDelay()
    {
        yield return new WaitForSeconds(5f);
        PlayerController.FindObjectOfType<PlayerController>().gameObject.transform.position = new Vector2(1.553f, 0);
        GameManager.Instance.isNextStage = true;
    }
}
