using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EBCollision : MonoBehaviour
{
    public PlayerControl script;
    public GameObject myObject;
   
    private void Start()
    {
        ShowObject();
        
    }
   
   
    // This function is called when the collider enters another collider marked as a trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other collider has the "Player" tag
        if (other.CompareTag("Player"))
        {
            //Triggers collecting bar
            CollectBar();
        }
    }


    public void CollectBar()
    {
        Debug.Log("Gained one speed!");
        script.speed += 1;
        HideObject();
    }


    public void HideObject()
    {
        myObject.SetActive(false);
    }


    // Function to show the object
    public void ShowObject()
    {
        myObject.SetActive(true);
    }
}