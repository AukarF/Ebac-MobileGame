using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LerpHelper : MonoBehaviour
{
    public Transform target;
    public float lerpSpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position,lerpSpeed * Time.deltaTime);
    }
}
