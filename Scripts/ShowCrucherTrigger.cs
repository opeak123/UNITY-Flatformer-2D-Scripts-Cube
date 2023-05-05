using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCrucherTrigger : MonoBehaviour
{
    public Image m_yoursImage;
    public Sprite m_crusherImage;
    private Rigidbody2D m_rigidBody;
    private UIAnimation m_uiAni;
    private int m_cnt = 0;
    

    private void Start()
    {
        m_uiAni = FindObjectOfType<UIAnimation>();
        m_rigidBody = gameObject.transform.GetChild(0).GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "PLAYER":

                DialogueReset();
                if(m_cnt ==0)
                {
                    ++m_cnt;
                    DialogueManager.Instance.pb_isTalking = true;
                    
                }
                //m_uiAni.TriggerOpen();
                m_rigidBody.gravityScale = 1f;

                break;


            default:
                break;
        
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "PLAYER":
                DialogueManager.Instance.pb_isTalking = false;
                break;

            default:
                break;

        }
    }

    private void DialogueReset()
    {
        DialogueManager.Instance.m_string = new string[5];
        DialogueManager.Instance.m_textMine.text = "";
        DialogueManager.Instance.m_textYours.text = "";
        DialogueManager.Instance.m_string[0] = "Watch Out, you almost crushed";
        DialogueManager.Instance.m_string[1] = "Oh,look, a small, unarmed cub Get out of my way!";
        DialogueManager.Instance.m_string[2] = "Can i just get by?";
        DialogueManager.Instance.m_string[3] = "Negative";
        DialogueManager.Instance.m_string[4] = "";
        m_yoursImage.sprite = m_crusherImage;
    }
}
