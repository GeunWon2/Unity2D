using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIExpSlider : MonoBehaviour
{
    public UnitCore unit;
    public Slider slider;
    public UITextSetup textSlider;

    public void SliderSetup()
    {
        slider.maxValue = 100;
        slider.value = unit.GetExp();
        slider.minValue = 0;
        SetText();
    }

    public void SliderChange(int exp)
    {
        slider.value = exp;
        SetText();

    }

    public void SetText()
    {
        textSlider.SetText(slider.value + " / " + slider.maxValue);
    }
}
