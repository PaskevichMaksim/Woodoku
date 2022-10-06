using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {
  [FormerlySerializedAs("progressBar")]
  [SerializeField]
  private Slider _progressBar;

  private void Start() {
    StartCoroutine(LoadAsynchronously());
  }
  
  private IEnumerator LoadAsynchronously() {
    AsyncOperation operation = SceneManager.LoadSceneAsync("Menu");
    
    while (!operation.isDone) {
      float progress = Mathf.Clamp01(operation.progress / 0.9f);
      _progressBar.value = progress;

      //Debug.Log(progress.ToString(CultureInfo.InvariantCulture));

      yield return null;
    }
  }
}