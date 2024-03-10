using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoateObject : MonoBehaviour
{
    private float roateSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        roateSpeed = Random.Range(1.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        roateSpeed = Random.Range(1.0f, 5.0f);
        transform.Rotate(0, roateSpeed, 0, Space.World);
    }
}
