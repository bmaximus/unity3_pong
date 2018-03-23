using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{

    public GameObject Sphere;

    public float shakeAmount;
    public float shakeDuration;
    
    float shakePercentage;
    float startAmount;
    float startDuration; 

    public bool smooth = false;
    public float smoothAmount = 2f;
    public bool _showLose = false;
    public bool _showWin = false;
    
    void Start()
    {

        InstansiateSphere();
    }
    private void InstansiateSphere()
    {
        Sphere = (GameObject)Resources.Load("Prefabs/Sphere", typeof(GameObject));
        GameObject InstantiatedPrefab = Instantiate(Sphere) as GameObject;
        
        //Debug.Log("Sphere Created");
    }
    public void ShakeCamera()
    {
        startAmount = shakeAmount / 100;
        startDuration = shakeDuration / 100;

         StartCoroutine(Shake());
    }
    IEnumerator Shake()
    {
        var innerShakeDuration = shakeDuration;

        while (innerShakeDuration > 0.01f)
        {
            Vector3 rotationAmount = Random.insideUnitSphere * shakeAmount;
            rotationAmount.z = 0;

            shakePercentage = innerShakeDuration / startDuration;

            shakeAmount = startAmount * shakePercentage;
            innerShakeDuration = Mathf.Lerp(innerShakeDuration, 0, Time.deltaTime);

            if (smooth)
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rotationAmount), Time.deltaTime * smoothAmount);
            else
                transform.localRotation = Quaternion.Euler(rotationAmount);
            yield return null;
        }
        transform.localRotation = Quaternion.identity;

    }
    void LateUpdate()
    {
        if (_showLose)
        {
            StartCoroutine(ShowLose());            
            _showLose = false;
        }
        if (_showWin)
        {
            StartCoroutine(ShowWin());
            _showWin = false;

        }
    }
    IEnumerator ShowLose()
    {
        transform.Rotate(Vector3.left, 90.0f);           

        transform.Translate(new Vector3(0, -1580, -1580));
        
        
        var cameraObject = GameObject.FindObjectOfType<Camera>();
        cameraObject.fieldOfView = 70;
        yield return null;
    }
    
    IEnumerator ShowWin()
    {
        transform.Rotate(Vector3.right, 90.0f);
     
        transform.Translate(new Vector3(270, 1580, -1510));
        
        var cameraObject = GameObject.FindObjectOfType<Camera>();
        //cameraObject.fieldOfView = 70;

        yield return new WaitForSeconds(5);
    }

}
