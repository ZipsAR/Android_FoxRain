using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu1Mng : MonoBehaviour
{
    public RectTransform panelToMove; // �̵���ų UI �г�
    public RectTransform panelToMove2;// �̵���ų UI �г�2
    public Vector2 startPosition; // ���� ��ġ
    public Vector2 targetPosition; // ��ǥ ��ġ
    public float lerpTime = 1f; // �̵��ϴ� �� �ɸ��� �ð�
    private float currentLerpTime; // ���� Lerp �ð�
    public float lerpTime2 = 1f; // �̵��ϴ� �� �ɸ��� �ð�
    private float currentLerpTime2; // ���� Lerp �ð�
    public bool isPanelMoved1 = false; // �г��� �̵� ���θ� ��Ÿ���� �÷���
    public bool isPanelMoved2 = false; // �г��� �̵� ���θ� ��Ÿ���� �÷���

    void Update()
    {
        if (isPanelMoved1)
        {
            // �г��� �̵���Ŵ
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            float t = currentLerpTime / lerpTime;
            t = t * t * t * (t * (6f * t - 15f) + 10f); // �������� �����Ͽ� �ε巯�� �̵��� ����

            panelToMove.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, t);

        }else if(!isPanelMoved1)
        {
            // �г��� ���� ��ġ�� �ǵ���
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            float t = currentLerpTime / lerpTime;
            t = t * t * t * (t * (6f * t - 15f) + 10f); // �������� �����Ͽ� �ε巯�� �̵��� ����

            panelToMove.anchoredPosition = Vector2.Lerp(targetPosition, startPosition, t);

        }
        if (isPanelMoved2)
        {
            // �г��� �̵���Ŵ
            currentLerpTime2 += Time.deltaTime;
            if (currentLerpTime2 > lerpTime2)
            {
                currentLerpTime2 = lerpTime2;
            }

            float t = currentLerpTime2 / lerpTime2;
            t = t * t * t * (t * (6f * t - 15f) + 10f); // �������� �����Ͽ� �ε巯�� �̵��� ����

            panelToMove2.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, t);

        }else if (!isPanelMoved2)
        {
            // �г��� ���� ��ġ�� �ǵ���
            currentLerpTime2 += Time.deltaTime;
            if (currentLerpTime2 > lerpTime2)
            {
                currentLerpTime2 = lerpTime2;
            }

            float t = currentLerpTime2 / lerpTime2;
            t = t * t * t * (t * (6f * t - 15f) + 10f); // �������� �����Ͽ� �ε巯�� �̵��� ����

            panelToMove2.anchoredPosition = Vector2.Lerp(targetPosition, startPosition, t);

        }

    }

    public void TogglePanelMovement1()
    {
        //panelToMove.gameObject.SetActive(true);
        //panelToMove2.gameObject.SetActive(true);
        // �г��� ��ġ�� ����Ͽ� �̵� �� �ǵ�����
        isPanelMoved1 = !isPanelMoved1;
        if(isPanelMoved1) isPanelMoved2 = false;
        currentLerpTime = 0f; // Lerp �ð� �ʱ�ȭ�Ͽ� �г��� �̵���Ŵ
        currentLerpTime2 = 0f; // Lerp �ð� �ʱ�ȭ�Ͽ� �г��� �̵���Ŵ
    }
    public void TogglePanelMovement2()
    {
        //panelToMove2.gameObject.SetActive(true);
        //panelToMove.gameObject.SetActive(true);
        isPanelMoved2 = !isPanelMoved2;
        if (isPanelMoved2) isPanelMoved1 = false;
        currentLerpTime = 0f; // Lerp �ð� �ʱ�ȭ�Ͽ� �г��� �̵���Ŵ
        currentLerpTime2 = 0f; // Lerp �ð� �ʱ�ȭ�Ͽ� �г��� �̵���Ŵ
    }
}
