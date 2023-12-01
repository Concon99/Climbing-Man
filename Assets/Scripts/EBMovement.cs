using UnityEngine;
using System.Collections;


public class EBMovement : MonoBehaviour
{
    public GameObject EnergyBarPrefab;
    public Transform spawnPoint;
    [SerializeField] private AudioSource ThrowSoundEffect;
 

    void Start()
    {
        StartCoroutine(FallingLoop());
    }


    IEnumerator FallingLoop()
    {
        while (true)
        {
            float randomPosition = Random.Range(7f, -7f); //setting a random area for the bar to spawn


            float RandomTime = Random.Range (5f , 20); //setting the random time to wait for a bar
           
            yield return new WaitForSeconds(RandomTime);

            GameObject newEnergyBar = Instantiate(EnergyBarPrefab, new Vector3(randomPosition, spawnPoint.position.y, spawnPoint.position.z), Quaternion.identity); //creates the bar position and rotation
            newEnergyBar.transform.parent = transform;
            newEnergyBar.transform.localScale = Vector3.one;  //creates bar + size
            ThrowSoundEffect.Play();
            while (newEnergyBar.transform.position.y > -6f) //the point in which the bar stops moving and is deleted
            {
                newEnergyBar.transform.Translate(Vector3.down * Time.deltaTime * 3); //speed at witch the bar falls down at you can change this by multiplying
                yield return null;
            }


            Destroy(newEnergyBar); //destroys the bar
        }
    }
}