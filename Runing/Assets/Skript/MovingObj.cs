using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObj : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Translate(new Vector3(0, 0, 1) * 0.15f * Time.deltaTime);
    }
}
