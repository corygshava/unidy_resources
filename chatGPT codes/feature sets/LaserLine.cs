using UnityEngine;

public class LaserLine : MonoBehaviour
{
    public float maxDistance = 10f; // Maximum distance for the raycast
    public bool visualize = true; // Boolean to control visualization
    public bool activateRay = false; // Boolean to activate the raycast

    private LineRenderer lineRenderer; // Reference to the LineRenderer component

    private void Start()
    {
        // Add a LineRenderer component to the current GameObject if visualize is true and it doesn't exist
        if (visualize && lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.positionCount = 0;
        }
    }

    private void Update()
    {
        if (activateRay)
        {
            DrawLaser();
        }
        else
        {
            // Clear the LineRenderer when not activating the ray or visualize is false
            if (lineRenderer != null)
                lineRenderer.positionCount = 0;
        }
    }

    private void DrawLaser()
    {
        // Create a ray from the current GameObject's position towards its forward direction
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            // Store the hit object and the distance to it
            GameObject hitObject = hit.collider.gameObject;
            float hitDistance = hit.distance;

            // Visualize the raycast hit point if visualize is true and lineRenderer is assigned
            if (visualize && lineRenderer != null)
            {
                // Set the points of the LineRenderer to the origin and hit point
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, ray.origin);
                lineRenderer.SetPosition(1, hit.point);
            }

            // Perform any additional actions with the hit object and hit distance
            // ...
        }
        else
        {
            // Visualize the maximum distance if visualize is true and lineRenderer is assigned
            if (visualize && lineRenderer != null)
            {
                // Set the points of the LineRenderer to the current GameObject's position and max distance in front of it
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, transform.position + transform.forward * maxDistance);
            }
        }
    }
}
