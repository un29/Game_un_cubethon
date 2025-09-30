
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager1 : MonoBehaviour{

    bool gameHasEnded = false;          //避免多次呼叫 EndGame()

    public float restartDelay = 1f;

    public GameObject levelcompleteUI;

    public void Completelevel(){
        
        levelcompleteUI.SetActive(true);
    }

    //延遲levelcomplete
    public void DelayLoad(){

        FindObjectOfType<levelcomplete>().LoadNextLevel();
    }

    public void EndGame(){

        if(gameHasEnded == false){

            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart" , restartDelay);
        }
    }

    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
