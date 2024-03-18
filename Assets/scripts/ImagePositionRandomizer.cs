using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ImagePositionRandomizer : MonoBehaviour
{
    public List<Vector3> positions; // List of positions
    public List<Transform> images; // List of images

    private void Start()
    {
        RandomizePositions(); // Randomize the positions
        AssignPositions(); // Assign positions to the images
    }

    private void RandomizePositions()
    {
        // Shuffle the list of positions using Fisher-Yates shuffle algorithm
        int n = positions.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            Vector3 value = positions[k];
            positions[k] = positions[n];
            positions[n] = value;
        }
    }

    private void AssignPositions()
    {
        // Assign positions to the images
        for (int i = 0; i < images.Count; i++)
        {
            if (i < positions.Count)
            {
                images[i].position = positions[i];
            }
            else
            {
                Debug.LogWarning("Not enough positions for all images.");
                break;
            }
        }
    }
}
