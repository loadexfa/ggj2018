using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
	public void NextScene()
	{
		SceneManager.LoadScene("Blank");
	}
}