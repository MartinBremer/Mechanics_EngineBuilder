using UnityEngine;
using UnityEngine.UI;

public class TierSelector : MonoBehaviour
{
    public Toggle self;

    public Toggle other1;
    public Toggle other2;

    public void SelectTier()
    {        
        self.isOn = true;

        other1.isOn = false;
        other2.isOn = false;
    }
}
