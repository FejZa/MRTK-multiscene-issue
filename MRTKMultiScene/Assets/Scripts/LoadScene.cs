using Microsoft.MixedReality.Toolkit.Core.Utilities.Async;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private bool canLoad = false;

    private Scene? currentlyLoadedScene = null;

    private void Start()
    {
        canLoad = true;
        SceneManager.sceneLoaded += SceneManagerOnSceneLoaded;
    }

    private void Update()
    {
        if (canLoad)
        {
            if (Input.GetKeyUp(KeyCode.A))
            {
                LoadNextScene("A");
            }
            else if (Input.GetKeyUp(KeyCode.B))
            {
                LoadNextScene("B");
            }
        }
    }

    private async void LoadNextScene(string sceneName)
    {
        canLoad = false;

        if (currentlyLoadedScene.HasValue)
        {
            await SceneManager.UnloadSceneAsync(currentlyLoadedScene.Value.name);
        }

        await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }

    private void SceneManagerOnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        Debug.Log($"{scene.name} loaded successfully");
        currentlyLoadedScene = scene;
        canLoad = true;
    }
}
