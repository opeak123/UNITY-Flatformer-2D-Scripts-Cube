using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //DialogueManager 인스턴스 선언
    public static DialogueManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    //Text 1번
    public Text m_textMine; 
    //Text 2번
    public Text m_textYours;

    //문자열 내용
    [TextArea(3, 8)]
    public string[] m_string;

    //대화중인지 여부 체크
    public bool isTalking = false;
    //대화중인 현재 스트링 Index
    private int m_currentIndex = 0;

    private void Start()
    {
        //String 초기화
        m_textMine.text = "";
        m_textYours.text = "";
    }

    private void Update()
    {
        if(isTalking)
          Talking();
    }

    void Talking()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //currentIndex 가 string 배열의 크기보다 작다면
            if (m_currentIndex < m_string.Length)
            {
                //Text 부모의 자식
                //현재 대화창의 UI의 Order in Layer 순서를 바꾼다
                if (m_currentIndex % 2 == 0)
                {
                    m_textYours.transform.parent.SetSiblingIndex(2);
                    m_textMine.text = m_string[m_currentIndex];
                    m_textYours.text = "";
                }
                else
                {
                    m_textMine.transform.parent.SetSiblingIndex(2);
                    m_textYours.text = m_string[m_currentIndex];
                    m_textMine.text = "";
                }
                m_currentIndex++;
            }
            else
            {
                isTalking = false;
            }
        }
        //string배열의 text가 6번째라면 인덱스를 처음으로 돌린다
        //현재 UI는 동시에 대화창을 띄워 순서만 바꾸는 형식
        //(Text 둘다 동시출력)
        if(m_currentIndex == 6) 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Interact();
                m_currentIndex++;
            }
        }
    }

    //애니메이션 상호작용
    //위 함수가 실행중일 때 게임매니저에서 플레이어 이동 제한
    void Interact()
    {
        PadUpTrigger.FindObjectOfType<PadUpTrigger>().pb_triggerEnd = true;
        ScreenAnimation.FindObjectOfType<ScreenAnimation>().TriggerWarning();
        StartCoroutine(TriggerDoorOpenWithDelay(3f));
        GameManager.Instance.canMove = true;
    }

    //애니메이션이 끝나고 코루틴을 통해 애니메이션 대기 실행
    IEnumerator TriggerDoorOpenWithDelay(float delay)
    {
        UIAnimation.FindObjectOfType<UIAnimation>().TriggerClose();
        yield return new WaitForSeconds(delay);

        DoorAnimation.FindObjectOfType<DoorAnimation>().TriggerDoorOpen();
        yield return new WaitForSeconds(delay+delay);
    }
}    