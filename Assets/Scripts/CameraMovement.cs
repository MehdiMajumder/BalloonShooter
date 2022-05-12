using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour

{
    [SerializeField] float followSpeed = 2f;
    [SerializeField] float offset = 1f;
    [SerializeField] Transform target;
    [SerializeField] Vector3 minCameraPos;
    [SerializeField] Vector3 maxCameraPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    // Camera position
    Vector3 newPosition = new Vector3(target.position.x, target.position.y + offset, -10f);
    
        // Smooth player movement
        transform.position = Vector3.Lerp
        (transform.position, newPosition, followSpeed * Time.deltaTime);

        // Restricting camera movement
        transform.position = new Vector3 (Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
            Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
            Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));

    }


}