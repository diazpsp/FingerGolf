using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public Vector3 Position => rb.position;

    public bool IsMoving => rb.velocity!=Vector3.zero;



    // Start is called before the first frame update
    private void Awake()
    {
        if(rb == null)
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void AddForce(Vector3 force){
        rb.AddForce(force,ForceMode.Impulse);
    }

    private void FixedUpdate(){
        if(rb.velocity != Vector3.zero && rb.velocity.magnitude < 0.5f)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
