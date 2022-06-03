using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private GameObject rightSlot;

    private Vector3 itemPosition;
    private Transform itemParent;
    private bool finish;
    private AudioSource audioSource;
    public static GameObject itemDragged;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!finish)
        {
            itemDragged = gameObject;
            itemPosition = transform.position;
            itemParent = transform.parent;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!finish)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!finish)
        {
            itemDragged = null;
            itemParent = transform.parent;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            if (itemParent == rightSlot.transform)
            {
                audioSource = GetComponent<AudioSource>();
                audioSource.Play();
                transform.position = itemPosition;
                finish = true;
                GameObject.Find("Menu").GetComponent<CompletionLvl>().AddPoint();
            }
            else
            {
                transform.position = itemPosition;
            }
            GameObject.Find("Menu").GetComponent<CompletionLvl>().TakeMove();
        }
    }
}
