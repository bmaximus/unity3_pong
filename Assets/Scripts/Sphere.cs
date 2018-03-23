using UnityEngine;
using System.Collections;

public class Sphere : MonoBehaviour
{

    public float Speed = 50.0f;
    public Transform _Sphere;
    private bool _pressed = false;
    void Start()
    {
        var rightBar = GameObject.Find("RightBar");
        transform.position = new Vector3(720, rightBar.transform.position.y, 0);
        _pressed = false;
    }
    void Update()
    {      
        if (Input.GetKey(KeyCode.Space) && !_pressed)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-720, -400) * Speed);
            _pressed = true;
        }    
    }  
}
