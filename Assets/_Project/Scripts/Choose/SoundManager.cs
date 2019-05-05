using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip[] correct;
    public AudioClip[] wrong;

    public AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        if (Instance != this)
            Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWin()
    {
        Play(correct[Random.Range(0, correct.Length)], false);
    }

    public void PlayLose()
    {
        PlayOneShot(wrong[Random.Range(0, correct.Length)]);
    }

    public void Play(AudioClip clip, bool loop = true)
    {
        audioSource.clip = clip;
        audioSource.loop = loop;
        audioSource.Play();
    }

    public void PlayOneShot(AudioClip clip)
    {
        audioSource?.PlayOneShot(clip);
    }
}
