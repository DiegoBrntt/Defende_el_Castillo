using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public Path[] Paths;

    [System.Serializable]
    public class Path
    {
        public string name;
        public Transform[] Posiciones;
    }


    public Transform[] GetRandomPath() {
        Debug.Log("Get Random Path");
        int random = Random.Range(0, Paths.Length);
        

        return Paths[random].Posiciones;
    }
}
