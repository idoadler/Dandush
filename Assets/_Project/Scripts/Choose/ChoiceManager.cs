using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceManager : MonoBehaviour
{
    public Choice ChoicePrefab;
    public Transform Layout;
    public int choiceNumber = 3;
    public ScriptableChoiceList choicesData;

    private List<Choice> choices = new List<Choice>();
    private List<ScriptableChoiceData> randomChoices;
    private int correctAnswer;
    private AudioClip targetClip;

    // Start is called before the first frame update
    void Start()
    {
        randomChoices = choicesData.GetRandomChoices(choiceNumber);
        foreach (ScriptableChoiceData c in randomChoices)
        {
            Choice choice = Instantiate(ChoicePrefab, Layout);
            choice.button.image.sprite = c.sprite;
            choice.clip = c.clip;
            choice.button.onClick.AddListener(WrongAnswer);
            choices.Add(choice);
        }
        correctAnswer = Random.Range(0, choiceNumber);
        choices[correctAnswer].button.onClick.RemoveListener(WrongAnswer);
        choices[correctAnswer].button.onClick.AddListener(RightAnswer);
        targetClip = choices[correctAnswer].clip;
        SoundManager.Instance.Play(targetClip);
    }

    private bool correct = false;
    private void Update()
    {
        if (correct && !SoundManager.Instance.audioSource.isPlaying)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void WrongAnswer()
    {
        SoundManager.Instance.PlayLose();
    }

    public void RightAnswer()
    {
        SoundManager.Instance.PlayWin();
        correct = true;
    }
}
