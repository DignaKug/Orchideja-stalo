using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class ButtonHandler : MonoBehaviour
{
    // Assign the buttons in the inspector
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
            Button capturedButton = button; // Capture the button variable
            capturedButton.onClick.AddListener(() => OnPotionasButtonClick(capturedButton));
        }

        foreach (var button in KietaButtons)
        {
            Button capturedButton = button; // Capture the button variable
            capturedButton.onClick.AddListener(() => OnKietaButtonClick(capturedButton));
        }

        foreach (var button in RandomButtons)
        {
            Button capturedButton = button; // Capture the button variable
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
            LoadScene(mostCommonNumber);
        }
    }

    void LoadScene(int sceneNumber)
    {
        string sceneName = "Scene" + sceneNumber;
        SceneManager.LoadScene(sceneName);
    }
}
