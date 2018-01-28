using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
	public void LoadStartScene()
	{
		SceneManager.LoadScene(1);
	}
}