using UnityEngine;
using TMPro;
using VRKeyboard.Utils;

public class PlayerNameInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private KeyboardManager1 keyboardManager;

    private void Start()
    {
        // Ensure you are assigning the TMP_InputField directly
        keyboardManager.inputText = inputField; // This should now correctly reference the TMP_InputField
    }

    public void SavePlayerName()
    {
        PlayerPrefs.SetString("PlayerName", inputField.text);
    }

    public void LoadNextScene(string sceneName)
    {
        SavePlayerName();
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
