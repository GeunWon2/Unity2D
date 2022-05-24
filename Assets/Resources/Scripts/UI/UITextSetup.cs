using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITextSetup : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void SetText(string newText)
    {
        text.SetText(newText);
    }

    public void SetText(int newInt)
    {
        text.SetText(newInt.ToString());
    }
}
