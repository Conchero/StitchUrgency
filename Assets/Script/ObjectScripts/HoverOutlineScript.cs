using UnityEngine;

public class HoverOutlineScript : MonoBehaviour
{

    [SerializeField]
    Renderer outlineRenderer;

    [SerializeField]
    string isHoveredParameterName;

    [SerializeField]
    Shader outlineShader;

    Material dynamicOutlineMaterial;

    // Start is called before the first frame update
    void Start()
    {
        //Create a dynamic material instance and set it to the object
        dynamicOutlineMaterial = new Material(outlineShader);

        if (outlineRenderer != null)
        {
            outlineRenderer.materials[0] = dynamicOutlineMaterial;
        }


        if (isHoveredParameterName == string.Empty)
        {
            isHoveredParameterName = "_Outline_Multiplicator";
        }

        HideHoverOutline();
    }

    //Use a float as a bool, boolean from shader graph are not accessible 
    public void ShowHoverOutline()
    {
        if (outlineRenderer != null)
        {
            outlineRenderer.sharedMaterial.SetFloat(isHoveredParameterName, 1);
        }
    }

    //Use a float as a bool, boolean from shader graph are not accessible 
    public void HideHoverOutline()
    {

        if (outlineRenderer != null)
        {
            outlineRenderer.sharedMaterial.SetFloat(isHoveredParameterName, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
