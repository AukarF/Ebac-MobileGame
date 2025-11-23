using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using DG.Tweening;
using UnityEditor;
using System;

namespace Screens
{

    public enum Screentype
    {
        Panel,
        Info_Panel,
        Shop
    }


    public class NewMonoBehaviourScript : MonoBehaviour
    {
        public Screentype screentype;

        public List<Transform> listofobjects;
        public List<Typer> listofphrases;

        public Image uiBackground;
        public bool startHided = false;

        [Header("Animations")]
        public float delayBetweenObjects = 0.5f;
        public float animationDuration = 3f;


        private void Start()
        {
            if (startHided)
            {
                HideObjects();
            }
        }




        [Button]
        protected virtual void Show()
        {
           //if (!EditorApplication.isPlaying) return;
           //Debug.Log("ScreenBase SHOW Called");
           //ShowElements();
                                  
            

            ShowObjects();
            Debug.Log("Show");
        }

        private void ShowElements()
        {
            throw new NotImplementedException();
        }

        [Button]
        protected virtual void Hide()
        {
            Debug.Log("Hide");
            HideObjects();
        }

        private void HideObjects()
        {
            listofobjects.ForEach(i => i.gameObject.SetActive(false));
            uiBackground.enabled = false;
        }

        private void ShowObjects()
        {
            for (int i = 0; i < listofobjects.Count; i++)
            {
                var obj = listofobjects[i];

                obj.gameObject.SetActive(true);
                obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects);
            }

            Invoke(nameof(StartType), delayBetweenObjects * listofobjects.Count);
            uiBackground.enabled = true;

        }

        private void StartType()
        {
            for (int i = 0; i < listofphrases.Count; i++)
            {
                listofphrases[i].StartType();
            }
        }

        private void ForceShowObjects()
        {
            listofobjects.ForEach(i => i.gameObject.SetActive(true));
                uiBackground.enabled = true;
        }

    }
}