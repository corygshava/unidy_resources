using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowToggle : MonoBehaviour
{
    public GameObject item;
    public GameObject mylight;
    public int matIndex = 0;
    public string matName;
    public Material mat;
    public Color[] colors;
    [SerializeField] Color curcol;
    public float waittime = 1.0f;
    [SerializeField]float curtime = 0.0f;

    [Header("switches")]
    public bool itsme = true;
    public bool on;
    public bool updateIt;
    public bool useItem;
    public bool useName = false;
    public bool runOnAwake = true;
    public bool usetimer = false;
    public bool toggleMe = true;
    public bool syncWithLight = true;


    // Start is called before the first frame update
    void Start()
    {
        if(runOnAwake){updateIt = true;}
        if(itsme){if(GetComponent<MeshRenderer>()){item = gameObject;useItem = true;}}
    }

    // Update is called once per frame
    void Update()
    {
        string logTxt = "";
        // the code for updating colors
        if(updateIt){
            curtime = 0.0f;
            updateIt = false;

            if(toggleMe){on = on ? false : true;}

            if(colors.Length >= 2){
                curcol = on ? colors[0] : colors[1];
            } else if(colors.Length == 1){
                curcol = colors[0];
            }

            changeMat();

            if(syncWithLight){mylight.GetComponent<LightColor>().col = curcol;mylight.GetComponent<LightColor>().updateIt = true;}
        }

        //in case you want the colors to switch after a certain amount of time
        if(usetimer){
            waittime = waittime > 0.01 ? waittime : 0.01f;
            if(curtime < waittime){curtime += Time.deltaTime;}
            else {updateIt = true;}
        }

        if(logTxt != ""){Debug.Log(logTxt);}
    }

    //a function for getting materials based on some preset switches
    void GetMat(bool crit){
        if(!crit){
            if(matIndex >= colors.Length){matIndex = colors.Length - 1;}
            mat = item.GetComponent<MeshRenderer>().materials[matIndex];
            // Debug.Log("material selected: " + item.GetComponent<MeshRenderer>().materials[matIndex].name);
        } else {
            foreach (Material mymat in item.GetComponent<MeshRenderer>().materials){
                if(mymat.name == matName || mymat.name == (matName + " (instance)")){
                    mat = mymat;
                    // Debug.Log("material called " + matName + " selected");
                }
            }
        }
    }

    void changeMat(){
        if(useItem){
            if(item != null){GetMat(useName);}
        }

        if(mat != null){
            mat.SetColor("_EmissionColor",curcol);
            // if(mat.GetColor("_EmissionColor") == curcol){logTxt += ("and it did");} else {logTxt += ("and it did not");}
        }
    }

    public void setColorId(bool onify){
        on = onify;
        updateIt = true;
    }
}
