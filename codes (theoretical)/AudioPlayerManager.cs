using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayerManager : MonoBehaviour
{
    public commonData cmdt;
    public AudioSource aud;

    [Header("playlist")]
    public bool UsePlayList;
    public bool playNext;
    public int cursong;
    public AudioClip[] songs;

    [Header("extra stuff")]
    [Range(0,1)]
    public float volume = 1.0f;
    public float pitch = 1.0f;
    [Range(0,1)]
    public float spatialBlend = 0;

    [Header("switches")]
    public bool toggleEnable = false;
    public bool shuffle = false;
    public bool working = true;

    // Update is called once per frame
    void Update(){
        if(working){
            extrastuff();
            if(UsePlayList){
                if(playNext){
                    playNext = false;
                    StartCoroutine(GoNext());
                }
            }
        } else {
            aud.Stop();
        }

        if(toggleEnable){
            toggleEnable = false;
            AudToggle(false);
        }
    }

    IEnumerator GoNext(){
        cursong = (shuffle) ? Random.Range(0,songs.Length) : cursong;
        cursong = (cursong >= songs.Length) ? 0 : cursong;
        if(cursong >= songs.Length){
            cursong = 0;
        }
        aud.clip = songs[cursong];
        aud.Play();

        yield return new WaitForSecondsRealtime(songs[cursong].length);
        cursong += 1;
    }

    void extrastuff(){
        // extra stuff to manipulate audio
        aud.volume = volume;
        aud.pitch = pitch;
        aud.spatialBlend = spatialBlend;
    }

    public void AudToggle(){
        aud.enabled = !aud.enabled;
    }

    public void playToggle(){
        PauseAud(aud.isPlaying);
    }

    public void AudEnable(bool thecon){
        aud.enabled = thecon;
    }

    public bool PauseAud(bool thecon){
        if(thecon){
            aud.Pause();
        } else {
            aud.UnPause();
        }
    }
}
