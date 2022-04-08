using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float _timer = 3f;

    void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            GetComponent<Collider2D>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BaseCharacter>())
        {
            collision.GetComponent<BaseCharacter>().SetDirty();
            Destroy(gameObject);
        }
    }
}
