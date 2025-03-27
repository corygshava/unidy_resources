using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class healthManager : MonoBehaviour
{
    public float armor;
    public float maxhealth;
    public float myhealth;
    public float healthratio;
    public float armorratio;

    public bool linked = false;
    public healthManager link;
    public bool lastchain = true;
    public bool master = false;

    // events for external communication
    public delegate void healthAction(float amt);
    public event healthAction OnHurt;
    public event healthAction OnHeal;
    public event Action OnDeath;

    // Start is called before the first frame update
    void Start(){
        setHealth();
    }

    // Update is called once per frame
    void Update(){
        healthratio = (float) myhealth / maxhealth;
        armorratio = (float) armor / maxhealth;

        normalize();

        if (linked && link != null) {
            if (lastchain)
            {
                if (link.link == null)
                {
                    linkme();
                }
            }else { 
                linkme();
            }
        }
    }

    public void hurt(float damage){
        if(link == null){
            if(armor > 0){armor -= damage;}
            else{myhealth -= damage;}
            if(damage > (maxhealth * 2)){
                myhealth -= damage;
            }
        } else {
            if(master){
                if(armor > 0){armor -= damage;}
                else{myhealth -= damage;}
            } else {
                link.hurt(damage / 2);
                // Debug.Log("I " + gameObject.name + " hurt " + link.name);
            }
        }

        OnHurt?.Invoke(damage);

        if(myhealth <= 0){OnDeath?.Invoke();}
    }

    public void heal(float amount){
        if(myhealth >= maxhealth){
            armor += amount;
        } else {
            myhealth += amount;
        }

        OnHeal?.Invoke(amount);
    }

    public void heal2(float amount){
        float toadd = (float) maxhealth * (amount / 100);
        heal(toadd);

        OnHeal?.Invoke(toadd);
    }

    public void addarmor(float amount){
        armor += amount;
    }

    public void addarmor2(float amount){
        armor += maxhealth * (amount / 100);
    }

    public void setHealth(){
        myhealth = maxhealth;
    }

    public void UpdateHealth(float factor){
        float fraction = (myhealth / maxhealth);
        maxhealth *= factor;
        myhealth = fraction * maxhealth;
        // Debug.Log("healthMan : f - "+factor);
    }

    void normalize(){
        if(armor > maxhealth){armor = maxhealth;}
        if(myhealth > maxhealth){myhealth = maxhealth;}

        if(armor < 0){armor = 0;}
        if(myhealth < 0){myhealth = 0;}

        if(armor > 0){myhealth = maxhealth;}
    }

    void linkme() {
        if (master){
            link.armor = armor;
            link.maxhealth = maxhealth;
            link.myhealth = myhealth;
        }
        else{
            armor = link.armor;
            maxhealth = link.maxhealth;
            myhealth = link.myhealth;
        }
    }
}
