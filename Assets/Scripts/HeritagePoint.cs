using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class HeritagePoint
{
    public string name;
    public float latitude;
    public float longitude;
    public string history;
    public string[] imageUrls;
    public string[] videoUrls;

    public HeritagePoint(string name, float latitude, float longitude, string history, string[] imageUrls, string[] videoUrls)
    {
        this.name = name;
        this.latitude = latitude;
        this.longitude = longitude;
        this.history = history;
        this.imageUrls = imageUrls;
        this.videoUrls = videoUrls;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public float Latitude
    {
        get => latitude;
        set => latitude = value;
    }

    public float Longitude
    {
        get => longitude;
        set => longitude = value;
    }

    public string History
    {
        get => history;
        set => history = value;
    }

    public string[] ImageUrls
    {
        get => imageUrls;
        set => imageUrls = value;
    }

    public string[] VideoUrls
    {
        get => videoUrls;
        set => videoUrls = value;
    }
}
