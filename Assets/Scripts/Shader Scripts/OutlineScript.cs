
using UnityEngine;



public class OutlineScript : MonoBehaviour

{

    [SerializeField] private Material outlineMaterial;

    [SerializeField] private float outlineScaleFactor;

    [SerializeField] private Color outlineColor;

    private Renderer outlineRenderer;



    void Start()

    {
        ResetMaterial();
    }

    public void SetMaterial()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }

        outlineRenderer = CreateOutline(outlineMaterial, outlineScaleFactor, outlineColor);
        outlineRenderer.enabled = true;
    }

    public void ResetMaterial()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }
    }

    Renderer CreateOutline(Material outlineMat, float scaleFactor, Color color)

    {

        GameObject outlineObject = Instantiate(this.gameObject, transform.position, transform.rotation, transform);

        Renderer rend = outlineObject.GetComponent<Renderer>();



        rend.material = outlineMat;

        rend.material.SetColor("_OutlineColor", color);

        rend.material.SetFloat("_Scale", scaleFactor);

        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;



        outlineObject.GetComponent<OutlineScript>().enabled = false;

        outlineObject.GetComponent<Collider>().enabled = false;



        rend.enabled = false;



        return rend;

    }

}