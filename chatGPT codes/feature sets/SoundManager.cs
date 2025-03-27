using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] audioClips;

    // Variables for testing
    public bool testPlay = false;
    public string testClipName = "";
    public Transform testClipTransform;

    private void Update()
    {
        if (testPlay && !string.IsNullOrEmpty(testClipName))
        {
            testPlay = false; // Reset the testPlay variable

            if (testClipTransform != null)
            {
                PlaySound(testClipName, testClipTransform);
            }
            else
            {
                PlaySound(testClipName);
            }
        }
    }

    public void PlaySound(string clipName)
    {
        AudioClip clip = FindAudioClip(clipName);

        if (clip != null)
        {
            GameObject soundObject = new GameObject("Sound");
            AudioSource audioSource = soundObject.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.Play();

            Destroy(soundObject, clip.length);
        }
        else
        {
            Debug.Log("No sound found with the name: " + clipName);
        }
    }

    public void PlaySound(string clipName, Transform spawnTransform)
    {
        AudioClip clip = FindAudioClip(clipName);

        if (clip != null)
        {
            GameObject soundObject = new GameObject("Sound");
            soundObject.transform.position = spawnTransform.position;
            AudioSource audioSource = soundObject.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.Play();

            Destroy(soundObject, clip.length);
        }
        else
        {
            Debug.Log("No sound found with the name: " + clipName);
        }
    }

    private AudioClip FindAudioClip(string clipName)
    {
        foreach (AudioClip clip in audioClips)
        {
            if (clip.name == clipName)
            {
                return clip;
            }
        }

        return null;
    }
}
