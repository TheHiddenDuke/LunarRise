using UnityEngine;

public class AIManager2 : MonoBehaviour
{

    #region Singleton
    public static AIManager2 instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject ai;
    public void KillPlayer()
    {
        Destroy(ai);
    }
}