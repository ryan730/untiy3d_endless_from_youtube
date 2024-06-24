using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public float leftRightSpeed = 4;

	public float moveSpeed = 5;

	public static int Direction = 0;

	static public bool canMove = false;

	public bool isJumping = false;
	public bool comingDown = false;

	public GameObject playerObject;

	public float jumpForce = 3f;
	public LayerMask groundLayerMask; // 包含地面层的层掩码
	private Rigidbody rb;

	void runAction()
	{
		transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * Direction, Space.World);
	}

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{

		if (canMove)
		{
			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			{
				////print("111:" + this.gameObject.transform.position.x);
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

			if (Input.GetKey(KeyCode.Space))
			{
				if (isJumping == false)
				{
					isJumping = true;
					playerObject.GetComponent<Animator>().Play("Jump1");
					StartCoroutine(JumpSequence());
				   
				}
				 //StartJump();//其他跳跃方法
			}
		}

		if (isJumping == true)
		{
			if (comingDown == false)
			{
				transform.Translate(Vector3.up * Time.deltaTime * 1, Space.World);
			}
			if (comingDown == true)
			{
				transform.Translate(Vector3.up * Time.deltaTime * -1, Space.World);
			}

		}else{
		   
		}
		 if (Direction != 0)
		{
			runAction();
		}
	}

	IEnumerator JumpSequence()
	{
		yield return new WaitForSeconds(0.45f);
		comingDown = true;
		yield return new WaitForSeconds(0.45f);
		isJumping = false;
		comingDown = false;
		//if(Direction != 0)
		if(canMove)
		{
			playerObject.GetComponent<Animator>().Play("Fast Run");
		}

	}

	// void StartJump()
	// {
	// 	if (IsGrounded())
	// 	{
	// 		playerObject.GetComponent<Animator>().Play("Jump1");
	// 		rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // 使用冲击模式添加向上的力
			
	// 	}else {
	// 		playerObject.GetComponent<Animator>().Play("Fast Run");
	// 	}

	// }

	// bool IsGrounded()
	// {
	// 	float raycastDistance = 0.1f;
	// 	Vector3 origin = transform.position + Vector3.down * 0.1f; // 调整射线起点以避开自身物体边缘
	// 	print("==============");
	// 	print(origin);
	// 	RaycastHit hit;
	// 	return Physics.Raycast(origin, Vector3.down, out hit, raycastDistance, groundLayerMask) && hit.collider.gameObject != gameObject;
	// }
}
