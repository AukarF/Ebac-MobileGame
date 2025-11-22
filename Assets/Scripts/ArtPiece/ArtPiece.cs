using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class ArtPiece : MonoBehaviour
{
    public GameObject currentArt;

    public void ChangePiece(GameObject piece)
    {
        if (currentArt != null) Destroy(currentArt);

        currentArt = Instantiate(piece, transform);
        currentArt.transform.localPosition = Vector3.zero;

        // APLICAR COR EM TODOS OS RENDERERS
        var renderers = currentArt.GetComponentsInChildren<Renderer>();

        foreach (var r in renderers)
        {
            r.material.SetColor("_Color", ColorManager.Instance.currentColor);
        }
    }

}
