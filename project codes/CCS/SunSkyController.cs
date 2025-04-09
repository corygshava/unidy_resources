using UnityEngine;

public class SunSkyController : MonoBehaviour
{
    public Color sunColor;
    public Color skyColor;
    public float sunIntensity = 1.0f;
    public bool changeBackground = true;

    public void SetSunAndSkyColors()
    {
        // Set Sun Color
        Light sunLight = FindObjectOfType<Light>();
        if (sunLight != null && sunLight.type == LightType.Directional)
        {
            sunLight.color = sunColor;
            sunLight.intensity = sunIntensity;
        }
        else
        {
            // Spawn a directional light prefab if not found
            GameObject sunPrefab = Resources.Load<GameObject>("DirectionalLightPrefab");
            if (sunPrefab != null)
            {
                Instantiate(sunPrefab, Vector3.zero, Quaternion.identity);
                SetSunAndSkyColors(); // Try setting colors again after spawning light
            }
            else
            {
                Debug.LogError("Directional light prefab not found!");
            }
        }

        // Set Sky Color
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            mainCamera.backgroundColor = skyColor;
            if (changeBackground)
            {
                mainCamera.clearFlags = CameraClearFlags.SolidColor;
            }
        }
        else
        {
            Debug.LogError("Main camera not found!");
        }
    }
}
