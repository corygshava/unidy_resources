using UnityEngine;

// Requires SoundManager component to work correctly
// Make sure to attach the SoundManager script to a GameObject in the scene

// Make sure to have imported the Rocket script into the project

public class RocketLauncherPowerup : MonoBehaviour
{
    public GameObject rocketPrefab;
    public Transform firePoint;
    public float maxInterval = 3f;
    public float baseDamage = 50f;
    public float damageMultiplier = 1f;
    public string gunSound = "GunSound";

    private int ammoCount = 3;
    private float timer = 0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && ammoCount > 0 && timer <= 0f)
        {
            FireRocket();
        }

        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }

        if (ammoCount <= 0)
        {
            // Despawn the RocketLauncher power-up game object
            Destroy(gameObject);
        }
    }

    private void FireRocket()
    {
        if (rocketPrefab == null || firePoint == null)
        {
            Debug.Log("Missing rocket prefab or fire point reference.");
            return;
        }

        if (ammoCount <= 0)
        {
            Debug.Log("Out of ammo.");
            return;
        }

        GameObject rocketGO = Instantiate(rocketPrefab, firePoint.position, firePoint.rotation);
        Rocket rocket = rocketGO.GetComponent<Rocket>();

        if (rocket != null)
        {
            float damage = baseDamage * damageMultiplier;
            rocket.explosionDamage = damage;

            // Play gun sound if SoundManager exists in the scene
            SoundManager soundManager = FindObjectOfType<SoundManager>();
            if (soundManager != null && !string.IsNullOrEmpty(gunSound))
            {
                soundManager.PlaySound(gunSound);
            }
        }

        ammoCount--;
        timer = maxInterval;
    }
}
