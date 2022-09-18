using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip[] correct;
    public AudioClip[] wrong;

    public AudioSource audioSource;
    private AudioClip lastClip;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        if (Instance != this)
            Destroy(this);

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWin()
    {
        Play(correct[Random.Range(0, correct.Length)], false);
    }

    public void PlayLose()
    {
        audioSource.Pause();
        audioSource.clip = null;
        var clip = wrong[Random.Range(0, correct.Length)];
        PlayOneShot(clip);
        Invoke(nameof(KeepPlay), clip.length + 0.2f);
    }

    private void KeepPlay()
    {
        Play(lastClip);
    }

    public void Play(AudioClip clip, bool loop = true)
    {
        lastClip = clip;
        audioSource.clip = clip;
        audioSource.loop = loop;
        audioSource.Play();
    }

    private void PlayOneShot(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
