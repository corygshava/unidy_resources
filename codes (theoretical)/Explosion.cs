using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject BlastFx;
    public float sizeMultiplier = 1.0f;

    [Header("stuff for the explosion mechanic")]
    public float radius = 5.0f;
    public float damage = 100f;
    public float distFactor = 0f;
    public float ExplosionDelay = 0.0f;

    [Header("stuff for the explosion physics")]
    public float explosionForce = 20f;
    public float upforce = 12.0f;

    [Header("switches")]
    public bool blowUp;
    public bool blowOnAwake;
    public bool hurtPlayer = true;
    public bool hurtEnemies = true;

    // Start is called before the first frame update
    void Start(){
        // to modify the size of the explosion for variety
        transform.localScale = transform.localScale * sizeMultiplier;
        if(blowOnAwake){Invoke("Explode",ExplosionDelay);}
    }

    void Update() {
        if(blowUp){
            blowUp = false;
            Invoke("Explode",ExplosionDelay);
        }
    }

    void Explode(){
        //show effect
        if(BlastFx != null){SpawnMe.spawnAndHold(BlastFx,gameObject);Debug.Log("Explosion effect happened");}

        // get nearby objects
        Collider[] cols = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider col in cols)
        {
            float newdamage = damage;
            distFactor = (transform.position.magnitude - col.transform.position.magnitude);
            if(distFactor > (radius / 2)){
                // float multi = (distFactor / radius) - .5f;
                // newdamage = newdamage * multi;
                float multi = 1 / (distFactor * distFactor);
                Debug.Log("enemy was "+distFactor+"m away so got a damage of "+newdamage+" instead of "+damage+" (multiplier was "+multi+")");
            }

            if(col.gameObject.GetComponent<Rigidbody>()){
                Debug.Log("Explosion happened");
                Rigidbody rb = col.GetComponent<Rigidbody>();
                rb.AddExplosionForce(explosionForce,transform.position,radius,upforce,ForceMode.Impulse);
            }

            if(col.gameObject.GetComponent<Enemy>()){
                if(hurtEnemies){col.gameObject.GetComponent<Enemy>().Damage(newdamage);}
            } else if(col.gameObject.GetComponent<Playerstats>()){
                if(hurtPlayer){col.gameObject.GetComponent<Playerstats>().Damage(newdamage);}
            }
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,radius);
    }
}
