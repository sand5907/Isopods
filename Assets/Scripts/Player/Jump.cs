using System.Collections.Generic;
using UnityEngine;


public class Jump : MonoBehaviour
{
    
    //This is the first isopod
    public GameObject first;

    //Position in relation to first isopod
    public int position;

    //Time elapsed before delay
    private float elapsedTime = 0; 

    private float jumpLag = .25f;

    //cycles through array of positions
    private int cycle = 0;
    //array containing previous positions to create movment delay
    private bool[] jumpedArray = null;

    // Update is called once per frame
    void Update()
    {
        //checks if the elapsed time is less delay for each isopod and greater than 0
        if (elapsedTime < jumpLag*position && elapsedTime >= 0)
        {
            //sets elapsed time to the sum time of each frame 
            elapsedTime += Time.deltaTime;
            //adds position to linked list
            cycle++;
        }
        //if the elapsed time is greater than the delay
        else if (elapsedTime > 0)
        {
            //sets the array to the size of the linked list
            jumpedArray = new bool[cycle];

            elapsedTime = -1;
            cycle = 0;
            jumpedArray[cycle] = false;
        }
        //after the array has been created
        else
        {
            if (jumpedArray[cycle])
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, first.GetComponent<Move>().jumpForce));

            jumpedArray[cycle] = first.GetComponent<Move>().jumped;

            if (cycle == jumpedArray.Length - 1)
                cycle = 0;
            else
                cycle++;

            /*if (!first.GetComponent<Move>().grounded)
            {
                tempVector = transform.position;
                tempVector.y = cycleDistanceArray[cycle].y;
                //sets this isopod's position to a previous position in array
                transform.position = tempVector;
                //sets the current adjusted position to the current place in array    
            }
                cycleDistanceArray[cycle] = positionAdjust;
            
                //resets the array counter if it is greater than array length
                if (cycle == cycleDistanceArray.Length - 1)
                    cycle = 0;
                else
                    cycle++;
            */
        }
        





        }


}
