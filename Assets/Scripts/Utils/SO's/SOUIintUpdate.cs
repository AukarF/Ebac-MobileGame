using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class SOUIintUpdate : MonoBehaviour
{

    public SOInt soInt;
    public TextMeshProUGUI uiTextValue;

    private void Start()
    {
        uiTextValue.text = soInt.value.ToString();
    }

    private void Update()
    {
        uiTextValue.text = soInt.value.ToString();
    }
}
