using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramanager : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    
    Vector3 originalloc;
    Vector3 startpos_PLAYER;
    Vector3 m_startposition;
    float mouse_x, mouse_y;
    GameObject camera=null;

    public static Cameramanager instance;

  
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        startpos_PLAYER = player.transform.position;
        m_startposition = transform.position;
        camera = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
            followplayer();
            controleaim();
            orbitplayer();
     
    }
    void controleaim()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (PlayerAnimationController.animator.GetBool("Equipbow"))
            {

                //Vector3 lerppos = Vector3.Lerp(camera.transform.localPosition
                //    , camera.transform.localPosition - new Vector3(0, 0, -1.2f),.05f);
               camera.transform.localPosition-=new Vector3(0, 0, -1.2f);
                // this.transform.localRotation = Quaternion.Euler(Vector3.zero);
            }
            else
            {
                //Vector3 lerppos = Vector3.Lerp(camera.transform.localPosition
                //  , camera.transform.localPosition - new Vector3(0, 0, 1.2f), .05f);
                camera.transform.localPosition -=new Vector3(0, 0, 1.2f); ;
            }
        }
    }
   void followplayer()
    {
        Vector3 dir = (player.transform.position - startpos_PLAYER).normalized;
        float mag = Vector3.Distance(player.transform.position, startpos_PLAYER);

        transform.position =
             (m_startposition + dir * mag);
       // transform.position = (m_startposition + dir * mag);

        startpos_PLAYER = player.transform.position;
        m_startposition = transform.position;
    }
    void orbitplayer()
    {
        mouse_x += Input.GetAxis("Mouse X");
        mouse_y += Input.GetAxis("Mouse Y");
        mouse_y = Mathf.Clamp(mouse_y, -45.0f, 45.0f);
        Quaternion camroat = transform.rotation;
        Quaternion destinationrot_yaw = Quaternion.Euler(0, mouse_x, 0);
        Quaternion destinationrot_pitch = Quaternion.Euler(-mouse_y, 0, 0);

        Quaternion targetrotation = destinationrot_yaw * destinationrot_pitch;
        transform.rotation =
            Quaternion.Slerp(this.transform.rotation, targetrotation, .05f);

    }
}
