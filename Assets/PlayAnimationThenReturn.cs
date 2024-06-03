using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayAnimationThenReturn : MonoBehaviour
{
    public string previousSceneName; 
    public float animationDuration;  

    private Image imageComponent;

    private void Start()
    {
       
        imageComponent = GetComponent<Image>();

      
        if (imageComponent == null)
        {
            Debug.LogError("Image component not found! Please attach this script to a GameObject with an Image component.");
            return;
        }


        imageComponent.enabled = false;

        StartCoroutine(PlayAnimationAndReturn());
    }

    private IEnumerator PlayAnimationAndReturn()
    {
       
        imageComponent.enabled = true;

       
        yield return new WaitForSeconds(animationDuration);

       
        imageComponent.enabled = false;

       
        imageComponent.sprite = null;

  
        SceneManager.LoadScene(previousSceneName);
    }
}
