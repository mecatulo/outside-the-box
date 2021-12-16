using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour
{
    [SerializeField] private Transform downTransform;
    [SerializeField] private Transform buttonMesh;
    [SerializeField] private GameObject lockPad;
    [SerializeField] private string key;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            lockPad.SendMessage("KeyEntry", key);
            buttonMesh.position = downTransform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            buttonMesh.localPosition = Vector3.zero;
    }
}
