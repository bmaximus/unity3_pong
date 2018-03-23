using UnityEngine;
using System.Collections;

public class LeftBar : MonoBehaviour
{

    /// <summary>
    /// Normal value is between 0.6 - 1 
    /// No more than 1
    /// </summary>
    public float AiStrength = 1.0f;


    void FixedUpdate()
    {

        var sphere = GameObject.FindGameObjectWithTag("Sphere");
        if (sphere != null)
        {
            if ((sphere.transform.position.y > -330 && sphere.transform.position.y < 330))
            {
                transform.position = new Vector3(transform.position.x, sphere.transform.position.y * AiStrength);
            }
            else if (sphere.transform.position.y < -330)
            {
                transform.position = new Vector3(transform.position.x, -329 * AiStrength);
            }
            else if (sphere.transform.position.y > 330)
            {
                transform.position = new Vector3(transform.position.x, 329 * AiStrength);
            }
        }
    }
}
