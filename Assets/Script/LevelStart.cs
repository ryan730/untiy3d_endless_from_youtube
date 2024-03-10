using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    public List<GameObject> CountDowns;
    public AudioSource readyFX;
    public AudioSource goFX;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountSequence());
    }

    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(0.1f);
        int i=0;
        foreach (GameObject countDown in CountDowns)
        {
            countDown.SetActive(true);
            if(i==0){
                goFX.Play();
            }else{
                readyFX.Play();
            }
            if(i==CountDowns.Count-1){
                print("ready===>>>");
                PlayerMove.canMove = true;
            }
            yield return new WaitForSeconds(1);
            i++;
        }

    }
}
