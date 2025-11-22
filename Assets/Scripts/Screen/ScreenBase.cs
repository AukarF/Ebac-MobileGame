using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using DG.Tweening;

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
            ShowObjects();
            Debug.Log("Show");
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
        }

        private void ShowObjects()
        {
            for (int i = 0; i < listofobjects.Count; i++)
            {
                var obj = listofobjects[i];

                obj.gameObject.SetActive(true);
                obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects);
            }
        }

        private void ForceShowObjects()
        {
            listofobjects.ForEach(i => i.gameObject.SetActive(true));
        }

    }
}