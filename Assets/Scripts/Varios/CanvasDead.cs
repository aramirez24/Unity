using System.Collections;
using UnityEngine;

public class CanvasDead : MonoBehaviour
{
    [HideInInspector]public ProvaQuadrat player;
    public GameObject deathScreen;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ProvaQuadrat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
        {
            StartCoroutine(DeathScreen());          
        }

    }

    IEnumerator DeathScreen()
    {
        yield return new WaitForSeconds(1);
        deathScreen.SetActive(true);
    }
}
