using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceManager : MonoBehaviour
{
    public ChoiceUI ChoicePrefab;
    public Transform Layout;
    public int choiceNumber = 3;
    public ChoiceListData choicesData;
    
    private List<BasicChoice> randomChoices;
    private int correctAnswer;
    private AudioClip targetClip;

    // Start is called before the first frame update
    void Start()
    {
        randomChoices = choicesData.GetRandomChoices(choiceNumber);
        correctAnswer = Random.Range(0, choiceNumber);
        for (int i = 0; i < randomChoices.Count; i++)
        {
            ChoiceUI choice = Instantiate(ChoicePrefab, Layout);
            choice.button.image.sprite = randomChoices[i].sprite;
            if (correctAnswer == i)
            {
                choice.button.onClick.AddListener(RightAnswer);
                targetClip = randomChoices[i].clip;
            }
            else
            {
                choice.button.onClick.AddListener(WrongAnswer);
            }
        }
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
