using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;
    public int zPos = 24;
    private bool creatingsection = false;
    public int secNum;

    public GameObject CombineInstance;

    void generateCoin(GameObject sec)
    {
        var coinObj = sec.transform.Find("SandFloor").gameObject as GameObject;
        var mrs = coinObj.transform.GetComponentsInChildren<MeshRenderer>(true);
        var bounds = mrs[0].bounds;
        var max = bounds.max;
        var min = bounds.min;

        ///var mrs = transform.GetComponentsInChildren<MeshRenderer>(true);

        for (int i = 0; i < 10; i++)
        {
            var coinX = Random.Range(min.x, max.x);//规定x轴方向上的范围
            var coinZ = Random.Range(min.z, max.z);//规定z轴方向上的范围

            print("generateCoin---");
            print(coinX);
            print(coinZ);
            //根据自己场景的实际情况去规定范围
            GameObject coin = Instantiate(CombineInstance, new Vector3(coinX, 0.2f, coinZ), Quaternion.identity);//随机生成物体（预制体，生成的位置，方向）。
            ///coin.transform.localRotation = Quaternion.Euler(-90, 0, 0);
            coin.transform.parent = sec.transform;
        }


    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (creatingsection == false && PlayerMove.Direction > 0 && PlayerMove.canMove == true)
        {
            creatingsection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        ///print("new create:");
        ///print(section[secNum]);
        //print(Quaternion.identity);
        secNum = Random.Range(0, 3);
        Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);

        generateCoin(section[secNum]);

        zPos += 24;
        yield return new WaitForSeconds(2);
        creatingsection = false;

    }
}
