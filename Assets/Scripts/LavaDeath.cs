using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaDeath : MonoBehaviour
{
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Lava"))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
