using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string message;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (TooltipManager._instance != null)
        {
            TooltipManager._instance.SetAndShowToolTip(message);
        }
        else
        {
            Debug.LogWarning("TooltipManager instance is null. Cannot display tooltip.");
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (TooltipManager._instance != null)
        {
            TooltipManager._instance.HideToolTip();
        }
        else
        {
            Debug.LogWarning("TooltipManager instance is null. Cannot hide tooltip.");
        }
    }
}
