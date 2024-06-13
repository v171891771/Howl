using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

[System.Serializable]
[PostProcess(typeof(CustomEdgeDetectionRenderer), PostProcessEvent.AfterStack, "Custom/EdgeDetection")]
public sealed class CustomEdgeDetection : PostProcessEffectSettings
{
    [Tooltip("Edge color")]
    public ColorParameter edgeColor = new ColorParameter { value = Color.black };

    [Tooltip("Background color")]
    public ColorParameter backgroundColor = new ColorParameter { value = Color.white };

    [Range(0.1f, 1.0f), Tooltip("Edge detection threshold")]
    public FloatParameter threshold = new FloatParameter { value = 0.2f };
}

public sealed class CustomEdgeDetectionRenderer : PostProcessEffectRenderer<CustomEdgeDetection>
{
    private Shader edgeDetectionShader;

    public override void Init()
    {
        edgeDetectionShader = Shader.Find("Hidden/Custom/EdgeDetection");
    }

    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(edgeDetectionShader);

        sheet.properties.SetColor("_EdgeColor", settings.edgeColor);
        sheet.properties.SetColor("_BackgroundColor", settings.backgroundColor);
        sheet.properties.SetFloat("_Threshold", settings.threshold);

        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}
