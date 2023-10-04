using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public GameObject[] Prefab_Obj;

    public static bool RightBorder = true;
    public static bool LeftBorder = true;
    public GameObject ChackPoint;
    GameObject Opponent;

    public float Left_Side;
    public float Right_Side;
    public int Distation;
    float _ZR;
    float _ZL;
    public float proba;
    public static int Destroy_obj = 100;

    void Start()
    {
        StartCoroutine(ChackPoint_Obj(-5));

        for (int i = 0; i < Distation; i++)
        {
            StartCoroutine(AddObj_Right(i, Right_Side));
        }

        for (int i = 0; i < Distation; i++)
        {
            StartCoroutine(AddObj_Left(i, Left_Side));
        }
    }

    void FixedUpdate()
    {
        if (transform.position.x > 2)
        {
            RightBorder = false;
            LeftBorder = true;
        }
        else if (transform.position.x < -2)
        {
            RightBorder = true;
            LeftBorder = false;
        }
        else
        {
            RightBorder = true;
            LeftBorder = true;
        }


        if (Opponent.transform.position.z + 70 <= transform.position.z)
        {
            for (int i = 0; i < Distation; i++)
            {
                _ZR = i + Distation - 6.7f;
                StartCoroutine(AddObj_Right(_ZR, Right_Side));
            }

            for (int i = 0; i < Distation; i++)
            {
                _ZL = i + Distation - 6.7f;
                StartCoroutine(AddObj_Left(_ZL, Left_Side));
            }
            StartCoroutine(ChackPoint_Obj(proba));
        }
    }

    IEnumerator AddObj_Right(float Axis_Z, float Side)
    {
        GameObject Object_Right = Instantiate(Prefab_Obj[Random.Range(0, Prefab_Obj.Length)],
            new Vector3(0f + Side, 0f, transform.position.z + Axis_Z * 10f),
            Quaternion.identity);
        //Enumy1.transform.Rotate(0, 180, 0);
        Destroy(Object_Right, Destroy_obj);
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator AddObj_Left(float Axis_Z, float Side)
    {
        GameObject Object_Left = Instantiate(Prefab_Obj[Random.Range(0, Prefab_Obj.Length)],
                new Vector3(0f + Side, 0f, transform.position.z + Axis_Z * 10f),
                Quaternion.identity);
        Destroy(Object_Left, Destroy_obj);
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator ChackPoint_Obj(float Axsis)
    {
        Opponent = Instantiate(ChackPoint,
            new Vector3(0f, transform.position.y, transform.position.z + Axsis),
            Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Destroy(Opponent, Destroy_obj);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("block"))
            SceneManager.LoadScene("Play_Scene");
        Debug.Log("Касание");
    }
}