using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothspeed = 0.125f;
    public Vector3 offset;

    Camera camera;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        //transform.LookAt(player);

        /*Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothspeed * Time.deltaTime);
        transform.position = smoothedPosition;*/

        transform.position = player.position + offset;
        
        //BackgroundColorChange();




    }

    

    

    void BackgroundColorChange()
    {
        if (player.tag == "Red")
        {
            camera.backgroundColor = Color.red;
        }
        else if (player.tag == "Blue")
        {
            camera.backgroundColor = Color.blue;

        }
        else if (player.tag == "Yellow")
        {
            camera.backgroundColor = Color.yellow;
        }

    }
}
