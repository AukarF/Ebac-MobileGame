using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChange : MonoBehaviour
{
    public float duration = .2f;
    private Color _startColor;

    public Color startColor = Color.white;
    private Color _correctColor;

    public MeshRenderer meshRenderer;

    private void OnValidate() 
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        _startColor = meshRenderer.materials[0].GetColor("_Color");
        LerpColor();
    }

    private void LerpColor()
    {
        meshRenderer.materials[0].SetColor("_Color", startColor);
        meshRenderer.materials[0].DOColor(_correctColor, duration).SetDelay(.5f);
    }


    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.P))
        {
        //    LerpColor();
        }
    }


}
