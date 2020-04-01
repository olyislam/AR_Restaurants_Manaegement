using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageData : MonoBehaviour
{
    public Texture2D burger;
   

    private void Start()
    {
        ImageReader img = new ImageReader(burger);

        string Json = JsonUtility.ToJson(img);
        Debug.Log(Json);

        ImageReader retriveImage = JsonUtility.FromJson<ImageReader>(Json);

        GetComponent<Renderer>().material.mainTexture = retriveImage.Load();
    }


}



