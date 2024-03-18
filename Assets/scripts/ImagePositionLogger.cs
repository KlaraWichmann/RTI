using UnityEngine;
using System.IO;

public class ImagePositionLogger : MonoBehaviour
{
    public string csvFilePath = "position_data.csv"; // File path to save the CSV file

    private void LogPosition(float dragDuration, Vector3 position, string imageName)
    {
        // Log the position and duration of the drag
        Debug.Log($"Drag Duration: {dragDuration:F2} | Position of {imageName}: {position}");

        // Save the position and duration to the CSV file
        SaveToCSV(dragDuration, position, imageName);
    }

    public void LogImagePosition(Transform imageTransform, string imageName, float dragDuration)
    {
        LogPosition(dragDuration, imageTransform.position, imageName);
    }

    private void SaveToCSV(float dragDuration, Vector3 position, string imageName)
    {
        // Check if the file exists, if not create a new file with header
        if (!File.Exists(csvFilePath))
        {
            using (StreamWriter writer = new StreamWriter(csvFilePath))
            {
                writer.WriteLine("DragDuration,ImageName,XPosition,YPosition");
            }
        }

        // Append the position and duration data to the CSV file
        using (StreamWriter writer = new StreamWriter(csvFilePath, true))
        {
            writer.WriteLine($"{dragDuration:F2},{imageName},{position.x},{position.y}");
        }
    }
}
