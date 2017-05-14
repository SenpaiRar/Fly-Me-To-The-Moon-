using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChunkGen : MonoBehaviour {

    class Chunk
    {
        public Chunk(GameObject Parent, float STARTh, float ENDh, float w)
        {
            ParentObject = Parent;
            StartingHeight = STARTh;
            EndingHeight = ENDh;
            Width = w;
        }

        float StartingHeight;
        float EndingHeight;
        float Width;
        public GameObject ParentObject;
        List<GameObject> ObjectsWithin; 

        public float GetHeight()
        {
            return (StartingHeight);
        }
        public float GetWidth()
        {
            return (Width);
        }
        public void AddToObject (GameObject x)
        {
            ObjectsWithin.Add(x);
        }
        public void DestroyEachObject()
        {
            foreach (var item in ObjectsWithin)
            {
                Destroy(item);
                ObjectsWithin.Remove(item);
            }
        }
        public void PopulateChunk (GameObject Population, int density)
        {
            for (int i = 0; i < density; i++)
            {
                Instantiate(Population, new Vector3(Random.Range(0,Width),Random.Range(StartingHeight,EndingHeight),0), Quaternion.identity);
            }
        }
    }

    List<Chunk> ChunkList = new List<Chunk>();
    float ChunkHeight;
    float ChunkWidth;
    float CurrentStartHeight;
    float CurrentEndHeight;
    GameObject testGameObject;

    void Awake()
    {
        CurrentStartHeight = 0;
        CurrentEndHeight = ChunkHeight;
    }
    
    void CreateChunk()
    {
        GameObject temp = new GameObject();
        temp.name = "Chunk #" + ChunkList.Count;
        Chunk thisChunk = new Chunk(temp, CurrentStartHeight, CurrentEndHeight, ChunkWidth);
        ChunkList.Add(thisChunk);

        CurrentStartHeight += ChunkHeight;
        CurrentEndHeight += ChunkHeight;
    }
    
}
