using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    // Variables
    const float SPEED = 5.0f;
    bool destination_set;
    Vector2 new_position;
    Vector2 normalized_path;
    float distance;

    // Update is called once per frame
    void Update()
    {
        // Returns true during the frame the user pressed the given mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // Returns world coordinates of where the user clicked on the game screen
            new_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        
            // Returns true if user clicked on game screen
            destination_set = true;
        }
        
        // Game object is traveling from starting point to end point
        else if (destination_set && (Vector2)transform.position != new_position)
        {
            // Calculating the normalized path between the end and starting point
            normalized_path = (new_position - (Vector2)transform.position).normalized;

            // Scaling to SPEED and integrating position
            transform.position = (Vector2)transform.position + (normalized_path * SPEED * Time.deltaTime);

            // Calculating the magnitude between the end and starting point
            distance = (new_position - (Vector2)transform.position).magnitude;

            // Allows for precise click to move. Function will be ignored until the distance gets smaller.
            // Removes jittering of the game object by "reminding" the game object where to land precisely. 
            if (SPEED * Time.deltaTime > distance)
                transform.position = new_position;
        }

        // Reached the end point/where the user clicked in the game screen
        else
            destination_set = false;
    }
}
