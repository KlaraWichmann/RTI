using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class ImagePositionLogger : MonoBehaviour
{
    private string csvFilePath; // File path to save the CSV file

    private void Start()
    {
        // Generate the CSV file path based on the current scene's name
        string sceneName = SceneManager.GetActiveScene().name;
        csvFilePath = $"{sceneName}_position_data.csv";
    }

    private void LogPosition(float dragStartTime, float dragEndTime, float dragDuration, Vector3 position, string imageName)
    {
        // Log the position and duration of the drag
        Debug.Log($"Drag Start Time: {dragStartTime} | Drag End Time: {dragEndTime}, Drag Duration: {dragDuration:F2} | Position of {imageName}: {position}");

        // Save the position and duration to the CSV file
        SaveToCSV(dragStartTime, dragEndTime, dragDuration, position, imageName);
    }

    public void LogImagePosition(Transform imageTransform, string imageName, float dragDuration, float dragStartTime, float dragEndTime)
    {
        LogPosition(dragStartTime, dragEndTime, dragDuration, imageTransform.position, imageName);
    }

    private void SaveToCSV(float dragStartTime, float dragEndTime, float dragDuration, Vector3 position, string imageName)
    {
        // Append the position and duration data to the CSV file
        using (StreamWriter writer = new StreamWriter(csvFilePath, true))
        {
            writer.WriteLine($"{dragStartTime},{dragEndTime},{dragDuration:F2},{imageName},{position.x},{position.y}");
        }
    }
}
