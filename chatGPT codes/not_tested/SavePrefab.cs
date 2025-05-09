// this code was generated by chatGPT AI code generator
using UnityEngine;

public class SavePrefab : MonoBehaviour
{
    public GameObject gameObjectToSave;
    public bool runIt = false;
    public bool writeOver = true;
    public bool runOnAwake = false;

    void Start(){
        if(runOnAwake){
            runIt = true;
        }
    }

    void Update(){
        if(runIt){
            runIt = false;
            saveMyPrefab(writeOver);
        }
    }

    public void saveMyPrefab(bool overwrite){
        if(overwrite){
            SavePrefabOverwrite();
        } else {
            SavePrefabNormal();
        }
    }

    void SavePrefabNormal()
    {
        // Check if the object to save is not null
        if (gameObjectToSave == null)
        {
            Debug.LogError("No object to save as prefab.");
            return;
        }

        // Create a path for the prefab in the Resources folder
        string prefabPath = "Assets/Resources/Generated/" + gameObjectToSave.name + ".prefab";

        // Check if a prefab with the same name already exists
        if (AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject)))
        {
            Debug.LogError("A prefab with that name already exists.");
            return;
        }

        // Create the prefab
        PrefabUtility.SaveAsPrefabAsset(gameObjectToSave, prefabPath);
        Debug.Log("Prefab saved at " + prefabPath);
    }

    void SavePrefabOverwrite()
    {
        // Check if the prefab already exists
        if (AssetDatabase.LoadAssetAtPath("Assets/Resources/" + prefabName + ".prefab", typeof(GameObject)))
        {
            AssetDatabase.DeleteAsset("Assets/Resources/" + prefabName + ".prefab");
        }

        // Create a new prefab
        Object prefab = PrefabUtility.SaveAsPrefabAsset(gameObjectToSave, "Assets/Resources/" + prefabName + ".prefab");
        AssetDatabase.Refresh();
    }
}