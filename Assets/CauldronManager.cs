using UnityEngine;

public class CauldronManager : MonoBehaviour
{
    public GameObject bubblingEffect;
    public GameObject[] objectsToDisappear;

    public void PutObjectInCauldron(GameObject objectToPut)
    {
       
        if (bubblingEffect != null)
        {
            bubblingEffect.SetActive(true);
        }

        if (objectToPut != null)
        {
            objectToPut.SetActive(false);
        }
    }
}
