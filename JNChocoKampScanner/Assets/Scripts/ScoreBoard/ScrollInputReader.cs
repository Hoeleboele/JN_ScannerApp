using UnityEngine;

public class ScrollInputReader : MonoBehaviour
{
    private const float speed = 2000f;
    [SerializeField]
    private Camera cam;

    void Update()
    {
        var scrollAxis = Input.GetAxis("Mouse ScrollWheel");

        if (scrollAxis > 0)
        {
            cam.transform.position += new Vector3(0, 0.1f * speed, 0);
        }
        else if (scrollAxis < 0)
        {
            cam.transform.position -= new Vector3(0, 0.1f * speed, 0);
        }
    }
}
