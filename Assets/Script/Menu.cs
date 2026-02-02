using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public int level;
    [SerializeField] TextMeshProUGUI _gameOverText;
    [SerializeField] Button[] _action;
    [SerializeField] int _mainMenuSceneIndex;
    [SerializeField] string _winText = "Ви перемогли";
    [SerializeField] string _loseText = "Ви програли";

    public void QuitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(_mainMenuSceneIndex);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(level);
    }

    public void ContinueGame()
    {
        if (_gameOverText.text == _winText)
            SceneManager.LoadScene(level);
        else if (_gameOverText.text == _loseText)
        {
            for (int i = 0; i < _action.Length; i++)
                _action[i].interactable = true;
        }
    }
}
