﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderConnector : MonoBehaviour
{
    public Material m;
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination,m);
    }
}
