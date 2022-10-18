using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float moveSpeed = 15f;
    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (!playerController.GameIsOver)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }
}
