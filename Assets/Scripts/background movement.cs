using System.Collections;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    public float scrollSpeed = 5.0f; // Adjust this value to control the speed of the scrolling
    public float resetYPosition = -10.0f; // Y position where the background resets
    public float resetInterval = 5.0f; // Time interval between resets

    void Start()
    {
        StartCoroutine(MoveCoroutine());
    }

    IEnumerator MoveCoroutine()
    {
        while (true)
        {
            // Move the background upward
            transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);

            // Check if the Y position exceeds the resetYPosition
            if (transform.position.y > resetYPosition)
            {
                // Reset the Y position after the specified interval
                yield return new WaitForSeconds(resetInterval);
                transform.position = new Vector3(transform.position.x, resetYPosition, transform.position.z);
            }

            yield return null;
        }
    }
}
