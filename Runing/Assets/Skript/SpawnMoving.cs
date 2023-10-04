using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnMoving : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Transform Player;
    public static bool Bool_Up;
    public static bool Bool_Down;

    void Start()
    {
        Bool_Up = false;
        Bool_Down = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!Bool_Up || !Bool_Down)
        {
            if ((Mathf.Abs(eventData.delta.x)) > (Mathf.Abs(eventData.delta.y)))
            {
                if (eventData.delta.x > 0)
                {
                    if (PlayerMove.RightBorder)
                        Player.position = new Vector3(Player.position.x + 5f, Player.position.y, Player.position.z);  // Игрок передвикаеться на 1 ед в сторону
                }
                else
                {
                    if (PlayerMove.LeftBorder)
                        Player.position = new Vector3(Player.position.x - 5f, Player.position.y, Player.position.z);
                }
            }
            else
            {
                if (eventData.delta.y > 0)
                {
                    if (PlayerMove.RightBorder)
                        Player.position = new Vector3(Player.position.x, Player.position.y, Player.position.z + 5f);  // Игрок передвикаеться на 1 ед в сторону
                }
                else
                {
                    if (PlayerMove.LeftBorder)
                        Player.position = new Vector3(Player.position.x, Player.position.y, Player.position.z - 5f);
                }
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
    }
}