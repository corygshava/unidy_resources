// AI gen code
using UnityEngine;

// Requires SoundManager component to work correctly
// Make sure to attach the SoundManager script to a GameObject in the scene

[RequireComponent(typeof(Rigidbody))]
public class CurveballRocket : MonoBehaviour
{
    public float myDamage = 50f;
    public GameObject explosionPrefab;
    public float maxDistance = 10f;
    public string flySound = "rocket_fly";

    private Vector3 targetLocation;
    private float initialSpeed;
    private Rigidbody rb;
    private bool hasExploded = false;

    // Requires Blast script attached to the explosion prefab for damage to be applied correctly

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Fire the curveball rocket towards the target location with a specified speed
    public void Fire(Vector3 target, float speed)
    {
        targetLocation = target;
        initialSpeed = speed;

        // Calculate the initial velocity to achieve the desired arc
        Vector3 direction = targetLocation - transform.position;
        float distance = direction.magnitude;
        float yOffset = 0.5f * distance;
        Vector3 velocity = direction.normalized * initialSpeed;
        velocity.y += Mathf.Sqrt(2f * Physics.gravity.magnitude * yOffset);

        // Apply the initial velocity to the projectile
        rb.velocity = velocity;

        // Play sound if SoundManager exists in the scene
        SoundManager soundManager = FindObjectOfType<SoundManager>();
        if (soundManager != null && !string.IsNullOrEmpty(flySound))
        {
            soundManager.PlaySound(flySound);
        }
    }

    private void Update()
    {
        if (!hasExploded && Vector3.Distance(transform.position, targetLocation) <= 0.3f)
        {
            Explode();
        }

        /*if (Vector3.Distance(transform.position, transform.parent.position) > maxDistance)
        {
            Explode();
        }*/
    }

    private void Explode()
    {
        if (hasExploded){return;}

        hasExploded = true;

        // Spawn explosion prefab
        if (explosionPrefab != null)
        {
            GameObject spawned = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            spawned.GetComponent<Blast>().maxDamage = myDamage;
        }

        // Despawn the rocket
        Destroy(gameObject);
    }
}
