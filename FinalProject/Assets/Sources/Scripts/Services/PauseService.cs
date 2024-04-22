using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PauseService : MonoBehaviour
{
    [field: SerializeField] public bool IsPause { get; set; }
    
    private List<IPause> _pauses = new List<IPause>();
    
    public void AddPause(IPause pause)
    {
        _pauses.Add(pause);
    }

    public void RemovePause(IPause pause)
    {
        _pauses.Remove(pause);
    }
    
    public void Pause()
    {
        //Time.timeScale = 0;
        IsPause = true;
        foreach (IPause pause in _pauses)
        {
            pause.Pause();
        }
    }

    public void Resum()
    {
        //Time.timeScale = 1;
        foreach (IPause pause in _pauses)
        {
            pause.Resum();
        }
    }
}
