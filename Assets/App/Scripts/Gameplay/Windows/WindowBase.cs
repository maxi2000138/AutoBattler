using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Gameplay.Windows.Win
{
  public abstract class WindowBase<T> : MonoBehaviour
  {
    private UniTaskCompletionSource<T> _completionSource;
    
    protected UniTask<T> Show()
    {
      _completionSource = new UniTaskCompletionSource<T>();
      ShowWindow();
      
      return _completionSource.Task;
    }
    
    protected void SetResult(T result)
    {
      _completionSource.TrySetResult(result);
      HideWindow();
    }
    
    private void ShowWindow()
    {
      gameObject.SetActive(true);
    }
    private void HideWindow()
    {
      gameObject.SetActive(false);
    }
  }
}