using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene : MonoBehaviour
{
    public void ResetScene()
    {
        SceneManager.LoadScene("Lab");
    }
}
