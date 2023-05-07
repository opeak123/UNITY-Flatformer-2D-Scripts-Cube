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

    //Image 1번
    public Image m_myImage;
    //Image 2번
    public Image m_yoursImage;
    //바꿀 이미지 yours
    public Sprite m_crusherImage;
    //바꿀 이미지 mine
    //public Sprite m_mineImage;

    //문자열 내용
    [TextArea(3, 8)]
    public string[] m_string;

    //대화중인지 여부 체크
    public bool pb_isTalking = false;
    //대화중인 현재 스트링 Index
    [SerializeField]
    private int m_currentIndex = 0;

    //Canvas 애니메이션
    private UIAnimation m_uiAni;

    private void Start()
    {
        //할당
        m_uiAni= FindObjectOfType<UIAnimation>();

        //String 초기화
        m_textMine.text = "";
        m_textYours.text = "";
    }

    private void Update()
    {
        if(pb_isTalking)
        {
            Talking();
        }
    }

    void Talking()
    {
        m_uiAni.TriggerOpen(); //Dialouge 컨버스 활성화 
        GameManager.Instance.canMove = false; //대화 중일 때 플레이어 행동 제어
        
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
            //else
            //{
            //    m_uiAni.TriggerClose();
            //    pb_isTalking = false;
            //}
        }
        //string배열의 text가 마지막배열이라면 인덱스를 처음으로 돌린다
        //현재 UI는 동시에 대화창을 띄워 순서만 바꾸는 형식
        //Text는 두개 모두 동시출력
        if (m_currentIndex == m_string.Length - 1)
        {
            m_currentIndex = 0;       //인덱스 처음으로 
            m_string = new string[0]; //배열 초기화
            
            //pb_isTalking = false;
            StartCoroutine(StandbyAction());
            StartCoroutine(UIClose());

            if (GameManager.Instance.currentStageNum == 0) 
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StageOneInteract();
                }
            }
        }
    }

    //대화가 끝나고 2초대기 이후 코루틴 실행
    IEnumerator StandbyAction() 
    {
        yield return new WaitForSecondsRealtime(3f);
        pb_isTalking = false;
        GameManager.Instance.canMove = true;
    }
    IEnumerator UIClose()
    {
        yield return new WaitForSeconds(5f);
        UIAnimation.FindObjectOfType<UIAnimation>().TriggerClose();
    }



    //애니메이션 상호작용
    //위 함수가 실행중일 때 게임매니저에서 플레이어 이동 제한
    void StageOneInteract()
    {
        PadUpTrigger.FindObjectOfType<PadUpTrigger>().pb_triggerEnd = true;
        ScreenAnimation.FindObjectOfType<ScreenAnimation>().TriggerWarning();
        StartCoroutine(DoorOpenDelay());
    }
    //애니메이션이 끝나고 코루틴을 통해 애니메이션 대기 실행
    IEnumerator DoorOpenDelay()
    {
        DoorAnimation.FindObjectOfType<DoorAnimation>().TriggerDoorOpen();
        yield return new WaitForSeconds(6f);
    }

}    