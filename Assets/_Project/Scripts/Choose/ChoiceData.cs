using System.Collections.Generic;
using UnityEngine;

public class ChoiceData : MonoBehaviour
{
    public string groupName = "";
    public Sprite icon;
    public List<BasicChoice> list;

    public List<BasicChoice> GetRandomChoices(int num)
    {
        if (num > list.Count)
            return null;

        List<BasicChoice> result = new List<BasicChoice>(num);

        for (int i = 0; i < num; i++)
        {
            BasicChoice choice = list[Random.Range(0, list.Count)];
            while (result.Contains(choice))
            {
                choice = list[Random.Range(0, list.Count)];
            }
            result.Add(choice);
        }

        return result;
    }
}

[System.Serializable]
public struct BasicChoice
{
    public Sprite sprite;
    public AudioClip clip;
}