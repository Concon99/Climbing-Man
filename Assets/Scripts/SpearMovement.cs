using UnityEngine;
using System.Collections;


public class SpearMovement : MonoBehaviour
{
    public GameObject SpearPreFab;
    public Transform spawnPoint;
    [SerializeField] private AudioSource SpearSound;
    public float spearspeed;
 

    void Start()
    {
        StartCoroutine(FallingLoop());
    }


    IEnumerator FallingLoop()
    {
        yield return new WaitForSeconds(15f);
        while (true)
        {
            float Startingtime = Random.Range (2f , 7f); //setting the random time to wait for a spear
            yield return new WaitForSeconds(Startingtime);
            float randomPosition = Random.Range(5f, -5); //setting a random area for the spear to spawn


            float RandomTime = Random.Range (2f , 7f); //setting the random time to wait for a spear
           
            yield return new WaitForSeconds(RandomTime);

            GameObject newSpear = Instantiate(SpearPreFab, new Vector3(spawnPoint.position.x, randomPosition, spawnPoint.position.z), Quaternion.identity); //creates the spear position and rotation
            newSpear.transform.parent = transform;
            newSpear.transform.localScale = Vector3.one;  //creates spear + size
            SpearSound.Play();
            while (newSpear.transform.position.x > -9f) //the point in which the spear stops moving and is deleted
            {
                newSpear.transform.Translate(Vector3.left * Time.deltaTime * spearspeed); //speed at witch the spear falls down at you can change this by multiplying
                yield return null;
            }


            spearspeed += 0.1f;
            Destroy(newSpear); //destroys the spear
        }
    }
}