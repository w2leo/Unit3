using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);        
    }
}
