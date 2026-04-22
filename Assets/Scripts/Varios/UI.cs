using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public ProvaQuadrat player;
    public TextMeshProUGUI text;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ProvaQuadrat>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Vides: " + player.health;
    }
}
