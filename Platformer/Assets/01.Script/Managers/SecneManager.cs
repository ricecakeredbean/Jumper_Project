using UnityEngine.SceneManagement;

public class SecneManager : Singleton<SecneManager>
{
    public int GetSeceneNum()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadSecne(int StageNum)
    {
        SceneManager.LoadScene(StageNum);
    }
}
