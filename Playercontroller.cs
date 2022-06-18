using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    #region oldregion
    //    Vector3 innitialvelocity;
    //    float pertime = 0.1f;
    //    [SerializeField]
    //    LineRenderer arrowtrail;
    //    [SerializeField]
    //    Transform head;
    //    Vector3 startingposition;
    //    float rot_yaw=0;
    //    float rot_pitch = 0;
    //    float trail_rot_yaw = 0;
    //    Animator anim;
    //    [SerializeField]
    //    GameObject aimer;
    //    [SerializeField]
    //    GameObject arrow;
    //    [SerializeField]
    //    GameObject bow;


    //    GameObject local_arrow;
    //    private void Start()
    //    {

    //        //innitialvelocity = Vector3.forward*100.0f;
    //        anim= GetComponent<Animator>();
    //    }
    //    void Update()
    //    {
    //        //Vector3 scale = new Vector3(Input.GetAxis("Horizontal"),0 ,Mathf.Clamp01(Input.GetAxis("Vertical"))) 
    //        //    * Time.deltaTime * 20.0f;
    //        //this.transform.position += transform.forward*scale.z+transform.right*scale.x;
    //        //rot_yaw += Input.GetAxis("Mouse X");
    //        //rot_yaw = Mathf.Clamp(rot_yaw, -45, 45);

    //        //Debug.Log(transform.position);
    //        //if (Input.GetMouseButton(0))
    //        //{
    //        //    arrowtrail.positionCount = (int)(5/0.1f);
    //        //    startingposition = aimer.transform.position;

    //        //    List<Vector3> points = new List<Vector3>();
    //        //    rot_pitch += Input.GetAxis("Mouse Y");

    //        //    rot_pitch = Mathf.Clamp(rot_pitch, -45, 45);

    //        //    innitialvelocity = Quaternion.Euler(-rot_pitch, 1, 1)* aimer.transform.forward * 50.0f;
    //        //    //Debug.Log(innitialvelocity);
    //        //    for (float t = 0; t < 5; t = t + pertime)
    //        //    {
    //        //        Vector3 newpos;
    //        //        newpos = startingposition+innitialvelocity*t;

    //        //        newpos.y = startingposition.y +
    //        //            innitialvelocity.y * t + Physics.gravity.y * 0.5f * t * t;

    //        //        //newpos = Quaternion.Euler(-rot_pitch, 1, 0) * newpos;
    //        //        points.Add(newpos);
    //        //    }

    //            //arrowtrail.positionCount = points.Count;
    //            //arrowtrail.SetPositions(points.ToArray());

    //            //for two test positions
    //            //startingposition = head.position;

    //            //rot_pitch += Input.GetAxis("Mouse Y");
    //            //rot_pitch = Mathf.Clamp(rot_pitch, -45, 45);

    //            //innitialvelocity = transform.forward * 50.0f;
    //            //Vector3 newpos = startingposition + innitialvelocity;

    //            //newpos = Quaternion.Euler(-rot_pitch, rot_yaw, 1) * newpos;

    //            //List<Vector3> points = new List<Vector3>();
    //            //points.Add(startingposition);
    //            //points.Add(newpos);

    //            arrowtrail.SetPositions(points.ToArray());
    //        }
    //        if (Input.GetMouseButtonUp(0))
    //        {
    //            rot_pitch = 0;
    //            trail_rot_yaw = 0;
    //            arrowtrail.positionCount = 0;
    //            local_arrow = Instantiate(arrow, startingposition,Quaternion.Euler(0,90,0), bow.transform) as GameObject;
    //            local_arrow.
    //                GetComponent<Rigidbody>().
    //                AddForce(innitialvelocity, ForceMode.VelocityChange);

    //            local_arrow.transform.parent = null;
    //            anim.speed = 1;
    //        }
    //       transform.eulerAngles= Quaternion.Euler(0, rot_yaw, 0).eulerAngles;

    //    }
    //    public void aim()
    //    {
    //        anim.speed = 0;
    //    }
    //}
    #endregion
        //this is used for the mechanics of the player movement
    float mouse_x, mouse_y;
    [SerializeField]
    GameObject camcenterref;
   

    private void Awake()
    {
        camcenterref = GameObject.Find("CameraCenter");
        
    }
    private void Update()
    {
        mouse_x += Input.GetAxis("Mouse X");
        mouse_y += Input.GetAxis("Mouse Y");
        if(Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical") != 0
            ||  (PlayerAnimationController.animator.GetBool("Equipbow")))
        {
         
            //destrotation.eulerAngles.y = camcenterref.transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0,camcenterref.transform.rotation.eulerAngles.y,0);
            //Quaternion.Slerp(currentrotation, destrotation,5f);
            //Debug.Log(transform.rotation.y);
        }
    }
}
