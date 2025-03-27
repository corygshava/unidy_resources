using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTag : MonoBehaviour
{
    public Transform target;
    public Transform normal;
    public HelpersHolder help;
    public Vector3 offset;
    public Camera cam;
    public GameObject player;
    public GameObject textUI;
    public float distance;
    public string text;

    public bool special;

    [Header("fading data")]
    public float opacity;
    public float maxDistance = 5;
    public float frameCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateData();
    }

    // Update is called once per frame
    void Update()
    {
        if(frameCount <= 25){
            frameCount += 1;
            UpdateData();
        }

        if(target == null){target = normal;}

        cam = FindObjectOfType<CamHolder>().cam.GetComponent<Camera>();
        player = FindObjectOfType<PlayerController>().gameObject;

        distance = Vector3.Distance(target.position,player.transform.position);
        if(target != null){
            Vector3 pos = cam.WorldToScreenPoint(target.position + offset);
            transform.position = pos;
            opacity = Mathf.Lerp(1,0,(float) distance / maxDistance);
        }

        if(gameObject.GetComponent<CanvasGroup>()){
            gameObject.GetComponent<CanvasGroup>().alpha = opacity;
        }

        cm.seTxt(textUI,text);
    }

    void UpdateData(){
        if(target == null){
            help = FindObjectOfType<HelpersHolder>();
            target = help.gameObject.transform.Find("DefaultFocus");
            normal = target;
        }
    }
}
