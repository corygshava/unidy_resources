using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rocket : MonoBehaviour
{
    // Requires SoundManager component to work correctly
    // Make sure to attach the SoundManager script to a GameObject in the scene
    // Also, make sure to add the Blast script to the explosion prefab
    // Adjust the variables below according to your requirements
    public float speed;
    public float explosionDamage;
    public GameObject explosionPrefab;
    public float blastRadius;
    public float maxDistance;
    public string explodeSound = "ExplosionSound";

    private bool hasExploded = false;
    [SerializeField] private bool explodeInput1 = false;
    [SerializeField] private bool explodeInput2 = false;
    [SerializeField] private bool explodeInput3 = false;

    private void FixedUpdate()
    {
        if (!hasExploded)
        {
            explodeInput1 = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftCommand) || Input.GetKey(KeyCode.RightCommand);
            explodeInput2 = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
            explodeInput3 = Input.GetKeyDown(KeyCode.X);

            if ((explodeInput1 && explodeInput2 && explodeInput3) || Vector3.Distance(transform.position, transform.parent.position) > maxDistance)
            {
                Explode();
            }

            if (!(explodeInput1 && explodeInput2 && explodeInput3))
            {
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.useGravity = false;
                rb.AddForce(transform.forward * speed, ForceMode.Acceleration);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasExploded)
        {
            Explode();
        }
    }

    private void Explode()
    {
        hasExploded = true;

        SoundManager soundManager = FindObjectOfType<SoundManager>();
        if (soundManager != null && !string.IsNullOrEmpty(explodeSound))
        {
            soundManager.PlaySound(explodeSound);
        }

        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Blast blastComponent = explosion.GetComponent<Blast>();
        if (blastComponent != null)
        {
            blastComponent.blastRadius = blastRadius;
            blastComponent.maxDamage = explosionDamage;
        }

        Destroy(gameObject,0.3);
    }
}
