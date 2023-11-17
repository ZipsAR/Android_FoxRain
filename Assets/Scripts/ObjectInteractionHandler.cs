using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using static UnityEngine.Random;
using UnityEngine.UI;

[RequireComponent(typeof(MeshRenderer))]
public class ObjectInteractionHandler : MonoBehaviour
{

    void OnEnable()
    {
        meshRenderer = this.GetComponent<MeshRenderer>();
        ManomotionManager.OnManoMotionFrameProcessed += HandleManoMotionFrameProcessed;
    }

    #region Instruction Rules

    [SerializeField]
    const int maxInteractionTimes = 3;
    [SerializeField]
    ManoGestureTrigger interactionTrigger = ManoGestureTrigger.CLICK;
    private int currentInteractionCounter = 0;

    #endregion

    #region Components

    [SerializeField]
    GameObject gestureAnimation;
    [SerializeField]
    GameObject infoText;

    private MeshRenderer meshRenderer;

    #endregion

    void HandleManoMotionFrameProcessed()
    {
        HandInfo currentHandInfo = ManomotionManager.Instance.Hand_infos[0].hand_info;

        if (currentHandInfo.gesture_info.mano_gesture_trigger == interactionTrigger)
        {
            if (currentInteractionCounter < maxInteractionTimes)
            {
                currentInteractionCounter ++;

            }
            else
            {
                gestureAnimation.gameObject.SetActive(false);
                infoText.gameObject.SetActive(false);
                Handheld.Vibrate();
            }

            ChangeColor();
        }
    }

    void ChangeColor()
    {
        Color newColor = new Color(UnityEngine.Random.Range(0f,1f), UnityEngine.Random.Range(0f,1f), UnityEngine.Random.Range(0f,1f), 1f);
        meshRenderer.material.color = newColor;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
