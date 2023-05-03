using UnityEngine;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    //인스턴스 선언 
    public static GameManager Instance;
    //플레이어 이동 제한
    public bool canMove = true;
    public bool dead = false;
    # region 싱글톤
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != null)
        {
            Destroy(Instance);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    #region 스테이지
    public GameObject[] stages;
    public bool isNextStage = false;
    public int currentStageNum = 0;

    private void Update()
    {
        if (isNextStage)
        {
            if (currentStageNum < stages.Length - 1)
            {
                ActivateStage(currentStageNum + 1);
                DestroyImmediate(stages[currentStageNum - 1]);
            }
            else
            {
                Debug.Log("All stages cleared!");
            }
            isNextStage = false;
        }
    }

    public void ActivateStage(int index)
    {
        if (currentStageNum < stages.Length)
        {
            stages[currentStageNum].SetActive(false);
        }

        stages[index].SetActive(true);
        currentStageNum = index;
    }
    #endregion
}