using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //reference to the bullet prefab we created in the
    //Unity Editor and will drag into the inspector to give
    //the variable a value
    public GameObject bulletPrefab;

    //reference to the launch position object we created on the 
    //Gun. This will be the starting position where bullets are fired
    public Transform launchPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //every frame check to see if mouse button is pressed down
        //this condition will lead to the rapid firing of the bullets
        if (Input.GetMouseButtonDown(0))
        {
            //check to see if you are not already invoking the function "fireBullet"
            if (!IsInvoking("fireBullet"))
            {
                //if not, then call the function "fireBullet"
                //InvokeRepeating requires 3 parameters: 
                //a function to execute, at a start time, and how often to repeat
                InvokeRepeating("fireBullet", 0f, 0.1f);
            }
        }

        //the condition to end the rapid firing, a mouse up(release mouse button)
        if (Input.GetMouseButtonUp(0))
        {
            //stop the repetitive function call to fireBullet function
            CancelInvoke("fireBullet");
        }
    }

    void fireBullet()
    {
        //Instantiate is a built in Unity method that creates a GameObject instance from a prefab
        //Instantiate returns a type Object, so we must cast it to type GameObject
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;

        //the newly created bullet must be placed at the launch position(barrel of gun)
        bullet.transform.position = launchPosition.position;

        //get the RigidBody of the newly created bullet and set its velocity to the forward facing direction 
        //of the parent of the gun, which is the space marine. 
        //Bullets fire in same direction as the space marine faces
        bullet.GetComponent<Rigidbody>().velocity = transform.parent.forward * 100;
    }
}
