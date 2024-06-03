using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class ButtonHandler : MonoBehaviour
{
    public Button[] PotionasButtons;
    public Button[] KietaButtons;
    public Button[] RandomButtons;

    private int selectedPotionas = -1;
    private int selectedKieta = -1;
    private int selectedRandom = -1;

    void Start()
    {
        foreach (var button in PotionasButtons)
        {
            Button capturedButton = button;
            capturedButton.onClick.AddListener(() => OnPotionasButtonClick(capturedButton));
        }

        foreach (var button in KietaButtons)
        {
            Button capturedButton = button;
            capturedButton.onClick.AddListener(() => OnKietaButtonClick(capturedButton));
        }

        foreach (var button in RandomButtons)
        {
            Button capturedButton = button;
            capturedButton.onClick.AddListener(() => OnRandomButtonClick(capturedButton));
        }
    }

    void OnPotionasButtonClick(Button button)
    {
        selectedPotionas = ExtractNumberFromButton(button);
        CheckSelectionsAndLoadScene();
    }

    void OnKietaButtonClick(Button button)
    {
        selectedKieta = ExtractNumberFromButton(button);
        CheckSelectionsAndLoadScene();
    }

    void OnRandomButtonClick(Button button)
    {
        selectedRandom = ExtractNumberFromButton(button);
        CheckSelectionsAndLoadScene();
    }

    int ExtractNumberFromButton(Button button)
    {
        string buttonName = button.name;
        return int.Parse(new string(buttonName.Where(char.IsDigit).ToArray()));
    }

    void CheckSelectionsAndLoadScene()
    {
        if (selectedPotionas != -1 && selectedKieta != -1 && selectedRandom != -1)
        {
            int[] numbers = { selectedPotionas, selectedKieta, selectedRandom };
            int mostCommonNumber = numbers.GroupBy(n => n)
                                          .OrderByDescending(g => g.Count())
                                          .ThenBy(g => g.Key)
                                          .First().Key;

            if (selectedPotionas == 3 && selectedKieta == 3 && selectedRandom == 3)
            {
                LoadScene(3); // Load Scene 3 if all selections are 3
            }
            else if (mostCommonNumber == 4)
            {
                LoadScene(4); // Load Scene 4 if the most common number is 4
            }
            else if (mostCommonNumber == 2 || mostCommonNumber == 3)
            {
                LoadScene(2); // Load Scene 2 if the most common number is 2 or 3
            }
            else
            {
                LoadScene(1); // Load Scene 1 otherwise
            }
        }
    }

    void LoadScene(int sceneNumber)
    {
        if (sceneNumber == 4)
        {
            // Shut down the game if Scene 4 is loaded
            Application.Quit();
        }
        else
        {
            // Load the scene
            string sceneName = "Scene" + sceneNumber;
            SceneManager.LoadScene(sceneName);
        }
    }
}
