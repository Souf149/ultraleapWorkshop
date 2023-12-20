using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmUIScript : MonoBehaviour
{

    public GameObject myPrefab1;
    public GameObject myPrefab2;
    public GameObject myPrefab3;
    public GameObject myPrefab4;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button1Pressed()
    {
        var gameObject = Instantiate(myPrefab1, Camera.main.transform.position + Camera.main.transform.forward*0.4f, Quaternion.identity);
        gameObject.name = "interactableObject";
    }

    public void Button2Pressed()
    {
        var gameObject = Instantiate(myPrefab2, Camera.main.transform.position + Camera.main.transform.forward * 0.4f, Quaternion.identity);
        gameObject.name = "interactableObject";
    }

    public void Button3Pressed()
    {
        var gameObject = Instantiate(myPrefab3, Camera.main.transform.position + Camera.main.transform.forward * 0.4f, Quaternion.identity);
        gameObject.name = "interactableObject";
    }

    public void Button4Pressed()
    {
        var gameObject = Instantiate(myPrefab4, Camera.main.transform.position + Camera.main.transform.forward * 0.4f, Quaternion.identity);
        gameObject.name = "interactableObject";
    }



}
