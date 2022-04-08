using UnityEngine;

public class SpawnStone : MonoBehaviour
{
    [SerializeField] private GameObject _stone;
    [SerializeField] private Transform _beginPosition;
    [SerializeField] private GameObject _parent;

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                GameObject newStone = Instantiate(_stone, new Vector3(_beginPosition.position.x + j * 2.19f - 0.222f * i, _beginPosition.position.y - 1.956f * i, _beginPosition.position.z), Quaternion.identity);
                newStone.transform.parent = _parent.transform;
            }
        }
    }
}
