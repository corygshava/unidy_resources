using UnityEngine;

public class Blast : MonoBehaviour
{
    // Requires the SoundManager component to be present in the scene

    public GameObject explosionPrefab;
    public float blastRadius;
    public float explosionForce;
    public float maxDamage;
    public bool spawnOnAwake = false;
    public bool explodeNow = false;
    public string blastSound;

    private void Start()
    {
        if (spawnOnAwake)
            Explode();
    }

    private void Update()
    {
        if (explodeNow)
        {
            Explode();
            explodeNow = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, blastRadius);
    }

    public void Explode()
    {
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider collider in colliders)
        {
            Vector3 closestPoint = collider.ClosestPoint(transform.position);
            float distance = Vector3.Distance(transform.position, closestPoint);

            float damagePercentage;
            if (distance <= blastRadius * 0.5f)
                damagePercentage = 1f;
            else
                damagePercentage = Mathf.Lerp(0.9f, 0.1f, (distance - blastRadius * 0.5f) / (blastRadius * 0.5f));

            DealDamage(collider.gameObject, maxDamage * damagePercentage);

            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(explosionForce, transform.position, blastRadius);
        }

        SoundManager soundManager = FindObjectOfType<SoundManager>();
        if (soundManager != null && !string.IsNullOrEmpty(blastSound))
        {
            soundManager.PlaySound(blastSound, transform);
        }
    }

    private void DealDamage(GameObject target, float damage)
    {
        // Apply damage to the target based on your specific implementation
        Debug.Log("Dealing " + damage + " damage to " + target.name);
    }
}
