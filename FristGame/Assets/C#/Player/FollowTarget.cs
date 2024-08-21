using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float zoomSpeed = 5;
    private Vector3 offset;
    public Transform PlayerTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Transform transform = PlayerTransform.transform;
        transform.position = PlayerTransform.position + offset;
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        //Àı∑≈ÀŸ∂»
        Camera.main.fieldOfView += scroll * zoomSpeed;
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 30, 80);
    }
}
