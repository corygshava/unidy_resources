
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    public commonData cmdt;
    public ScreenTag mytag;
    public GameObject torun;
    public PowerupHandler ph;
    public PlayerController player;
    public NotifyHandler notice;

    [Header("Switches")]
    public bool hasrun;
    public bool available;
    public bool doit;
    public bool inrange = false;
    public bool showNotice = true;

    [Header("custom data")]
    public bool once;
    public bool notifyPlayer = true;
    public float waittime = 3.0f;
    public float distance;
    public string interTxt = "interact";
    public string errTxt = "powerup not available";
    public string workTxt = "powerup triggered";

    ScreenTag[] tempo;

    // Start is called before the first frame update
    void Start()
    {
        if(FindObjectOfType<commonData>()){cmdt = FindObjectOfType<commonData>();}
        else {this.enabled = false;}

        cmdt.setStuff();

        refreshtag();
    }

    // Update is called once per frame
    void Update()
    {
        player = cmdt.player;
        notice = cmdt.notice;
        distance = Vector3.Distance(transform.position,player.gameObject.transform.position);
        inrange = Vector3.Distance(transform.position,player.gameObject.transform.position) < 3.5;

        if(inrange){
            if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)){
                if(available){
                    doit = true;
                }
                notify(available);
            }

            mytag.target = transform;
        }

        if(doit){
            if(GetComponent<PortalHandler>()){GetComponent<PortalHandler>().inter = true;}
            doit = false;
            interact();
        }

        refreshtag();
    }

    void OnTriggerEnter(Collider other) {
        if(this.enabled){
            if(other.CompareTag("Player") && available){
                mytag.target = transform;

                if(showNotice){
                    mytag.text = interTxt;
                } else {
                    mytag.text = "interact";
                }

                //Debug.Log("the text is : "+mytag.text);
            }
        }
    }

    void OnTriggerStay(Collider other) {
        OnTriggerEnter(other);
    }

    void interact(){
        cm.deact(torun,2);
        mytag.target = mytag.normal;
        hasrun = true;
        available = false;

        if(ph != null){ph.RunPower();}

        if(!once){
            StartCoroutine(ResetPower());
        }
    }

    void refreshtag(){
        tempo = cmdt.UItags;

        for(int x = 0;x<tempo.Length;x++){
            if(tempo[x].type == "interact"){
                mytag = tempo[x];
            }
        }
    }

    void notify(bool good){
        if(notifyPlayer){
            if(good){
                notice.NotifyMe(workTxt);
            } else{
                notice.NotifyMe(errTxt);
            }
        }
    }

    IEnumerator ResetPower(){
        if(ph.powerId == 0){
            ph.gameObject.GetComponent<ChestManager>().Open();
        }

        yield return new WaitForSeconds(waittime - 1.2f);
        if(ph.powerId == 0)
            ph.gameObject.GetComponent<ChestManager>().Close();

        yield return new WaitForSeconds(1.2f);
        Debug.Log("available is "+available);
        available = true;
        hasrun = false;
        cm.deact(torun,1);
    }
}
