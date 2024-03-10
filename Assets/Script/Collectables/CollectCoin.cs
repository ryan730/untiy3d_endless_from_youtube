using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public AudioSource coinFx;
    void OnTriggerEnter(Collider other)
    {
        //coinFx.Stop();
        coinFx.Play();
        CollectableControl.coinCount += 1;
        ///this.gameObject.SetActive(false);
        if (transform.parent.gameObject != null)
        {
           Destroy(transform.parent.gameObject);
        }
        
    }

}
