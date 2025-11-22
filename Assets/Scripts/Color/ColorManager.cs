using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Ebac.Core.Singleton;

public class ColorManager : Singleton<ColorManager>
{
    public List<Material> materials;
    public List<ColorSetup> colorSetups;
    public Color currentColor;

    public void ChangeColorByType(ArtManager.ArtType artType)
    {
       var setup = colorSetups.Find(i => i.artType == artType);

        for (int i=0; i < materials.Count; i++)
        {
            materials[i] = new Material(materials[i]);
            materials[i].SetColor("_color", setup.colors[i]);
        }
        currentColor = setup.colors[0];
    }

    private void Start()
    {
        for (int i = 0; i < materials.Count; i++)
        {
            materials[i] = Instantiate(materials[i]);
        }
    }

}

[System.Serializable]
public class ColorSetup
{
    public ArtManager.ArtType artType;
    public List<Color> colors;
}
