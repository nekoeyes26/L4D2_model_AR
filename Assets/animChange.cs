using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animChange : MonoBehaviour
{
    public Animator anim;

    // Define lists of AudioSource for each category
    public List<AudioSource> idleAudioSources = new List<AudioSource>();
    public List<AudioSource> meleeAudioSources = new List<AudioSource>();
    public List<AudioSource> walkAudioSources = new List<AudioSource>();

    // Reference to the currently running coroutine
    private Coroutine audioCoroutine;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began && anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                anim.Play("melee");
                StopAudioCoroutine();
                audioCoroutine = StartCoroutine(PlayAudioSequentially(meleeAudioSources));
            }
            else if (Input.GetTouch(i).phase == TouchPhase.Began && anim.GetCurrentAnimatorStateInfo(0).IsName("melee"))
            {
                anim.Play("walk");
                StopAudioCoroutine();
                audioCoroutine = StartCoroutine(PlayAudioSequentially(walkAudioSources));
            }
            else if (Input.GetTouch(i).phase == TouchPhase.Began && anim.GetCurrentAnimatorStateInfo(0).IsName("walk"))
            {
                anim.Play("idle");
                // Stop the current coroutine if it's running
                StopAudioCoroutine();

                // Start a new coroutine
                audioCoroutine = StartCoroutine(PlayAudioSequentially(idleAudioSources));
            }
        }
    }

    // Play audio sources sequentially and loop
    IEnumerator PlayAudioSequentially(List<AudioSource> audioSources)
    {
        for (int i = 0; i < audioSources.Count; i++)
        {
            // Play the current audio source
            audioSources[i].Play();

            // Wait until the audio has finished playing
            yield return new WaitWhile(() => audioSources[i].isPlaying);
        }
    }

    // Stop the currently running coroutine
    void StopAudioCoroutine()
    {
        if (audioCoroutine != null)
        {
            StopCoroutine(audioCoroutine);
        }
    }
}
