using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using NaughtyAttributes;
using UnityEditor;
using System;

public class Typer : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float timeBetweenLetters = .1f;

    public string phrase;


    private void Awake()
    {
        textMesh.text = "l";
    }

    [Button]
    protected virtual void Show()
    {
     if (!EditorApplication.isPlaying) return;
     Debug.Log("ScreenBase SHOW Called");
     ShowElements();
    }

    private void ShowElements()
    {
        throw new NotImplementedException();
    }

    [NaughtyAttributes.Button]
    public void StartType()
    {
        StartCoroutine(Type(phrase));
    }


    IEnumerator Type(string s)
    {
        textMesh.text = "";
        foreach (char l in s.ToCharArray()) 
        {
            textMesh.text += l;
            yield return new WaitForSeconds(timeBetweenLetters);
        }
    }
}
