using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 spinCloads;
    [SerializeField] private float speed = 1f;
    [SerializeField] Light moonlight;
    [SerializeField] GameObject proceedButton;
    public Color startColor;
    public Color endColor;

    private void Start()
    {
        proceedButton.SetActive(false);
        if (moonlight != null) moonlight.color= startColor;
    }
    void Update()
    {
        transform.Rotate(spinCloads * speed * Time.deltaTime);
        if (moonlight == null) return;
        // lerp moonlight between red and white, red if rotation.x is 170 and white if rotation.x is 100
        if (transform.rotation.x > 170)
        {
            moonlight.color = Color.Lerp(startColor, endColor, (transform.rotation.x - 170) / 30, Time.deltaTime);
            proceedButton.SetActive(true);
        }
        else if (transform.rotation.x < 100)
        {
            moonlight.color = Color.Lerp(endColor, startColor, transform.rotation.x / 100 , Time.deltaTime);
        }
    }

}

