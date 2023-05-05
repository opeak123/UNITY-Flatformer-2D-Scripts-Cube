using UnityEngine;

public class FadeCall : MonoBehaviour
{
    private void Update()
    {
        if (GameManager.Instance.currentStageNum == 3)
        {
            StartCoroutine(FadeInOut.FindObjectOfType<FadeInOut>().FadeIn());
        }
        Destroy(gameObject.GetComponent<FadeCall>(),7f);
    }
}
