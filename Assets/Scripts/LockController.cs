using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LockController : MonoBehaviour
{
    [SerializeField] private UnityEvent unlock;
    [SerializeField] private string code = "8888";
    [SerializeField] private int codeLimit;
    //string currentCode;
    //string errorCode;
    [SerializeField] private Text m_codeDisplay;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip correctSound;
    [SerializeField] private AudioClip wrongSound;

    private void Start()
    {
        m_codeDisplay.text = "";
    }

    public void KeyEntry(string key)
    {
        if (key == "Clear")
        {
            Clear();
            return;
        }
        else if (key == "Enter")
        {
            Enter();
            return;
        }

        int length = m_codeDisplay.text.ToString().Length;
        if (length < codeLimit)
        {
            m_codeDisplay.text = m_codeDisplay.text + key;
        }
    }

    //void KeyEntry(string key)
    //{
    //    currentCode += key;

    //    if (currentCode == code)
    //    {
    //        currentCode = "UNLOCKED";
    //        m_codeDisplay.color = Color.green;
    //        m_codeDisplay.text = currentCode;
    //        unlock.Invoke();
    //    }
    //    else if (currentCode.Length == code.Length)
    //    {
    //        currentCode = "";
    //        errorCode = "ERROR";
    //        m_codeDisplay.color = Color.red;
    //        m_codeDisplay.text = errorCode;
    //        m_codeDisplay.text = currentCode;
    //    }
    //    else
    //        m_codeDisplay.text = currentCode;
    //}

    private void Clear()
    {
        m_codeDisplay.text = "";
        m_codeDisplay.color = Color.black;
    }

    private void Enter()
    {
        if (m_codeDisplay.text == code)
        {
            //door.lockedByPassword = false;
            unlock.Invoke();

            if (audioSource != null)
                audioSource.PlayOneShot(correctSound);

            m_codeDisplay.color = Color.green;
            StartCoroutine(waitAndClear());
            m_codeDisplay.text = "UNLOCKED";
        }
        else
        {
            if (audioSource != null)
                audioSource.PlayOneShot(wrongSound);

            m_codeDisplay.color = Color.red;
            StartCoroutine(waitAndClear());
        }
    }
    IEnumerator waitAndClear()
    {
        yield return new WaitForSeconds(0.75f);
        Clear();
    }

}
