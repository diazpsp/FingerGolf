using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Ball ball;
    [SerializeField] Transform camPivot;
    [SerializeField] Camera cam;
    [SerializeField] LayerMask ballLayer;
    [SerializeField] LayerMask Raylayer;
    
    [SerializeField] Vector2 camSensitivity;
    [SerializeField] float shootForce;
    [SerializeField] AudioSource audio;

    Vector3 lastMousePosition;

    float ballDistance;


    bool isShooting;

    float forceFactor;
    Vector3 forceDir;

    void Start(){
        ballDistance = Vector3.Distance(cam.transform.position, ball.Position);
        audio = GetComponent<AudioSource>();
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ball.IsMoving == false){
           audio.Play();
         
        }
        if(ball.IsMoving){
           return;
         
        }
         
        // if(this.transform.position != ball.Position){
        //     this.transform.position = ball.Position;
        // }
        if(Input.GetMouseButtonDown(0))
        {
           
            var ray = cam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,ballDistance,ballLayer))
   
                isShooting = true;
            
        }

        if(Input.GetMouseButton(0) && isShooting == true){

             var ray = cam.ScreenPointToRay(Input.mousePosition);
             RaycastHit hit;
             if(Physics.Raycast(ray, out hit,ballDistance*2,Raylayer)){
                Debug.DrawLine(ball.Position, hit.point);
                

                var forceVector = ball.Position - hit.point;
                forceVector = new Vector3(forceVector.x,0,forceVector.z);
                forceDir = forceVector.normalized;
                var forceMagnitude = forceVector.magnitude;
                Debug.Log(forceMagnitude);
                forceMagnitude = Mathf.Clamp(forceMagnitude,0,5);
                forceFactor = forceMagnitude/5;
                

             }
        }

        if(Input.GetMouseButton(0) && isShooting == false)        {
            var current = cam.ScreenToViewportPoint(Input.mousePosition);
            var last = cam.ScreenToViewportPoint(lastMousePosition);

            var delta = current - last;
            
            //rotate horizontal
            camPivot.transform.RotateAround(ball.Position,Vector3.up,delta.x*camSensitivity.x);

            //rotate vertical
            camPivot.transform.RotateAround(ball.Position,cam.transform.right, -delta.y*camSensitivity.y);

            var angle = Vector3.SignedAngle(Vector3.up,cam.transform.up, cam.transform.right);


            //kalau melewati batas , putar balik
            if(angle<3 )
            camPivot.transform.RotateAround(
                ball.Position,cam.transform.right, 3- angle);

            else if(angle > 65)
                camPivot.transform.RotateAround(
                ball.Position,cam.transform.right, 65- angle);
            
        }

        
        if(Input.GetMouseButtonUp(0)){
            ball.AddForce(forceDir*shootForce*forceFactor);
            forceFactor = 0;
            forceDir = Vector3.zero;
            isShooting = false;
           
        }
        lastMousePosition = Input.mousePosition;
    }

       
}

