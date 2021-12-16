using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public string key;

    public void SendKey()
    {
        this.transform.GetComponentInParent<LockController>().KeyEntry(key);
    }
}
