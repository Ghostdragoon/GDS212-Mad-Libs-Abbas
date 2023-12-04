using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 spinCloads;
    [SerializeField] private float speed = 1f;
    [SerializeField] private Light moonlight;
    [SerializeField] private Light moonlight2;
    [SerializeField] private GameObject proceedButton;
    public Color startColor;
    public Color endColor;

    private float rotationProgress = 0f;

    private void Start()
    {
        proceedButton.SetActive(false);
        if (moonlight != null) moonlight.color = startColor;
    }

    void Update()
    {
        transform.Rotate(spinCloads * speed * Time.deltaTime);

        if (moonlight == null) return;

        // Increment rotation progress over time
        rotationProgress += speed * Time.deltaTime;

        // Lerp moonlight between red and white, red if rotation.x is 170 and white if rotation.x is 100
        float t = Mathf.InverseLerp(100f, 170f, rotationProgress);

        moonlight.color = Color.Lerp(startColor, endColor, t);
        moonlight2.color = Color.Lerp(startColor, endColor, t);

        if (rotationProgress > 170)
        {
            proceedButton.SetActive(true);
        }
        else if (rotationProgress < 100)
        {
            proceedButton.SetActive(false);
        }
    }
}


