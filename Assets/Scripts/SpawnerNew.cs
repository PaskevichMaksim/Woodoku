using UnityEngine;

public class SpawnerNew : MonoBehaviour
{
    private const int SHAPES_COUNT = 3;
    [SerializeField] 
    private GameObject[] _shapes;

    [SerializeField]
    private Transform[] _spawnPositions;

    private void Start()
    {
        SpawnShapes();
    }
    private void Update()
    {
        if (Mouse.QnttDestroy == 3)
        {
            SpawnShapes();
            //обнуляем кол-во удаленных фигур
            Mouse.QnttDestroy = 0;
        }
    }

    private void SpawnShapes()
    {
        for (int i = 0; i < SHAPES_COUNT; i++)
        {
            SpawnShape(i);
        }
        PlayGameManager.CheckGameOver();
    }

    private void SpawnShape(int index)
    {
        var spawnedTile = Instantiate(_shapes[Random.Range(0, _shapes.Length - 1)], _spawnPositions[index], false);
        spawnedTile.name = $"Shape_{index.ToString()}";
    }
}