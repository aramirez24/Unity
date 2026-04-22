using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemy;
    public float tempsAparicio = 5;
    float ultimaAparicio = 0;
    public float distanciaX = 9;
    public Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        transform.position = new Vector3(target.position.x, target.position.y + 20);

        ultimaAparicio += Time.deltaTime;
        if (ultimaAparicio >= tempsAparicio)
        {
            InstanciarEnemic();
            ultimaAparicio = 0;
        }
    }

    void InstanciarEnemic()
    {
        GameObject e = Instantiate(enemy);
        e.transform.position = new Vector3(transform.position.x + Random.Range(-distanciaX, distanciaX), transform.position.y, -1);
    }
}
