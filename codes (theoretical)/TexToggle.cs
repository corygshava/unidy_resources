using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexToggle : MonoBehaviour
{
    [Header("external mat")]
    public Material mymat;

    [Header("internal mat")]
    public Renderer rend;
    public int matno;

    [Header("texture switching data")]
    public Texture mytex;
    public Texture[] texs;

    public float timer = 0.0f;
    public float interval = 3.0f;
    public int curtex = 0;

    [Header("switches")]
    public bool useinternal;
    public bool itsme;
    public bool doOnAwake = true;

    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        if(interval <= 0){
            interval = 3.0f;
        }

        if(timer >= interval && interval != 0){
            changetex();
        }

        timer += Time.deltaTime;
    }

    public void changetex(){
        timer = 0;

        curtex+=1;
        if(texs.Length != 0){
            // curtex = Mathf.Clamp(curtex,0,texs.Length);
            if(curtex == texs.Length){
                curtex = 0;
            }
            mytex = texs[curtex];

            if(!useinternal){
                if(mymat != null){
                    mymat.SetTexture("_EmissionMap",mytex);

                    Debug.Log("texture of "+mymat.name+" changed to "+mytex.name);
                } else {
                    Debug.Log("["+gameObject.name+"]: a material is required for this to work");
                }
            } else {
                if(rend != null){
                    rend.materials[matno].SetTexture("_EmissionMap",mytex);

                    Debug.Log("["+gameObject.name+"]: renderer's texture has been set");
                } else {
                    Debug.Log("["+gameObject.name+"]: a renderer is required for this to work");
                }
            }
        }
    }

    void init(){
        if(itsme){rend = GetComponent<Renderer>();}
        if(doOnAwake){changetex();}
    }
}
