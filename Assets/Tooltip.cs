using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string message;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        TooltipManager._instance.SetAndShowToolTip(message);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        TooltipManager._instance.HideToolTip();
    }
}
