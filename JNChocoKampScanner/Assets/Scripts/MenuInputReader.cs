using UnityEngine;

public class MenuInputReader : MonoBehaviour
{
    [SerializeField]
    private GameObject menuObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuObject.SetActive(true);
        }
    }
}
