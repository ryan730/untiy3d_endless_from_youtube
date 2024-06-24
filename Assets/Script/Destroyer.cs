using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Destroyer : MonoBehaviour
{
	public string parentName;
	
	void Update()
	{
		
	}
	
	void Start()
	{
	    parentName = transform.name;
		StartCoroutine(DestroyClone());
	}

	
	IEnumerator DestroyClone()
	{
		yield return new WaitForSeconds(10);
		print("DestroyClone-Destroy");
		print(parentName);
		
		if(parentName == "Section0(Clone)" || parentName == "Section1(Clone)" || parentName == "Section2(Clone)")
		{
			
			Destroy(gameObject);
		}
	}
}