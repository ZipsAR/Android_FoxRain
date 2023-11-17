using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class InteractableCubes : MonoBehaviour
{
    
    Material materialInstance;
    float transparentAlpha = 0.25f;
    Color initialColor;

    void OnEnable()
    {
        materialInstance = this.GetComponent<MeshRenderer>().material;
        initialColor = materialInstance.color;
        StartCoroutine(FadeIn());
    }

    public void HighLighCubeInteraction()
    {
        StartCoroutine(FadeOut());
    }

    public void ResetVisuializations()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        Color tempColor = materialInstance.color;
        float additive = transparentAlpha;

        while (tempColor.a < 1)
        {
            additive += Time.deltaTime;
            tempColor = new Color(initialColor.r, initialColor.g, initialColor.b, additive);
            materialInstance.color = tempColor;

            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        Color tempColor = materialInstance.color;
        float sub = materialInstance.color.a;

        while (tempColor.a > transparentAlpha)
        {
            sub -= Time.deltaTime;
            tempColor = new Color(initialColor.r, initialColor.g, initialColor.b, sub);
            materialInstance.color = tempColor;

            yield return null;
        }
    }

    void DetectObjects()
    {
        Raycast hit;
        
        Vector3 origin = this.transform.position;
        Vector3 destination = this.transform.position - Camera.main.transform.position;
        if (Physics.SphereCast(origin, sphereRadius, destination, out hit, maxDistance))
        {
            hitPosition = hit.point;

            if (hit.transform.tag == "Interactable")
            {
                if (currentCube != hit.transform.GetComponent<InteractableCubes>())
                {
                    if (currentCube)
                    {
                        currentCube.ResetVisuializations();
                    }
                    currentCube = hit.transform.GetComponent<InteractableCubes>();
                    currentCube.HighLighCubeInteraction();
                }
            }
        }
        else
        {
            hitPosition = Vector3.zere;
            if (currentCube)
            {
                currentCube.ResetVisuializations();
            }
        }
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
*/