
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// from Cubie

public class UInavManager : MonoBehaviour
{
    [Header("common data")]
    public int curslot;
    public AudioSource sound;

    [Header("For Using Images")]
    public Image[] items1;
    public Color[] Colors;

    [Header("For canvas group")]
    public CanvasGroup[] items2;
    public float[] Values;

    [Header("switches")]
    public bool vertical;
    public bool useImage;
    public bool runit;
    public bool PlaySound;
    public bool selected;
    public bool autoget;
    public bool DBlclickSelect;
    bool alreadyOn;

    // Start is called before the first frame update
    void Start()
    {
        curslot = 0;

        if(autoget){
            if(useImage){
                items1 = GetComponentsInChildren<Image>();
            } else {
                items2 = GetComponentsInChildren<CanvasGroup>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        int move = 0;

        if(vertical){
            if(Input.GetKeyDown(KeyCode.DownArrow)){
                move = -1;
                UpdateSlot(move);
            } else if(Input.GetKeyDown(KeyCode.UpArrow)){
                move = 1;
                UpdateSlot(move);
            }
        } else {
            if(Input.GetKeyDown(KeyCode.RightArrow)){
                move = -1;
                UpdateSlot(move);
            } else if(Input.GetKeyDown(KeyCode.LeftArrow)){
                move = 1;
                UpdateSlot(move);
            }
        }

        if(runit){
            runit = false;
            UpdateSlot(0);
        }

        if(selected){
            selected = false;
        } else if(Input.GetKeyDown(KeyCode.Return)){
            selected = true;
        }
    }

    void UpdateSlot(int increase){
        UnityEngine.Debug.Log("called");

        int maxLength = useImage ? items1.Length : items2.Length;

        curslot -= increase;

        if(PlaySound && sound != null){
            sound.Play();
        }

        if(curslot < 0){
            curslot = maxLength - 1;
            UnityEngine.Debug.Log("[below required] curslot updated to " + curslot);
        } else if(curslot >= maxLength){
            curslot = 0;
            UnityEngine.Debug.Log("[above required] curslot updated to " + curslot);
        }

        for(int x = 0;x < maxLength;x++){
            if(useImage){
                items1[x].color = Colors[0];
            } else {
                items2[x].alpha = Values[0];
            }
        }

        if(useImage){
            items1[curslot].color = Colors[1];
        } else {
            items2[curslot].alpha = Values[1];
            UnityEngine.Debug.Log("alpha for " + curslot + " updated to " + items2[curslot].alpha);
        }
    }

    public void selectSlot(int what){
        UnityEngine.Debug.Log("set by click");

        int maxLength = useImage ? items1.Length : items2.Length;
        if(curslot == what){alreadyOn = true;}
        curslot = what;

        if(PlaySound && sound != null){
            sound.Play();
        }

        if(curslot < 0){
            curslot = maxLength - 1;
            // UnityEngine.Debug.Log("[below required] curslot updated to " + curslot);
        } else if(curslot >= maxLength){
            curslot = 0;
            // UnityEngine.Debug.Log("[above required] curslot updated to " + curslot);
        }

        for(int x = 0;x < maxLength;x++){
            if(useImage){
                items1[x].color = Colors[0];
            } else {
                items2[x].alpha = Values[0];
            }
        }

        if(useImage){
            items1[curslot].color = Colors[1];
        } else {
            items2[curslot].alpha = Values[1];
            // UnityEngine.Debug.Log("alpha for " + curslot + " updated to " + items2[curslot].alpha);
        }

        if(DBlclickSelect & alreadyOn){
            selected = true;
        }

        alreadyOn = false;
    }

    public void SelectAndGo(int sno){
        selectSlot(sno);
        selected = true;
    }
}
