using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePopup : MonoBehaviour
{
    // this class is used to spawn damage popups (obviously)
    // it needs SpawnMe and mytag class to work well
    // assign a text UI object with a mytag script attached in the tospawn spot in the SpawnMe component and this class will handle everything else

    public SpawnMe spawner;

    // damage popups
    public void showdamage(int amount,Vector3 hitpos) {
        handleSpawn($"{amount}",hitpos,"-",Color.red);
    }
    public void showdamage(int amount,Transform hitpos) {
        handleSpawn($"{amount}",hitpos.position,"-",Color.red);
    }

    // healing popups
    public void showheal(int amount,Vector3 hitpos) {
        handleSpawn($"{amount}",hitpos,"-",Color.green);
    }
    public void showheal(int amount,Transform hitpos) {
        handleSpawn($"{amount}",hitpos.position,"-",Color.green);
    }

    // custom popups
    public void showcustom(int amount,Vector3 hitpos,string prefix,Color col) {
        handleSpawn($"{amount}",hitpos,prefix,col);
    }
    public void showcustom(int amount,Vector3 hitpos,Color col) {
        handleSpawn($"{amount}",hitpos,"",col);
    }
    public void showcustom(string what,Vector3 hitpos,string prefix,Color col) {
        handleSpawn($"{what}",hitpos,prefix,col);
    }
    public void showcustom(string what,Vector3 hitpos,Color col) {
        handleSpawn($"{what}",hitpos,"",col);
    }

    // worker functions
    void handleSpawn(string amount,Vector3 hitpos,string prefix,Color mycol){
        spawner.spawnIt();
        cm.seTxt(spawner.spawned,$"{prefix}{amount}");
        cm.seTxtColor(spawner.spawned,mycol);
        spawner.spawned.GetComponent<mytag>().usetrackpos = true;
        spawner.spawned.GetComponent<mytag>().trackpos = hitpos;
    }
}
