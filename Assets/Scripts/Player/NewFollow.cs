using UnityEngine;
using System.Collections;

public class NewFollow : MonoBehaviour
{

    public Transform front;//set target from inspector instead of looking in Update
    private float speed = 3f;
    private float distance = 1f;

        void Update()
    {
        //rotate to look at the player
        transform.LookAt(front.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation


        //move towards the player
        if (Vector3.Distance(transform.position, front.position) > distance)
        {//move if distance from target is greater than 1
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
     

    }

}