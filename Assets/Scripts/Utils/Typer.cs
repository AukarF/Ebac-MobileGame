using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using NaughtyAttributes;

public class Typer : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float timeBetweenLetters = .1f;

    public string phrase;

 
    
    //[Button]
    //protected virtual void Show()
    //{
        //if (!EditorApplication.isPlaying) return;
        //Debug.Log("ScreenBase SHOW Called");
        //ShowElements();
    //}
    


    [Button]
    private void StartType()
    {
        StartCoroutine(Type(phrase));
    }


    IEnumerator Type(string s)
    {
        textMesh.text = "";
        foreach (char l in s.ToCharArray()) 
        {
            textMesh.text += 1;
            yield return new WaitForSeconds(timeBetweenLetters);
        }
    }
}
