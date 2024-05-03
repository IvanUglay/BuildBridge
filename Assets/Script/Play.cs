using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System;

public class Play : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _firstBirdge;
    [SerializeField] TextMeshProUGUI _secondBirdge;
    [SerializeField] TextMeshProUGUI _newBirdge;
    [SerializeField] GameObject _gameOver;
    [SerializeField] UnityEngine.UI.Button[] _action;
    BuildAllBridge build = new BuildAllBridge();
    string[] input = File.ReadAllLines(@"Assets/File/InputSignals.txt");
    System.Random random = new System.Random(Guid.NewGuid().GetHashCode());
    private bool win = false;
    private bool loser = false;
    void Start()
    {
        build.list_action = new List<string>();
        char[] chars = input[random.Next(0, input.Length)].ToCharArray();
        _firstBirdge.text = string.Join(" ", chars);
        chars = input[random.Next(0, input.Length)].ToCharArray();
        _secondBirdge.text = string.Join(" ", chars);
        build._firstBirdge = _firstBirdge.text;
        build._secondBirdge = _secondBirdge.text;
        for (int i = 0; i < _action.Length; i++)
        {
            build.list_action.Add(_action[i].GetComponentInChildren<TextMeshProUGUI>().text);
        }
        build.SetButtonActiveHandler(SetButtonActive);
        build.BuildBridge(input);


    }
    public void SetButtonActive(int index, bool active)
    {
        if (index >= 0 && index < _action.Length)
        {
            _action[index].gameObject.SetActive(active);
        }
    }
    private void Update()
    {
        if (win)
        {
            _gameOver.GetComponentInChildren<Transform>().Find("SMS").GetComponentInChildren<TextMeshProUGUI>().text = "Ви виграли";
            _gameOver.GetComponentInChildren<Transform>().Find("ActionEnd").GetComponentsInChildren<UnityEngine.UI.Button>()[0].GetComponentInChildren<TextMeshProUGUI>().text = "Наступний рівень";
            _gameOver.GetComponentInChildren<Transform>().Find("ActionEnd").GetComponentsInChildren<UnityEngine.UI.Button>()[1].GetComponentInChildren<TextMeshProUGUI>().text = "Головне меню";
        }
        if (loser)
        {
            _gameOver.GetComponentInChildren<Transform>().Find("SMS").GetComponentInChildren<TextMeshProUGUI>().text = "Ви програли";
            _gameOver.GetComponentInChildren<Transform>().Find("ActionEnd").GetComponentsInChildren<UnityEngine.UI.Button>()[0].GetComponentInChildren<TextMeshProUGUI>().text = "Перезапустити рівень";
            _gameOver.GetComponentInChildren<Transform>().Find("ActionEnd").GetComponentsInChildren<UnityEngine.UI.Button>()[1].GetComponentInChildren<TextMeshProUGUI>().text = "Головне меню";
        }
    }
    public void DrawNewBirdge(int buttonIndex)
    {
        loser = false;
        foreach (var signal in build.WinBirdges)
        {
            if (_action[buttonIndex].GetComponentInChildren<TextMeshProUGUI>().text == signal.Key)
            {
                _newBirdge.text = signal.Value;
                win = true;
            }
        }
        foreach (var signal in build.Birdges)
        {
            if (_action[buttonIndex].GetComponentInChildren<TextMeshProUGUI>().text == signal.Key)
            {
                _newBirdge.text = signal.Value;
                loser = true;

            }
        }
        for (int i = 0; i < _action.Length; i++)
        {
            _action[i].interactable = false;
        }
    }

}