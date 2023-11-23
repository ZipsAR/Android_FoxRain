using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu1Mng : MonoBehaviour
{
    public RectTransform panelToMove; // 이동시킬 UI 패널
    public RectTransform panelToMove2;// 이동시킬 UI 패널2
    public Vector2 startPosition; // 시작 위치
    public Vector2 targetPosition; // 목표 위치
    public float lerpTime = 1f; // 이동하는 데 걸리는 시간
    private float currentLerpTime; // 현재 Lerp 시간
    public float lerpTime2 = 1f; // 이동하는 데 걸리는 시간
    private float currentLerpTime2; // 현재 Lerp 시간
    public bool isPanelMoved1 = false; // 패널의 이동 여부를 나타내는 플래그
    public bool isPanelMoved2 = false; // 패널의 이동 여부를 나타내는 플래그

    void Update()
    {
        if (isPanelMoved1)
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

        }else if(!isPanelMoved1)
        {
            // 패널을 원래 위치로 되돌림
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            float t = currentLerpTime / lerpTime;
            t = t * t * t * (t * (6f * t - 15f) + 10f); // 보간값을 조절하여 부드러운 이동을 만듦

            panelToMove.anchoredPosition = Vector2.Lerp(targetPosition, startPosition, t);

        }
        if (isPanelMoved2)
        {
            // 패널을 이동시킴
            currentLerpTime2 += Time.deltaTime;
            if (currentLerpTime2 > lerpTime2)
            {
                currentLerpTime2 = lerpTime2;
            }

            float t = currentLerpTime2 / lerpTime2;
            t = t * t * t * (t * (6f * t - 15f) + 10f); // 보간값을 조절하여 부드러운 이동을 만듦

            panelToMove2.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, t);

        }else if (!isPanelMoved2)
        {
            // 패널을 원래 위치로 되돌림
            currentLerpTime2 += Time.deltaTime;
            if (currentLerpTime2 > lerpTime2)
            {
                currentLerpTime2 = lerpTime2;
            }

            float t = currentLerpTime2 / lerpTime2;
            t = t * t * t * (t * (6f * t - 15f) + 10f); // 보간값을 조절하여 부드러운 이동을 만듦

            panelToMove2.anchoredPosition = Vector2.Lerp(targetPosition, startPosition, t);

        }

    }

    public void TogglePanelMovement1()
    {
        //panelToMove.gameObject.SetActive(true);
        //panelToMove2.gameObject.SetActive(true);
        // 패널의 위치를 토글하여 이동 및 되돌리기
        isPanelMoved1 = !isPanelMoved1;
        if(isPanelMoved1) isPanelMoved2 = false;
        currentLerpTime = 0f; // Lerp 시간 초기화하여 패널을 이동시킴
        currentLerpTime2 = 0f; // Lerp 시간 초기화하여 패널을 이동시킴
    }
    public void TogglePanelMovement2()
    {
        //panelToMove2.gameObject.SetActive(true);
        //panelToMove.gameObject.SetActive(true);
        isPanelMoved2 = !isPanelMoved2;
        if (isPanelMoved2) isPanelMoved1 = false;
        currentLerpTime = 0f; // Lerp 시간 초기화하여 패널을 이동시킴
        currentLerpTime2 = 0f; // Lerp 시간 초기화하여 패널을 이동시킴
    }
}
