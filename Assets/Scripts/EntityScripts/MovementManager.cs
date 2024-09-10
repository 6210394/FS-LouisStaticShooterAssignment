using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public bool canMoveHorizontally = true;
    public bool canMoveVertically = true;

    public float moveSpeed = 5f;
    public float moveX = 0f;
    public float moveY = 0f;

public float minX = -10f; // Minimum horizontal limit
public float maxX = 10f;  // Maximum horizontal limit
public float minY = -5f;  // Minimum vertical limit
public float maxY = 5f;   // Maximum vertical limit

public bool limitHorizontal = true; // Flag to enable/disable horizontal limit
public bool limitVertical = true;   // Flag to enable/disable vertical limit

// Update is called once per frame
void Update()
{
    // Get input from arrow keys
    if (canMoveHorizontally)
    {
        moveX = Input.GetAxis("Horizontal");
    }
    if (canMoveVertically)
    {
        moveY = Input.GetAxis("Vertical");
    }

    // Create a new vector for movement
    Vector3 movement = new Vector3(moveX, moveY, 0f);

    // Apply movement to the GameObject
    transform.position += movement * moveSpeed * Time.deltaTime;

    // Clamp the position within the defined limits if enabled
    float clampedX = transform.position.x;
    float clampedY = transform.position.y;

    if (limitHorizontal)
    {
        clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
    }
    if (limitVertical)
    {
        clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
    }

    transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }   
}