
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelcomplete : MonoBehaviour{
 
    public void LoadNextLevel(){

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
