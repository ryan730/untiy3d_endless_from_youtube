using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float leftRightSpeed = 4;

    public float moveSpeed = 5;

    public static int Direction = 0;

    static public bool canMove = false;

    void runAction()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * Direction, Space.World);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if( !canMove ){
            return;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            print("111:" + this.gameObject.transform.position.x);
            if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }

        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
            }

        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
            {
                ///transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
                Direction = 1;
            }

        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
            {
                /// transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * -1, Space.World);
                Direction = -1;
            }

        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            {
                Direction = 0;
            }

        }

        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            {
                Direction = 0;
            }

        }

        if (Direction != 0)
        {
            runAction();
        }
    }
}
