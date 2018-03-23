using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    private static int Ai;
    private static int Player;
    public GameObject Sphere;

    void OnCollisionEnter(Collision collision)
    {
        var cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        var script  =cameraObject.GetComponent<Pickup>();
        script.ShakeCamera();

        if (this.name == "RightWall")
            Ai = Ai + 1;
        if (this.name == "LeftWall")
            Player = Player + 1;
        
        if (collision.gameObject.CompareTag("Sphere"))
        {
            KillSelf(collision.gameObject);
            InstantiateSphere();
        }
        SetScore();
    }

    private void InstantiateSphere()
    {
        if (Ai < 10 && Player < 10)
        {
            Sphere = (GameObject)Resources.Load("Prefabs/Sphere", typeof(GameObject));
            GameObject InstantiatedPrefab = Instantiate(Sphere) as GameObject;
            //Debug.Log("Sphere Created");
        }
    }
    void KillSelf(GameObject gameObject)
    {
        Destroy(gameObject);
        // Debug.Log("Sphere Destroyed");
    }
    private void SetScore()
    {
        var scoreText =string.Format("Ai: {0} - Player: {1}",Ai, Player);

        if (Ai == 10)
            ShowLose();
     
        else if (Player == 10)
            ShowWin();
      
        Debug.Log(scoreText);
        GameObject.FindObjectOfType<Text>().text = scoreText;
    }
    private void ShowLose()
    {
        var cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        var script = cameraObject.GetComponent<Pickup>();
        script._showLose = true;
        
    }
    private void ShowWin()
    {
        var cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        var script = cameraObject.GetComponent<Pickup>();
        script._showWin = true;
    }
}

