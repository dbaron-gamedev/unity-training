using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Create_Enemy : MonoBehaviour
{
    public float mapSize = 5f;
    
    public KeyCode triggerKeyCreate = KeyCode.Space;
    public KeyCode triggerKeyDelete = KeyCode.Tab;
    
    private List<GameObject> spawnedObjects = new List<GameObject>();
    
    private GameObject parentObject;
    
    void Update()
    {
        if (Input.GetKeyDown(triggerKeyCreate))
        {
            Create();
        }
        
        else if (Input.GetKeyDown(triggerKeyDelete))
        {
            Delete();
        }
    }

    void Create()
    {
        if (spawnedObjects.Count == 0)
        {
            parentObject = new GameObject("ParentSpawnedObject");
        }

        if (spawnedObjects.Count > 10)
        {
            return;
        }
        
        GameObject childObj = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        childObj.name = "SpawnedObject_" + spawnedObjects.Count;
        childObj.transform.SetParent(parentObject.transform, false);
        
        childObj.transform.localPosition = new Vector3(Random.Range(-mapSize, mapSize), 1f, Random.Range(-mapSize, mapSize));
        childObj.transform.localRotation = Quaternion.Euler(0, Random.Range(0,360), 0);
        
        spawnedObjects.Add(childObj);
        childObj.AddComponent<GizmoSpawnDirection>();
    }
    
    void Delete()
    {
        Destroy(spawnedObjects[spawnedObjects.Count - 1]);
        spawnedObjects.RemoveAt(spawnedObjects.Count - 1);
    }
    
}
