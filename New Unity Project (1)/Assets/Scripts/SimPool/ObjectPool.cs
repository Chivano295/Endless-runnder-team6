using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
     /// <summary>
     /// Responsible for the creation of the objectpool
     /// </summary>
    
    public GameObject pooledObject;
    public int poolSize;

    public bool autoExpand;
    public int expansionSize;

    //Stack irrelevant in the work field?
    private Stack<PoolItem> objectPool;

    //Creates set size of itempool

    #region Creates object pool at start
    private void Awake()
    {
        objectPool = new Stack<PoolItem>(poolSize);

        Expand(poolSize);
    }
    #endregion

    #region Pool Expansion
    //Expands itempool if itempool runs out of poolitems
    private void Expand(int expansionSize)
    {
        for (int i = 0; i < expansionSize; i++)
        {
            GameObject newObject = Instantiate(pooledObject);
            PoolItem item = newObject.GetComponent<PoolItem>();
            item.Pool = this;
            ReturnPooledObject(item);
        }
    }
    #endregion  

    #region Gets and returns pooled objects to object pool
    //Gets the position, rotation and possible parent from poolitem when game is running
    public GameObject GetPooledObject(Vector3 position, Quaternion rotation, Transform parent=null)
    {
        if (objectPool.Count == 0)
        {
            Expand(expansionSize);
        }

        PoolItem item = objectPool.Pop();
        item.Init(position, rotation, parent != null ? parent : transform);
        item.gameObject.SetActive(true);
        return item.gameObject;
    }

    //deactivates and returns poolitem to itempool when game is running
    public void ReturnPooledObject(PoolItem item)
    {
        if (!item.gameObject.activeSelf)
        {
            return;
        }
        item.transform.parent = transform;
        item.gameObject.SetActive(false);
        
        objectPool.Push(item);
    }
    #endregion
}
