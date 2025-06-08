using UnityEngine;

public class SpearDoor : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    [ContextMenu("Open Door")]
    public void Open()
    {
        _animator.SetTrigger("Open");
    }


    [ContextMenu("Close Door")]
    public void Close()
    {
        _animator.SetTrigger("Close");
    }
}
