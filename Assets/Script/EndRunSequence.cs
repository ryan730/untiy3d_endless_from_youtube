using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        yield return new WaitForSeconds(3);
        liveCoins.SetActive(false);
        liveDis.SetActive(false);
        endscreen.SetActive(true);
        yield return new WaitForSeconds(3);
        fade0ut.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
