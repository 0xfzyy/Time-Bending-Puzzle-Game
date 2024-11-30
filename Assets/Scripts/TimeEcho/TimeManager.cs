 using UnityEngine;
using System.Collections.Generic;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }
    
    [SerializeField] private GameObject timeEchoPrefab;
    [SerializeField] private int maxEchoes = 3;
    
    private List<TimeEcho> activeEchoes = new List<TimeEcho>();
    private PlayerRecorder playerRecorder;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
            
        playerRecorder = FindObjectOfType<PlayerRecorder>();
    }
    
    public void CreateTimeEcho()
    {
        if (activeEchoes.Count >= maxEchoes)
            return;
            
        GameObject echoObj = Instantiate(timeEchoPrefab);
        TimeEcho echo = echoObj.GetComponent<TimeEcho>();
        
        // 获取玩家记录的动作并初始化回响
        echo.Initialize(playerRecorder.GetRecording());
        
        activeEchoes.Add(echo);
        playerRecorder.ClearRecording();
    }
    
    public void ResetAllEchoes()
    {
        foreach (var echo in activeEchoes)
        {
            Destroy(echo.gameObject);
        }
        activeEchoes.Clear();
        playerRecorder.ClearRecording();
    }
}