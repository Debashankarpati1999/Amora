using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    // Start is called before the first frame update
    // .313226e-12,-0.01075402,00
    //0,0,0
    
    [System.Serializable]
    class BowProperties
    {
      public Transform EquipTransform;
      public Transform UnequipTransform;
      public GameObject Equipparent;
      public GameObject Unequipparent;
    }
    [SerializeField]
     BowProperties bowproperties;
    [System.Serializable]
    class Stringproperties
    {
        public GameObject pullparent;
        public GameObject initialstringparent;
        public GameObject B_string;
        public Transform initialtransform;
        public Vector3 initialstringpos=new Vector3(0.313226e-12f, -0.01075402f, 0);
        
    }
    [SerializeField]
    Stringproperties stringproperties;
    void Start()
    {
        stringproperties.B_string =
            GameObject.FindGameObjectWithTag("string");
        stringproperties.pullparent =
            GameObject.FindGameObjectWithTag("ArrowLaunchfinger");
        //coping the initial parent of the string prior to change the pparent
        stringproperties.initialstringparent =
            stringproperties.B_string.transform.parent.gameObject;
      

    }
    [SerializeField]
    LineRenderer arrowprojectileline;
    [SerializeField]
    GameObject arrowhead;
    [SerializeField]
    GameObject Arrowproxyreference;
    private bool startdrwingPP=false;
    private void Awake()
    {
        arrowhead = arrowprojectileline.transform.GetChild(0).gameObject;
        Arrowproxyreference.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
        

         }
        if (startdrwingPP)
            drawprojectilepredictor();
        else
            resetprojectilerenderer();
    }
    public void equip()
    {
        if (PlayerAnimationController.animator.GetBool("Equipbow"))
        {
            Debug.Log("Bow Equipped");
            this.transform.parent = bowproperties.Equipparent.transform;
            this.transform.position = bowproperties.EquipTransform.position;
            this.transform.rotation = bowproperties.EquipTransform.rotation;

        }
    }
    public  void unequip()
    {
        Debug.Log("Relocating transform");
        this.transform.position = bowproperties.UnequipTransform.position;
        this.transform.rotation = bowproperties.UnequipTransform.rotation;
        this.transform.parent = bowproperties.Unequipparent.transform;
    }
    public void pullstring()
    {
        //coping the transform of the string prior to change the transform
        //stringproperties.initialtransform
        // = stringproperties.B_string.transform;
        Debug.Log("Bow pullstring called");
        //setting up the parent for string while pulling
        stringproperties.B_string.transform.parent =
              stringproperties.pullparent.transform;

        stringproperties.B_string.transform.position =
            stringproperties.pullparent.transform.position;
        Debug.Log("String position and rotation set to finger");
        stringproperties.B_string.transform.rotation =
           stringproperties.pullparent.transform.rotation;
        //draw the projectile predictor
        startdrwingPP = true;
        Arrowproxyreference.SetActive(true);
    }
    public void releasestring()
    {
        ////setting back the position and rotation for the string to initial rotation
        ////and position of the string
        stringproperties.B_string.transform.parent =
        stringproperties.initialstringparent.transform;

        stringproperties.B_string.transform.localPosition =
            stringproperties.initialstringpos;
        //stringproperties.initialtransform.position;
        stringproperties.B_string.transform.rotation =
            Quaternion.Euler(0, 0, 0);
        //stringproperties.initialtransform.rotation;
        //setting back the transform of the string to the initial parent of the string
        startdrwingPP = false;
        Arrowproxyreference.SetActive(false);
    }
    void drawprojectilepredictor()
    {
        //render the aim line
            arrowprojectileline.widthMultiplier = .05f;
            arrowprojectileline.positionCount = (int)(5 / 0.1f);
            Vector3 startingposition = arrowhead.transform.position;

            List<Vector3> points = new List<Vector3>();

            Vector3 innitialvelocity = arrowhead.transform.forward * 52.0f;
            //Debug.Log(innitialvelocity);
            for (float t = 0; t < 5; t = t + 0.1f)
            {
                Vector3 newposition = Vector3.zero;
                newposition = startingposition + innitialvelocity * t;

                newposition.y = startingposition.y +
                    innitialvelocity.y * t + Physics.gravity.y * 0.5f * t * t;

                //newpos = Quaternion.Euler(-rot_pitch, 1, 0) * newpos;
                points.Add(newposition);
            }

            arrowprojectileline.positionCount = points.Count;
            arrowprojectileline.SetPositions(points.ToArray());
    }
    void resetprojectilerenderer()
    {
        arrowprojectileline.positionCount = 0;
    }
}
