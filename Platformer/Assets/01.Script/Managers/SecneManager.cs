using UnityEngine.SceneManagement;

public class SecneManager : MonoSingleTon<SecneManager>
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
