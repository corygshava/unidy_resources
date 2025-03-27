using UnityEngine;
using UnityEngine.Events;

// Requires CurveballRocket script and SoundManager component to work correctly
// Make sure to attach the SoundManager script to a GameObject in the scene

public class CurveballLauncherPowerup : MonoBehaviour
{
    public CurveballRocket rocketPrefab;
    public int totalRounds = 3;
    public float launchInterval = 3f;
    public float launchSpeed = 10f;
    public string launchSound = "RocketLaunchSound";
    public Transform[] attackBoundaries;
    public Transform[] spawnPoints;
    public float targetPositionZ = 0f;

    [Header("Events")]
    public UnityEvent OnFire();

    private int remainingRounds;
    private bool canLaunch = true;
    private SoundManager soundManager;

    // Start is called before the first frame update
    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        remainingRounds = totalRounds;
    }

    // Update is called once per frame
    private void Update()
    {
        if (canLaunch && Input.GetKeyDown(KeyCode.X) && remainingRounds > 0)
        {
            LaunchRockets();
            remainingRounds--;

            if (remainingRounds <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void LaunchRockets()
    {
        if (rocketPrefab == null)
            return;

        if (soundManager != null && !string.IsNullOrEmpty(launchSound)){
            soundManager.PlaySound(launchSound);
        }

        for (int x = 0; x < spawnPoints.Length; x++){
            spawnHandler(x);
        }

        canLaunch = false;
        Invoke(nameof(ResetLaunch), launchInterval);
    }

    private Vector3 GetRandomVector3(Transform[] boundaries)
    {
        if (boundaries.Length != 4)
        {
            Debug.LogWarning("Invalid boundaries array! It must contain exactly 4 elements.");
            return Vector3.zero;
        }

        float targetX = Random.Range(boundaries[0].position.x, boundaries[1].position.x);
        float targetY = Random.Range(boundaries[2].position.y, boundaries[3].position.y);
        float targetZ = targetPositionZ;

        return new Vector3(targetX, targetY, targetZ);
    }

    private void ResetLaunch()
    {
        canLaunch = true;
    }

    void spawnHandler(int x){
        CurveballRocket rocket = Instantiate(rocketPrefab, spawnPoints[x], Quaternion.identity);
        rocket.Fire(GetRandomVector3(attackBoundaries), launchSpeed);
    }
}
