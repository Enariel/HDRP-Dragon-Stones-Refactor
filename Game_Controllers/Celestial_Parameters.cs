using UnityEngine;

//This is a script based of Glynn Taylor
[CreateAssetMenu(menuName = "Celestial Parameters")]
public class Celestial_Parameters : ScriptableObject
{
    //Gradients to set certain lighting parameters.
    public Gradient ambientColour;
    public Gradient directionalColour;
    public Gradient fogColour;
    
}
