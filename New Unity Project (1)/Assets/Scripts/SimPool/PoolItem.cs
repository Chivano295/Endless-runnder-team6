using UnityEngine;

public class PoolItem : MonoBehaviour
{
    /// <summary>
    /// Sets the pool an object belongs to
    /// </summary>

    private ObjectPool myPool;
    public ObjectPool Pool { set { myPool = value; } }

    #region Activation and deactivation of poolitems
    //Calls activate and deactivate poolitem functions
    protected virtual void Activate() { }
    protected virtual void Deactivate() { }
    #endregion

    #region Initilization and Pool Return
    //Sets position, rotation and (possibly) parent and activates pool item
    public void Init(Vector3 position, Quaternion rotation, Transform parent)
    {
        transform.position = position;
        transform.rotation = rotation;
        transform.parent = parent;

        Activate();
    }

    //Deactivates and returns poolitem to objectpool
    public void ReturnToPool()
    {
        Deactivate();
        myPool.ReturnPooledObject(this);
    }
    #endregion
}
