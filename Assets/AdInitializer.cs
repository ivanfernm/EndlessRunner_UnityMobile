using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdInitializer : MonoBehaviour
{
    [SerializeField]
    private AddType addType;
    private string addTypeString;

    public static AdInitializer instance;
   
    // Start is called before the first frame update
    void Start()
    {    
        instance = this;
        Advertisement.Initialize("4493977",true); 
        addTypeString = addType.ToString(); 
    }

    private IEnumerator WaitForAdd()
    {
        while (!Advertisement.IsReady(addTypeString))
        {
            yield return null;   
        }

        ShowOptions options = new ShowOptions {resultCallback = AdFinished};
        Advertisement.Show(addTypeString,options);

    }
    public void ShowAdds()
    {
        StartCoroutine(WaitForAdd());
    }


    private void AdFinished(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            if (addType == AddType.GameOverLife)
            {
                
                PlayerBasics.instance.AddToLife(3); 
                PlayerBasics.instance.NotifyTo("Revive");    
            }
        }
        else if (result == ShowResult.Skipped)
        {
            if (addType == AddType.GameOverLife)
            {

                PlayerBasics.instance.AddToLife(1); 
                PlayerBasics.instance.NotifyTo("Revive");            
            }

        }
        else if (result == ShowResult.Failed)
        {
            
        }

    }
}
