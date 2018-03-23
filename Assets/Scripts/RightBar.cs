using UnityEngine;
using System.Collections;

public class RightBar : MonoBehaviour {

    public float Speed = 500.0f;
	void Update () {    
        
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 310)
        {
            transform.Translate(Vector3.up * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -310)
        {
            transform.Translate(Vector3.down * Time.deltaTime * Speed);
        }    
    }
}
