using UnityEngine;

public class ScreenAnimation : MonoBehaviour
{
    //스크린 애니메이션 
    Animator m_ani;
    void Start()
    {
        //할당
        m_ani = GetComponent<Animator>();
    }
    public void TriggerMove()
    {
        //스크린의 move 애니메이션 활성화됐다면 order를 뒤로
        m_ani.SetTrigger("move");
        GetComponentInChildren<SpriteRenderer>().sortingOrder = -1;
    }
    public void TriggerWarning()
    {
        //스크린의 warning 애니메이션 활성화됐다면 order를 앞으로
        m_ani.SetTrigger("warning");
        GetComponentInChildren<SpriteRenderer>().sortingOrder = 2;
    }


}
