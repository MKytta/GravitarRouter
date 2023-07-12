using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonVisuals : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform m_moved;

    void Start()
    {

    }

    private void MoveText(float yValue)
    {
        m_moved.Translate(0, yValue, 0);
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            MoveText(-4);
        }
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            MoveText(4);
        }
    }
}
