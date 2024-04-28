using System.Collections.Generic;
using System;

class BuildAllBridge
{
    private Action<int, bool> _setButtonActiveAction;
    public Dictionary<string, string> Birdges = new Dictionary<string, string>();
    public Dictionary<string, string> WinBirdges = new Dictionary<string, string>();
    public List<string> list_action;
    public string _firstBirdge;
    public string _secondBirdge;

    public void SetButtonActiveHandler(Action<int, bool> setButtonActiveAction)
    {
        _setButtonActiveAction = setButtonActiveAction;
    }

    public void BuildBridge(string[] input)
    {
        string first_result = new string('-', (_firstBirdge.Length/2) + 1);
        string second_result = new string('_', (_secondBirdge.Length/2) + 1);

        do
        {
            Birdges.Clear();
            int i = 0;
            foreach (string a in list_action)
            {
                string signalForm = GetOutputSignalForm(a, _firstBirdge, _secondBirdge);
                if (signalForm == first_result || signalForm == second_result)
                    WinBirdges[a] = signalForm;
                else
                {
                    foreach (var signal in Birdges)
                        if (Birdges[signal.Key] == signalForm)
                            _setButtonActiveAction?.Invoke(i, false);
                    Birdges[a] = signalForm;
                }
                i++;
            }
            _firstBirdge = input[UnityEngine.Random.Range(0, input.Length)];
            _secondBirdge = input[UnityEngine.Random.Range(0, input.Length)];
        } while (WinBirdges.Count == 0);
    }
    public string GetOutputSignalForm(string gateType, string signal1, string signal2)
    {
        string outputSignal = "";
        for (int i = 0; i < signal1.Length; i++)
        {
            bool input1 = signal1[i] == '-';
            bool input2 = signal2[i] == '-';
            bool result = false;


            switch (gateType)
            {
                case "AND":
                    result = input1 && input2;
                    break;
                case "OR":
                    result = input1 || input2;
                    break;
                case "XOR":
                    result = input1 ^ input2;
                    break;
                case "NAND":
                    result = !(input1 && input2);
                    break;
                case "NOR":
                    result = !(input1 || input2);
                    break;
                case "NXOR":
                    result = !(input1 ^ input2);
                    break;
            }
            outputSignal += result ? '-' : '_';
        }
        return outputSignal;
    }
}