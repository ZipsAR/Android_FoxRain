using EnumTypes;
using UnityEngine;
using PlayMode = EnumTypes.PlayMode;

public class GameManager : Singleton<GameManager>
{
    public PlayMode currentPlayMode;
    public Player player; // Attached to AR Camera && Used to locate a user

    public InteractManager interactManager;
    public InteractAudioManager interactAudioManager;

    public PetType curPetType;
    
    private void Start()
    {
        curPetType = PetType.None;
    }

    public void QuitApp()
    {
        Application.Quit(0);
    }

    public bool ChangeMode(PlayMode playMode)
    {
        if (playMode == currentPlayMode)
        {
            return false;
        }

        currentPlayMode = playMode;
        return true;
    }

    /*
     
    /// <summary>
    /// Caution : Scene name must be spelled correctly because there is no exception handling part
    /// </summary>
    /// <param name="sceneName">Scene name to load</param>
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneSequence(sceneName));
        // float3 aa = new float3(1, 0, 0);
        // float2 cc = new float2(4, 8);
        // float3 bb = cc.xyy;
        // float3 dd = Vector3.right;
        // math.distance(aa, bb);
        // var bNormal = math.normalizesafe(aa, 1);
        //
        // Quaternion a = Quaternion.Euler(0, 90, 0);
        //
        // quaternion curRot = transform.rotation;
        // quaternion rot = quaternion.Euler(0,math.PI/2,0);
        // quaternion aa = math.mul(curRot, rot); 
        // quaternion newRot = math.mul(curRot, rot);
        // transform.rotation = newRot;
    }
    
    private IEnumerator LoadSceneSequence(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        // Waiting for next scenes to load
        while (!asyncOperation.isDone)
        {
            yield return null;
            Logger.Log("Progress : " + asyncOperation.progress);
        }

        switch (sceneName)
        {
            case "InteractMode":
                PlacementSystem.Instance.ProtectGrib();
                MapInfo.Instance.SetReScale(6.33f);
                MapInfo.Instance.CatchObjectInitialize();
                MapInfo.Instance.SetInvisiblemode();
           
                interactManager = 
                    GameObject.Find("Interact Manager").GetComponent<InteractManager>();
                interactAudioManager =
                    GameObject.Find("Interact Audio Manager").GetComponent<InteractAudioManager>();
                ChangeMode(PlayMode.InteractMode);
                break;
            
            case "HousingMode":
                MapInfo.Instance.SetMapHousingmode();
                MapInfo.Instance.SetOrigin();
                MapInfo.Instance.SetReScale(16);
                MapInfo.Instance.MapUnGrabmode();
                break;
            
            case "StoreScene":
                MapInfo.Instance.CatchObjectInitialize();
                MapInfo.Instance.SetInvisiblemode();
                break;
        }
    }
    */

}
