using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHPSlider : MonoBehaviour
{
    public UnitCore unit;
    public Slider slider;
    public UITextSetup textSlider;

    public void SliderSetup()
    {
        slider.maxValue = unit.GetHP();
        slider.value = slider.maxValue;
        slider.minValue = 0;
        SetText();
    }

    public void SliderChange(int damage)
    {
        slider.value += damage;

        SetText();

    }

    public void SetText()
    {
        textSlider.SetText(slider.value + " / " + slider.maxValue);
    }

}
