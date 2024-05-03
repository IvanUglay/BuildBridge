using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI ;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public int level;
    [SerializeField] TextMeshProUGUI _gameOverText;
    [SerializeField] Button[] _action;

    /*public void QuitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }*/
    public void ContinueGame()
    {
        if (_gameOverText.text == "Ви виграли")
            SceneManager.LoadScene(level);
        else if (_gameOverText.text == "Ви програли")
        {
            for (int i = 0; i < _action.Length; i++)
                _action[i].interactable = true;
        }
    }
}
