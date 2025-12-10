using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject selectDifficulty;
    
    public void OpenOptionsPanel()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        selectDifficulty.SetActive(false);
    }

    public void OpenMainMenuPanel()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        selectDifficulty.SetActive(false);
    }

    public void OpenSelectDifficulty()
    {
        selectDifficulty.SetActive(true);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
