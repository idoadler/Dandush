using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChoiceData", menuName = "Game/ChoiceData", order = 2)]
public class ScriptableChoiceData : ScriptableObject
{
    public Sprite sprite;
    public AudioClip clip;
}

[CreateAssetMenu(fileName = "ChoiceList", menuName = "Game/ChoiceList", order = 1)]
public class ScriptableChoiceList : ScriptableObject
{
    public string groupName = "";
    public List<ScriptableChoiceData> list;

    public List<ScriptableChoiceData> GetRandomChoices(int num)
    {
        if (num > list.Count)
            return null;

        List<ScriptableChoiceData> result = new List<ScriptableChoiceData>(num);

        for (int i = 0; i < num; i++)
        {
            ScriptableChoiceData choice = list[Random.Range(0, list.Count)];
            while (result.Contains(choice))
            {
                choice = list[Random.Range(0, list.Count)];
            }
            result.Add(choice);
        }

        return result;
    }
}