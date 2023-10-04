using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAnimPlayer : MonoBehaviour
{
    private Animator MyAnimator;
    public GameObject Player;

    BoxCollider boxCollider_Player;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider_Player = GetComponent<BoxCollider>();
        MyAnimator = GetComponent<Animator>();
        if (true)
            MyAnimator.Play("Run");
    }

    void FixedUpdate()
    {
        if (SpawnMoving.Bool_Up)
        {
            MyAnimator.Play("Run");
            boxCollider_Player.center = new Vector3(0.01f, 0.85f, 0.05f);
            boxCollider_Player.size = new Vector3(0.45f, 1.75f, 0.52f);
            //MyAnimator.Play("Jump");
            SpawnMoving.Bool_Up = false;
        }
        else if (SpawnMoving.Bool_Down)
        {
            MyAnimator.Play("Running_Crawl");
            boxCollider_Player.center = new Vector3(-0.045f, 0.37f, 0.05f);
            boxCollider_Player.size = new Vector3(0.38f, 0.68f, 0.52f);
            SpawnMoving.Bool_Down = false;
        }

    }
}
