using UnityEngine;

public class SpawnBlockOpponent : MonoBehaviour
{
    public GameObject[] Block_Opponent_NoFly;
    public GameObject[] Block_Opponent_Fly;
    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Add_Block_Opponent_NoFly), 1, 2);
        InvokeRepeating(nameof(Add_Block_Opponent_Fly), 1, 2);
    }

    void Add_Block_Opponent_NoFly() =>
        Instantiate(Block_Opponent_NoFly[Random.Range(0, Block_Opponent_NoFly.Length)],
            new Vector3(Random.Range(-4f, 4f), 0.5f, Player.position.z + 90), Quaternion.identity);

    void Add_Block_Opponent_Fly() =>
        Instantiate(Block_Opponent_Fly[Random.Range(0, Block_Opponent_NoFly.Length)],
            new Vector3(Random.Range(-4f, 4f), 3.5f, Player.position.z + 90), Quaternion.identity);
}
