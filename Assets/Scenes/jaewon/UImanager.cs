using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public RectTransform Menu1;
    public RectTransform panelToMove; // �̵���ų UI �г�
    public Vector2 startPosition; // ���� ��ġ
    public Vector2 targetPosition; // ��ǥ ��ġ
    public float lerpTime = 1f; // �̵��ϴ� �� �ɸ��� �ð�
    private bool isPanelMoved = false; // �г��� �̵� ���θ� ��Ÿ���� �÷���
    private float currentLerpTime; // ���� Lerp �ð�

    void Update()
    {
        if (isPanelMoved)
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
        }
        else
        {
            // �г��� ���� ��ġ�� �ǵ���
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            float t = currentLerpTime / lerpTime;
            t = t * t * t * (t * (6f * t - 15f) + 10f); // �������� �����Ͽ� �ε巯�� �̵��� ����
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
        // �г��� ��ġ�� ����Ͽ� �̵� �� �ǵ�����
        isPanelMoved = !isPanelMoved;
        currentLerpTime = 0f; // Lerp �ð� �ʱ�ȭ�Ͽ� �г��� �̵���Ŵ
    }
    public void ExitBtn()
    {
        Application.Quit();
    }
}
