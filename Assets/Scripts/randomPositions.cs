using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPositions : MonoBehaviour
{
    [SerializeField] private Vector3[] positions;

    // Start is called before the first frame update
    void Start()
    {
        int randomNumber = Random.Range(0, positions.Length);
        transform.position = positions[randomNumber];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
