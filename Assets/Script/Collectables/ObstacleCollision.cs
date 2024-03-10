using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;
    public AudioSource crashThud;

    public GameObject mainCam;
    public GameObject levelControl;

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<PlayerMove>().enabled = false;
        charModel.GetComponent<Animator>().Play("Stumble Backwards");
        crashThud.Play();
        PlayerMove.Direction = 0;
        PlayerMove.canMove = false;
        mainCam.GetComponent<Animator>().enabled  = true;
        levelControl.GetComponent<LevelDistance>().enabled  = false;
        levelControl.GetComponent<EndRunSequence>().enabled  = true;
    }

}
