using UnityEngine;
using TMPro;

public class InAppLogger : MonoBehaviour
{
    public TMP_Text logText;
    private string buffer = "";

    void OnEnable()
    {
        Application.logMessageReceived += OnLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= OnLog;
    }

    void OnLog(string message, string stackTrace, LogType type)
    {
        buffer += message + "\n";

        if (buffer.Length > 5000)
            buffer = buffer.Substring(buffer.Length - 5000);

        if (logText != null)
            logText.text = buffer;
    }
}