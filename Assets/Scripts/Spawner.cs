using UnityEngine;

public class Spawner : MonoBehaviour
{
    //어떤 부모 밑에서
    public Transform parent;
    //어떤 게임오브젝트를
    public GameObject item;
    //어느 위치들에다가
    public Transform[] spawnPositions;
    //어느 시점에 생성할 지
    public float startSpawnTime = 1f;
    public float spawnInterval = 1f;

    private float _spawnTime;
    void Start()
    {
        _spawnTime = Time.time + startSpawnTime;
    }

    void Update()
    {
        if(_spawnTime > Time.time)
            return;

        _spawnTime += spawnInterval;

        if(spawnPositions.Length == 0)
            return;

        //낳은 상태

        for (int i = 0; i < spawnPositions.Length; i++)
        {
        Instantiate(item, spawnPositions[i].position, spawnPositions[i].rotation, parent);
        }

    }
}
