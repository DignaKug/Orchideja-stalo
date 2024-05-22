using UnityEngine;

public class CauldronManager : MonoBehaviour
{
    public GameObject bubblingEffect;
    public GameObject[] objectsToDisappear;

    public void PutObjectInCauldron(GameObject objectToPut)
    {
        // Play bubbling animation
        if (bubblingEffect != null)
        {
            bubblingEffect.SetActive(true);
        }

        // Make the specific object disappear
        if (objectToPut != null)
        {
            objectToPut.SetActive(false);
        }
    }
}
