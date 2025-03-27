using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> audioClips = new List<AudioClip>();

    // Variables for testing
    public bool testPlay = false;
    public string testClipName = "";
    public Transform testClipTransform;
    public Transform holder;

    private void Update(){
        if (testPlay && !string.IsNullOrEmpty(testClipName))
        {
            testPlay = false; // Reset the testPlay variable

            if (testClipTransform != null){
                PlaySound(testClipName, testClipTransform);
            }
            else{
                PlaySound(testClipName);
            }
        }
    }

    public void PlaySound(string clipName){
        playHandler(clipName,transform);
    }

    public void PlaySound(string clipName, Transform spawnTransform){
        playHandler(clipName,spawnTransform);
    }

    public void PlaySound(AudioClip theclip, Transform spawnTransform) {
        if(!(hasAudioClip(theclip.name))){AddAudioClip(theclip);}

        PlaySound(theclip.name,spawnTransform);
    }

    public void PlaySound(AudioClip theclip) {
        if(!(hasAudioClip(theclip.name))){AddAudioClip(theclip);}

        PlaySound(theclip.name);
    }

    void playHandler(string clipName, Transform spawnTransform){
        AudioClip clip = FindAudioClip(clipName);

        if (clip != null){
            GameObject soundObject = new GameObject("Sound");
            if(holder != null){soundObject.transform.parent = holder;}
            soundObject.transform.position = spawnTransform.position;
            AudioSource audioSource = soundObject.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.Play();

            Destroy(soundObject, clip.length);
        }
        else{
            Debug.Log($"[{gameObject.name}] SoundMan : No sound found with the name: \"{clipName}\"");
        }
    }

    private AudioClip FindAudioClip(string clipName){
        foreach (AudioClip clip in audioClips)
        {
            if (clip.name == clipName)
            {
                return clip;
            }
        }

        return null;
    }

    public bool hasAudioClip(string clipName){
        AudioClip theaud = FindAudioClip(clipName);
        return theaud != null;
    }

    public void AddAudioClip(AudioClip sound){
        audioClips.Add(sound);
    }
}
