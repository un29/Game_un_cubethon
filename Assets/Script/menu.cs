using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour{
   
    public void StartGame(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
