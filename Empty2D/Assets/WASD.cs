using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD : MonoBehaviour
{
    // Variables
    float SPEED = 5.0f;

    // Update is called once per frame
    void Update()
    {
        // Initializing vector direction to (0,0)
        Vector2 direction = Vector2.zero;

        // If user presses A -> go left
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }

        // If user presses W -> go up
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }

        // If user presses S -> go down
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }

        // If user presses D -> go right
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }

        // Calculating the velocity of the game object
        Vector2 velocity = direction.normalized * SPEED;

        // Integrating velocity to update position
        transform.position = transform.position + (Vector3)(velocity * Time.deltaTime);
    }
}
