using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class PinchHandler : MonoBehaviour
{
    public GameObject objectA;
    public GameObject handSkeleton;
    private bool isPinch;
    private MeshRenderer meshRenderer;

    void Start()
    {
        isPinch = false;
        meshRenderer = objectA.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (isPinch == false && ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_trigger == ManoGestureTrigger.PICK)
        {
            isPinch = true;
            // isPinch 시각적 체크용
            Color newColor = new Color(UnityEngine.Random.Range(0f,1f), UnityEngine.Random.Range(0f,1f), UnityEngine.Random.Range(0f,1f), 1f);
            meshRenderer.material.color = newColor;
        }

        if (isPinch == true && ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_trigger == ManoGestureTrigger.DROP)
        {
            isPinch = false;
            // isPinch 시각적 체크용
            Color newColor = new Color(UnityEngine.Random.Range(0f,1f), UnityEngine.Random.Range(0f,1f), UnityEngine.Random.Range(0f,1f), 1f);
            meshRenderer.material.color = newColor;
        }
    }

    void OnTriggerStay(Collider other)
    {
        // 엄지 충돌여부 시각적 체크용
        if (other.gameObject.name == "ThumbTip")
        {
            Color newColor = new Color(UnityEngine.Random.Range(0f,1f), UnityEngine.Random.Range(0f,1f), UnityEngine.Random.Range(0f,1f), 1f);
            meshRenderer.material.color = newColor;
        }
        
        // Pinch중이면서 A와 엄지가 닿고 있을 때, A의 위치를 엄지의 위치로 이동
        if (other.gameObject.name == "ThumbTip" && isPinch)
        
        {
            objectA.transform.position = other.transform.position;
        }
    }
}