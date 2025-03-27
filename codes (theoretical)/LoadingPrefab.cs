// Loading assets from the Resources folder using the Resources.Load(path, systemTypeInstance)
using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    // Instantiates a Prefab named "enemy" located in any Resources folder in your project's Assets folder.
    void Start()
    {
        GameObject instance = Instantiate(Resources.Load("enemy", typeof(GameObject))) as GameObject;
    }
}