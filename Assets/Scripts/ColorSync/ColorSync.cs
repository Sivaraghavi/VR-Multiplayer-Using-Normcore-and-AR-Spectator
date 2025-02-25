/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class ColorSync : RealtimeComponent<ColorSyncModel>
{
    [SerializeField] private MeshRenderer[] meshRenderers;
    [SerializeField] private Color color;
    private Color lastColor;

    private void Update()
    {
        if(color!= lastColor)
        {
            model.color = color;
            lastColor = color;
        }
    }

    private void UpdateMeshRendererColor()
    {
        foreach (var renderer in meshRenderers)
        {
            foreach(var mat in renderer.materials)
            {
                mat.color = model.color;
            }
        }
    }
    protected override void OnRealtimeModelReplaced(ColorSyncModel previousModel, ColorSyncModel currentModel)
    {
        if(previousModel != null) { previousModel.colorDidChange -= DidColorChange; }

        if(currentModel.isFreshModel) { currentModel.color = meshRenderers[0].material.color; }

        UpdateMeshRendererColor();
        currentModel.colorDidChange += DidColorChange;
    }
    private void DidColorChange(ColorSyncModel model, Color value)
    {
        UpdateMeshRendererColor();
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class ColorSync : RealtimeComponent<ColorSyncModel>
{
    [SerializeField] private MeshRenderer[] meshRenderers;
    [SerializeField] private Color color;
    private Color lastColor;


    private void Start()
    {
        var randomColor = new Color(Random.value, Random.value, Random.value);
        model.color = randomColor;
    }
    private void Update()
    {
        if (color != lastColor)
        {
            if (model != null) // Check if model is not null
            {
                model.color = color;
                lastColor = color;
            }
        }
    }

    private void UpdateMeshRendererColor()
    {
        if (meshRenderers != null) // Check if meshRenderers is not null
        {
            foreach (var renderer in meshRenderers)
            {
                if (renderer != null && renderer.materials != null) // Check if renderer and materials are not null
                {
                    foreach (var mat in renderer.materials)
                    {
                        mat.color = model.color; // This line should also check if model is not null
                    }
                }
            }
        }
    }

    protected override void OnRealtimeModelReplaced(ColorSyncModel previousModel, ColorSyncModel currentModel)
    {
        if (previousModel != null) // Check if previousModel is not null
        {
            previousModel.colorDidChange -= DidColorChange;
        }

        if (currentModel != null) // Check if currentModel is not null
        {
            if (currentModel.isFreshModel && meshRenderers.Length > 0 && meshRenderers[0] != null && meshRenderers[0].material != null)
            {
                currentModel.color = meshRenderers[0].material.color; // Initialize the color
            }

            UpdateMeshRendererColor();
            currentModel.colorDidChange += DidColorChange;
        }
    }

    private void DidColorChange(ColorSyncModel model, Color value)
    {
        UpdateMeshRendererColor();
    }

    public void SetColor(Color newColor)
    {
        color = newColor;
    }

}
