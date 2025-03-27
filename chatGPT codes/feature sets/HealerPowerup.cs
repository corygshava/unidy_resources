using UnityEngine;

public class HealerPowerup : MonoBehaviour
{
    public float healingAmount = 10f; // Base amount of health to be gained when the powerup is used
    public float healingMultiplier = 1f; // Multiplier to adjust the healing amount
    public float range = 10f; // Maximum range within which the powerup can heal the player
    public float lifespan = 10f; // Lifespan of the powerup before it despawns

    private float healTimer = 0.2f; // Time interval between each heal tick
    private float timer = 0f; // Timer to track heal intervals

    private void Start()
    {
        // Start the lifespan countdown
        Destroy(gameObject, lifespan);
    }

    private void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if enough time has passed for the next heal tick
        if (timer >= healTimer)
        {
            HealPlayer();

            // Reset the timer
            timer -= healTimer;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Start healing the player
            HealPlayer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Stop healing the player
            StopHealingPlayer();
        }
    }

    private void HealPlayer()
    {
        // Get all colliders within the range
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);

        foreach (Collider collider in colliders)
        {
            // Check if the collider belongs to the player
            if (collider.CompareTag("Player"))
            {
                // Get the HealthManager component from the player
                HealthManager healthManager = collider.GetComponent<HealthManager>();

                // Calculate the amount of health to add
                float healthToAdd = healingAmount * healingMultiplier;

                // Heal the player using the heal method of HealthManager
                healthManager.Heal(healthToAdd);
            }
        }
    }

    private void StopHealingPlayer()
    {
        // No longer healing the player, do any necessary cleanup or effects here
    }
}
