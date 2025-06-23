using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {

            Scene currentScene = SceneManager.GetActiveScene();

            if (currentScene.name == "bienvenida") {

                SceneManager.LoadScene("prejuego");
            } 
            else if (currentScene.name == "prejuego") {

                SceneManager.LoadScene("instrucciones");
            }
            else if (currentScene.name == "instrucciones") {

                SceneManager.LoadScene("SampleScene");
            }

        }
    }
}
