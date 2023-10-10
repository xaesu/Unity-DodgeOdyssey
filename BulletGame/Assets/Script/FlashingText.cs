using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlashingText : MonoBehaviour
{
    public float flashingDuration = 3f;

    private Text textComponent;
    private float flashingTimer;
    private bool isFlashing;

    private void Start()
    {
        textComponent = GetComponent<Text>();
        flashingTimer = flashingDuration;

        isFlashing = true;

        // 코루틴 시작
        StartCoroutine(FlashText());
    }

    // 플래시 효과 코루틴
    private IEnumerator FlashText()
    {
        // 플래시 효과를 실행할 때
        while (isFlashing)
        {
            // 텍스트 컴포넌트 활성화/비활성화 반복
            textComponent.enabled = !textComponent.enabled;
            // 0.5초 대기
            yield return new WaitForSeconds(0.5f);
        }
    }

    // 지정 타이머 이후 플래시 효과 종료
    private void Update()
    {
        flashingTimer -= Time.deltaTime;
        if (flashingTimer <= 0)
        {
            isFlashing = false;
        }
    }
}
