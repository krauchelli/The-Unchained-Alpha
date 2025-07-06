using UnityEngine;
using System.Collections;

public class IntervalSpearDoor : MonoBehaviour
{
    [Header("Interval Settings (in seconds)")]
    public float openInterval = 2f;
    public float closeInterval = 2f;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        if (_animator == null)
        {
            Debug.LogError($"No Animator component found on {gameObject.name}! Please add an Animator component.", this);
            return;
        }

        if (_animator.runtimeAnimatorController == null)
        {
            Debug.LogError($"No Animator Controller assigned to {gameObject.name}! Please assign an Animator Controller.", this);
            return;
        }

        Debug.Log($"SpearDoor {gameObject.name} initialized successfully with Animator Controller: {_animator.runtimeAnimatorController.name}");
    }

    private void Start()
    {
        if (_animator != null)
        {
            StartCoroutine(AutoToggleRoutine());
        }
    }

    private IEnumerator AutoToggleRoutine()
    {
        while (true)
        {
            Open();
            yield return new WaitForSeconds(openInterval);

            Close();
            yield return new WaitForSeconds(closeInterval);
        }
    }

    [ContextMenu("Open Door")]
    public void Open()
    {
        if (_animator == null)
        {
            Debug.LogError($"Animator is null on {gameObject.name}. Cannot open door.", this);
            return;
        }

        Debug.Log($"Attempting to open door: {gameObject.name}");
        _animator.SetTrigger("Open");
    }

    [ContextMenu("Close Door")]
    public void Close()
    {
        if (_animator == null)
        {
            Debug.LogError($"Animator is null on {gameObject.name}. Cannot close door.", this);
            return;
        }

        Debug.Log($"Attempting to close door: {gameObject.name}");
        _animator.SetTrigger("Close");
    }

    [ContextMenu("Debug Animator Info")]
    public void DebugAnimatorInfo()
    {
        if (_animator == null)
        {
            Debug.LogError("Animator is null!");
            return;
        }

        Debug.Log($"Animator Controller: {_animator.runtimeAnimatorController?.name}");
        Debug.Log($"Current State: {_animator.GetCurrentAnimatorStateInfo(0).fullPathHash}");
        Debug.Log($"Is Animator Enabled: {_animator.enabled}");
    }
}
