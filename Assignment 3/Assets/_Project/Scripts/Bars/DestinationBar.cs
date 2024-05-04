using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestinationBar : MonoBehaviour
{
    public Slider slider;

    public void setMaxDistance(float distance)
    {
        slider.maxValue = distance;
        slider.value = distance;
    }

    public void setDistance(float distance)
    {
        if (distance <= slider.maxValue)
        {
            slider.value = distance;
        }
        else
        {
            slider.value = slider.maxValue;
        }
    }
}
