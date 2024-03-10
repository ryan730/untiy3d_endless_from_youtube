using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRunSequence : MonoBehaviour
{
    public GameObject liveCoins;
    public GameObject liveDis;
    public GameObject endscreen;
    public GameObject fade0ut;
    void Start()
    {
        StartCoroutine(EndRun());
    }

    IEnumerator EndRun()
    {
        yield return new WaitForSeconds(5);
        liveCoins.SetActive(false);
        liveDis.SetActive(false);
        endscreen.SetActive(true);
        yield return new WaitForSeconds(5);
        fade0ut.SetActive(true);

    }
}
