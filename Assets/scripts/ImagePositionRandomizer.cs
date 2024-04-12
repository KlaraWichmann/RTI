using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using Random = UnityEngine.Random;

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

    private static List<Transform> ReduceList(List<Transform> list, int count)
        {
            if (count >= list.Count)
            {
                // No need to reduce if count is greater than or equal to list count
                return list;
            }

            // Shuffle the list randomly using UnityEngine.Random
            List<Transform> shuffledList = list.OrderBy(x => UnityEngine.Random.value).ToList();

            // Take the first count elements from the shuffled list
            return shuffledList.Take(count).ToList();
        }

    private void AssignPositions()
    {
        bool reduced = false;
        List<Transform> reducedImages = new List<Transform>();
        // if there are more images than positions randomly reduce the image list to the size of the positions
        if (images.Count > positions.Count)
        {
            reduced = true;
            reducedImages = ReduceList(images, positions.Count);
        }
        // Assign positions to the images
        for (int i = 0; i < images.Count; i++)
        {
            if (reduced)
            {
                reducedImages[i].position = positions[i];
            } else
            {
              reduced = false;
              images[i].position = positions[i];
            }
        }
    }
}
