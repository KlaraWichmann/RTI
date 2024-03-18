using UnityEngine;
using System.IO;

public class ImagePositionLogger : MonoBehaviour
{
    public string csvFilePath = "position_data.csv"; // File path to save the CSV file

    private void LogPosition(Vector3 position, string imageName)
    {
        // Log the position and time of the image
        Debug.Log($"Time: {Time.time:F2} | Position of {imageName}: {position}");

        // Save the position and time to the CSV file
        SaveToCSV(Time.time, position, imageName);
    }

    public void LogImagePosition(Transform imageTransform, string imageName)
    {
        LogPosition(imageTransform.position, imageName);
    }

    private void SaveToCSV(float time, Vector3 position, string imageName)
    {
        // Check if the file exists, if not create a new file with header
        if (!File.Exists(csvFilePath))
        {
            using (StreamWriter writer = new StreamWriter(csvFilePath))
            {
                writer.WriteLine("Time,ImageName,XPosition,YPosition");
            }
        }

        // Append the position and time data to the CSV file
        using (StreamWriter writer = new StreamWriter(csvFilePath, true))
        {
            writer.WriteLine($"{time:F2},{imageName},{position.x},{position.y}");
        }
    }
}
