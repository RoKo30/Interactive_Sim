using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;  // Needed for Scene management

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine that waits for 5 seconds and then loads the scene
        StartCoroutine(LoadMainMenuAfterDelay());
    }

    // Coroutine that waits for 5 seconds and loads the MainMenu scene
    IEnumerator LoadMainMenuAfterDelay()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // Load the "MainMenu" scene
        SceneManager.LoadScene("MainMenu");
    }
}