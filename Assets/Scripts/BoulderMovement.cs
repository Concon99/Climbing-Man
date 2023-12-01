using UnityEngine;
using System.Collections;


public class BoulderMovement : MonoBehaviour
{
    public GameObject boulderPrefab;
    public Transform spawnPoint;
    private float difficulty = 3f;
    [SerializeField] private AudioSource ThrowSoundEffect;
 




    void Start()
    {
        StartCoroutine(FallingLoop()); //calling the loop
    }


    IEnumerator FallingLoop() //define loop
    {
        while (true)
        {




            float randomScale = Random.Range(4f,7f); //making the random size of the rocks


            float randomPosition = Random.Range(5f, -5f); //setting a random area for the rocks to spawn (Y AXIS)


            float RandomTime = Random.Range (0f , 0.3f); //setting the random time to wait for a rock
           
            yield return new WaitForSeconds(RandomTime); //Waits a random amount of time to spawn object

            //dont need to change any of this
            //replace everything with "boulder" newboulder is created on line 42
            GameObject newBoulder = Instantiate(boulderPrefab, new Vector3(randomPosition, spawnPoint.position.y, spawnPoint.position.z), Quaternion.identity); //creates the rocks position and rotation 
            newBoulder.transform.parent = transform;
            newBoulder.transform.localScale = Vector3.one * randomScale; //creates the random size of the rock
            ThrowSoundEffect.Play(); //plays sound effect, remove
            while (newBoulder.transform.position.y > -6f) //the point in which the rock stops moving and is deleted
            {
                newBoulder.transform.Translate(Vector3.down * Time.deltaTime * difficulty); //speed at witch the rock falls down at you can change this by multiplying
                yield return null;
            }


            Destroy(newBoulder); //destroys the rock
            difficulty += 0.1f; //increases difficulty
        }
    }
}