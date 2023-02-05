using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{

    public LineRenderer linerenderer;
    public float GrowthDistance = 1.0f;
    public float GrowthRate = 1.0f;
    private float CoolDown = 0.0f;
    float Horizontal, verticaleInput;

    public GameObject myCollisionHead;

    public List<Vector3> _POSList = new List<Vector3>();

    public float Distance_X = 0.0f, Distance_Y = 0.0f;

    
    public Vector3 LastValues;

    // Start is called before the first frame update
    void Start()
    {
        LastValues.y = GrowthDistance;
        if (linerenderer == null) { GetComponent<LineRenderer>(); }

        _POSList.Add(linerenderer.GetPosition(0));
    }

    // Update is called once per frame
    void Update()
    {
        verticaleInput = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");

        CoolDown += Time.deltaTime;

        if (CoolDown >= GrowthRate)
        {
            CoolDown = 0;
            GrowVine();
        }




  // Set Values based of input

        // To do change arrow UI based off input. 
        if (verticaleInput > 0.0f) {


            /**
             *  An attempt to do some QA controls for user, but decided to put that work on hold.
             * 
            if(LastValues.x.Equals( 0.0f ) && LastValues.y.Equals(1.0f))
            {
               float randomValue =  Random.Range(0.0f, 20.0f)  % 2;

               if(randomValue == 1)
                {

                    Distance_X = 1;
                }
                else
                {
                    Distance_X = -1;
                }

            }
            */

            Distance_Y = GrowthDistance; 
        }

        if (verticaleInput < 0.0f) { Distance_Y = 0.0f - GrowthDistance; }

        if (verticaleInput == 0.0f) { Distance_Y = 0.0f; }

        if (Horizontal > 0.0f) { Distance_X = GrowthDistance; }

        if (Horizontal < 0.0f) { Distance_X = 0.0f - GrowthDistance; }

        if (Horizontal == 0.0f) { Distance_X = 0.0f; }

        
        if(Horizontal == 0.0f && verticaleInput == 0.0f)
        {
            Distance_X = LastValues.x;
            Distance_Y = LastValues.y;
        }

      

    }


    public void GrowVine()
    {

        ///add 
        Vector3 oldPOS = linerenderer.GetPosition(linerenderer.positionCount - 1);
        Vector3 myNewPOS = oldPOS;


        myNewPOS.x += Distance_X;
        myNewPOS.y += Distance_Y;

        // store values 
        LastValues.x = Distance_X;
        LastValues.y = Distance_Y;

       
        if (_POSList.Contains(myNewPOS))
        {

            Debug.Log("Debug End Game");
            // Put end game trigger here!
            
        }
        linerenderer.positionCount++;

        linerenderer.SetPosition(linerenderer.positionCount - 1, myNewPOS);

        _POSList.Add(myNewPOS);

        // Add extra midpoint to list if going in diagnol direction
        if(Distance_X != 0 && Distance_Y != 0)
        {
            // add new point for daiganols
            Vector3 Difference = new Vector3( oldPOS.x - myNewPOS.x, oldPOS.y - myNewPOS.y, oldPOS.z - myNewPOS.z);

           // Debug.Log("Caluclating Differences");
            _POSList.Add(Difference);
        }


        // move the collision head
        if(myCollisionHead != null)
        {

            myNewPOS = transform.TransformPoint(myNewPOS);

            myCollisionHead.transform.position = myNewPOS;

        }

    }
}