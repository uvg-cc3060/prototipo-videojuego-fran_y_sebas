using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecrosisSpawner : MonoBehaviour
{
    public GameObject necrosisPrefab;

    objectPooler objPool;

    private void Start(){
        objPool = objectPooler.Instance;
    }
    void FixedUpdate() {
        objPool.SpawnFromPool("necrosis", transform.position, Quaternion.identity);
    }
}
