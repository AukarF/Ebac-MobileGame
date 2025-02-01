using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class SOUIintUpdate2 : MonoBehaviour
{

    public SOInt2 soInt2;
    public TextMeshProUGUI uiTextValue2;

    private void Start()
    {
        uiTextValue2.text = soInt2.value.ToString();
    }

    private void Update()
    {
        uiTextValue2.text = soInt2.value.ToString();
    }
}

