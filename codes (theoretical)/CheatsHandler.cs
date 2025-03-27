using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CheatsListener))]
public class CheatsHandler : MonoBehaviour
{
    // a separate script that requires cheatsListener script to work
    public CheatsListener cl;

    // a string array representing all avaiable cheats (usually for editor and debug use )
    // must correspond with cheats in cheatsListener
    public string[] availableCheats;
    public List<string> cheatsReport = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        cl = GetComponent<CheatsListener>();
        createCheatsReport();
    }

    // Update is called once per frame
    void Update()
    {
        if(cl != null){
            if(cl.cheatEntered){
                cl.cheatEntered = false;
                cheater(cl.cheatid);
            }
        }
    }

    public void cheater(int cno){
        // this is where you set up the functions for the set up cheats

        switch (cno)
        {
            case 0:
                // normally : fullclip
                addAmmo(500);
                break;
            case 1:
                // normally : clipMe
                addAmmo(30);
                break;
            case 2:
                // normally : respawnall
                respawnAll();
                break;
            case 3:
                // normally :
                break;
            case 4:
                // normally :
                break;
            case 5:
                // normally :
                break;
            case 6:
                // normally :
                break;
            case 7:
                // normally :
                break;
            case 8:
                // normally :
                break;
            case 9:
                // normally :
                break;
            case 10:
                // normally :
                break;
            default:
                break;
        }
    }

    public void createCheatsReport(){
        if(cl.cheats != null){
            for (int x = 0; x < cl.cheats.Length; x++){
                if(x < availableCheats.Length){
                    cheatsReport.Add(cl.cheats[x] + " - " + availableCheats[x]);
                }
            }
        }
    }

    // start of cheat functions
    
    public void addAmmo(int amount){
        if(FindObjectOfType<weapon>()){FindObjectOfType<weapon>().ammo += amount;}
    }

    public void respawnAll(){
        SpawnMe[] allspawns = FindObjectsOfType<SpawnMe>();

        for (var x = 0; x < allspawns.Length; x++){
            allspawns[x].SpawnAgain = true;
        }
    }
}
