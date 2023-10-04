using UnityEngine;
    
public class Earth_Move : MonoBehaviour
{
    public float Offset;
    public float Offset_Speed;
    Renderer Rend;
    public float Timer = 15f;

    void Start() => Rend = GetComponent<Renderer>();

    void FixedUpdate()
    {
        if (Offset < 350.0001f)
            Offset -= Offset_Speed;
        else
            Offset = 350;

        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            Block_Opponent_Move.speed += 0.05f;
            Offset_Speed += 0.001f;
            if (PlayerMove.Destroy_obj > 15)
                PlayerMove.Destroy_obj -= 5;
            else
                PlayerMove.Destroy_obj = 15;
            Timer = 15f;
        }

        Rend.material.mainTextureOffset = new Vector2(0, Offset);
    }
}
