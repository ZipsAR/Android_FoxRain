using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public RectTransform Menu1;
    public RectTransform panelToMove; // 이동시킬 UI 패널
    public Vector2 startPosition; // 시작 위치
    public Vector2 targetPosition; // 목표 위치
    public float lerpTime = 1f; // 이동하는 데 걸리는 시간
    private bool isPanelMoved = false; // 패널의 이동 여부를 나타내는 플래그
    private float currentLerpTime; // 현재 Lerp 시간

    void Update()
    {
        if (isPanelMoved)
        {
            // 패널을 이동시킴
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            float t = currentLerpTime / lerpTime;
            t = t * t * t * (t * (6f * t - 15f) + 10f); // 보간값을 조절하여 부드러운 이동을 만듦

            panelToMove.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, t);
        }
        else
        {
            // 패널을 원래 위치로 되돌림
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            float t = currentLerpTime / lerpTime;
            t = t * t * t * (t * (6f * t - 15f) + 10f); // 보간값을 조절하여 부드러운 이동을 만듦
            if (Menu1.gameObject.GetComponent<Menu1Mng>().isPanelMoved1 || Menu1.gameObject.GetComponent<Menu1Mng>().isPanelMoved2)
            {
                Menu1.gameObject.GetComponent<Menu1Mng>().isPanelMoved1 = false;
                Menu1.gameObject.GetComponent<Menu1Mng>().isPanelMoved2 = false;
            }

            panelToMove.anchoredPosition = Vector2.Lerp(targetPosition, startPosition, t);
        }
    }

    public void TogglePanelMovement()
    {
        // 패널의 위치를 토글하여 이동 및 되돌리기
        isPanelMoved = !isPanelMoved;
        currentLerpTime = 0f; // Lerp 시간 초기화하여 패널을 이동시킴
    }
    public void ExitBtn()
    {
        Application.Quit();
    }
}
