/*using System.Collections;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.SceneManagement;

public class AsynSceneLoader : MonoBehaviour
{
    [SerializeField] private Realtime realTime;
    [SerializeField] private string roomName; // The room name
    [SerializeField] private string sceneName; // Use scene name instead of index
    private bool isLoading;

    public void LoadScene()
    {
        if (isLoading) return; // Prevent multiple triggers
        isLoading = true;

        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        // Disconnect from the current session
        if (realTime != null)
        {
            realTime.Disconnect();
            realTime = null; // Nullify to prevent using the old reference
        }

        // Start loading the new scene asynchronously
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(sceneName);
        loadAsync.allowSceneActivation = false; // Prevent automatic activation until ready

        // Optionally, show loading UI here (e.g., a loading screen or progress bar)
        while (!loadAsync.isDone)
        {
            // You could update a loading progress bar here:
            // float progress = Mathf.Clamp01(loadAsync.progress / 0.9f);
            // LoadingProgressBar.fillAmount = progress;

            yield return null;
        }

        // After the scene is loaded, reconnect to Realtime
        realTime = FindObjectOfType<Realtime>();
        if (realTime != null)
        {
            realTime.Connect(roomName);
        }

        // Optionally, you could add a delay to ensure everything is set up before allowing the scene to activate
        yield return new WaitForSeconds(0.5f); // Adjust this based on your needs

        // Allow scene activation now that everything is loaded and ready
        loadAsync.allowSceneActivation = true;

        // Done loading, reset loading state
        isLoading = false;
    }
}*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.SceneManagement;

public class AsynSceneLoader : MonoBehaviour
{
    [SerializeField] private Realtime realTime;
    [SerializeField] private string roomName;
    [SerializeField] private int sceneIndex;

    private bool isLoading;
    public void LoadScene()
    {
        if (isLoading) return;
        isLoading = true;

        StartCoroutine(LoadSceneAsync());

    }

    IEnumerator LoadSceneAsync()
    {
        realTime.Disconnect();
        realTime = null;

        var loadAsync = SceneManager.LoadSceneAsync(sceneIndex);

        while (!loadAsync.isDone) yield return null;

        realTime = FindObjectOfType<Realtime>();
        realTime.Connect(roomName);

        isLoading = false;
    }

}
