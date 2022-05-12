using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSize : MonoBehaviour
{
    [SerializeField] float timer = 0f;
    [SerializeField] float growTime = 4f;
    [SerializeField] float maxSize = 5f;
    [SerializeField] bool isMaxSize = false;
    
    // Start is called before the first frame update
    void Start()
    {   // If the object is not at its max size
        if (!isMaxSize == false)
        {
            // Execute the coroutine
            StartCoroutine(Grow());
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Invoking a coroutine 
    public IEnumerator Grow()
    {
        // The starting size of the balloons
        Vector2 startScale = transform.localScale;
        // This is the size the ballons will grow to (maxSize 5f)
        Vector2 maxScale = new Vector2(maxSize, maxSize);

        do
        {
            // Growing the object in a certain amount of time
            // Checks how close the timer is to the grow time
            transform.localScale = Vector3.Lerp(startScale, maxScale, timer / growTime);
            // Increming the timer
            timer += Time.deltaTime;
            // Pausing the execution
            yield return null;
        }
        while (timer < growTime);
        // When the scale is equal to the max size change to true
        isMaxSize = true;

    }

    
}
    
