using UnityEngine;

// the idea is that it cycles through items spawning a specific item in that list like in a vehicle selection screen
public class cycleitems : MonoBehaviour
{
    public GameObject[] tocycle;
    public int currentIndex = 0;
    public GameObject parent;
    private GameObject lastSpawnedObject;

    private void Update(){
        // Check for left arrow key press to cycle to the previous object
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            goPrevious();
        }

        // Check for right arrow key press to cycle to the next object
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            goNext();
        }
    }

    public void SpawnObject(){
        // Check if there's a last spawned object, destroy it if it exists
        if (lastSpawnedObject != null){
            Destroy(lastSpawnedObject);
        }

        // Spawn the current object
        lastSpawnedObject = Instantiate(tocycle[currentIndex], parent.transform.position, parent.transform.rotation, parent.transform);
    }

    public void CycleIndex(int increment){
        // Increment the current index by the specified value
        currentIndex += increment;

        // Wrap around if currentIndex goes out of bounds
        if (currentIndex < 0){
            currentIndex = tocycle.Length - 1;
        }
        else if (currentIndex >= tocycle.Length){
            currentIndex = 0;
        }
    }

    // Cycle to the next object
    public void goNext(){
        CycleIndex(1);
        SpawnObject();
    }

    // Cycle to the previous object
    public void goPrevious()
    {
        CycleIndex(-1);
        SpawnObject();
    }
}
