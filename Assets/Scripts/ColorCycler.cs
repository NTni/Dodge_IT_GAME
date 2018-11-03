using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCycler : MonoBehaviour
{

    public Color[] Colors;
    public float Speed = 5;
    int currentIndex = 0;
    Camera cam;
    bool shouldChange = false;

    void Start()
    {
        cam = GetComponent<Camera>();

        currentIndex = 0;
        SetColor(Colors[currentIndex]);
    }

    public void SetColor(Color color)
    {
        cam.backgroundColor = color;
    }

    public void Cycle()
    {
        shouldChange = true;
    }

    void Update()
    {
        if (shouldChange)
        {
            var startColor = cam.backgroundColor;

            var endColor = Colors[0];
            if (currentIndex + 1 < Colors.Length)
            {
                endColor = Colors[currentIndex + 1];
            }


            var newColor = Color.Lerp(startColor, endColor, Time.deltaTime * Speed);
            SetColor(newColor);

            if (newColor == endColor)
            {
                shouldChange = false;
                if (currentIndex + 1 < Colors.Length)
                {
                    currentIndex++;
                }
                else
                {
                    currentIndex = 0;
                }
            }
        }
    }
}
