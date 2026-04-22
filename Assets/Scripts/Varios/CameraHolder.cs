using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    public Camera Camera;
    public Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        Camera.transform.position = new Vector3(target.position.x, target.position.y, -10);
    }
}
