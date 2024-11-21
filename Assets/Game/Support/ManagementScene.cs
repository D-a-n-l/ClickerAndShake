using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagementScene : MonoBehaviour
{
    public void TransitionTo(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }
}