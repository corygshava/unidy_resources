using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public enum lockMode{
        locked,
        none,
        confined
    }

    public float curTimeScale = 0;

    [Header("switches")]
    public bool enableAll = false;
    public bool disableAll = false;
    public bool detectTimeScale = true;
    public bool hideCursor = true;
    public lockMode lockCursor;

    [Header("runtime data")]
    public CursorLockMode cursor_lock;
    public bool cursorvisible;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(detectTimeScale){
            if(Time.timeScale <= 0.01f){
                hideCursor = false;
            }
        }

        if(disableAll){
            enableAll = false;
            hideCursor = false;
            lockCursor = lockMode.none;
            disableAll = false;
        }

        if(enableAll){
            hideManager(true);
            lockManager(true);
        } else {
            hideManager(hideCursor);
            lockManager(false);
        }

        getdata();

        // for disabling in case of debug
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)){
            if(Input.GetKeyDown(KeyCode.L)){
                if(!cursorvisible){
                    disableAll = true;
                } else {
                    enableAll = true;
                }
            }
        }
    }

    public void hideManager(bool on){
        Cursor.visible = !on;
    }

    public void lockManager(bool on){
        if(on){
            Cursor.lockState = CursorLockMode.Locked;
        } else {
            if(lockCursor == lockMode.locked){
                Cursor.lockState = CursorLockMode.Locked;
            } else if(lockCursor == lockMode.none){
                Cursor.lockState = CursorLockMode.None;
            } else {
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
    }

    void getdata(){
        cursor_lock = Cursor.lockState;
        cursorvisible = Cursor.visible;
    }
}
