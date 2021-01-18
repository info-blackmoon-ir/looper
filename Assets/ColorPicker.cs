using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    [SerializeField] private GameObject[] colorsList;

    [SerializeField] float rotationSpeed = 100f;
    private bool isDragging = false;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    private void OnMouseDrag()
    {
        isDragging = true;
        
    }

    private void OnMouseDown()
    {
        rb.freezeRotation = true;
        rb.freezeRotation = false;
        print("true");
    }

    private void FixedUpdate()
    {
        if (isDragging)
        {
            float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;
            float y = Input.GetAxis("Mouse Y") * rotationSpeed * Time.fixedDeltaTime;


            rb.AddTorque(Vector3.forward * -x);
            rb.AddTorque(Vector3.forward * y);
        }
    }
}

