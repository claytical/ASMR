using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class CubeMapCreateTool : ScriptableWizard
{
    public Transform renderPosition;
    public Cubemap customCubemap;

    private void OnWizardUpdate()
    {
        helpString = "Select transform to render" + "from and cubemap to render into";
        if (renderPosition!=null&&customCubemap!=null)
        {
            isValid = true;
        }
        else
        {
            isValid = false;
        }
    }
    void OnWizardCreate()
    {
        GameObject go = new GameObject("CubeCam", typeof(Camera));

        go.transform.position = renderPosition.position;
        go.transform.rotation = Quaternion.identity;

        go.GetComponent<Camera>().RenderToCubemap(customCubemap);

        DestroyImmediate(go);
    }
    [MenuItem("Custom/Render Cubemap")]
        static void RenderCubemap()
    {
        ScriptableWizard.DisplayWizard("Render CubeMap", typeof(CubeMapCreateTool), "Render!");
    }
}
