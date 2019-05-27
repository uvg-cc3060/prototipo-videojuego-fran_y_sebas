using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class objectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool{
        public string tag;
        public GameObject prefab;
        public int size;
    }
    public static objectPooler Instance;

    private void Awake(){
        Instance = this;
    }
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools){
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i<pool.size; i++){
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }

    }

    public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rot){
        while(poolDictionary[tag].Count !=0){
            GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        
            if (!poolDictionary.ContainsKey(tag)){
                Debug.LogWarning("Pool con tag" + tag + "no existe");
                return null;
            }
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rot;
            
        IPulledNecrosis pooledObj= objectToSpawn.GetComponent<IPulledNecrosis>();

            if (pooledObj != null){
                pooledObj.onObjectSpawn();
            }

            //poolDictionary[tag].Enqueue(objectToSpawn);
            return objectToSpawn;

            }
            return null;
        
    }
}
