using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject player;
    public Transform currentSpawnPoint;
    public CameraHolder cameraScript;
    public CanvasDead canvas;
    public EnemyGenerator enemyGenerator;
    public UI ui;
    

    public string SceneName;
    public void NextScene()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void Respawn()
    {
        Instantiate(player, currentSpawnPoint.position, currentSpawnPoint.rotation);
        enemyGenerator.target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        ui.player = GameObject.FindGameObjectWithTag("Player").GetComponent<ProvaQuadrat>();
        cameraScript.target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        canvas.player = GameObject.FindGameObjectWithTag("Player").GetComponent<ProvaQuadrat>();
        canvas.StopAllCoroutines();
        canvas.deathScreen.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
