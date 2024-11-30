 using UnityEngine;
using System.Collections.Generic;

public class TimeEcho : MonoBehaviour
{
    private List<PlayerRecorder.TimeFrame> recordedFrames;
    private int currentFrame = 0;
    private float startTime;
    
    public void Initialize(List<PlayerRecorder.TimeFrame> frames)
    {
        recordedFrames = frames;
        startTime = Time.time;
    }
    
    private void Update()
    {
        if (recordedFrames == null || currentFrame >= recordedFrames.Count)
            return;
            
        // 重放录制的动作
        while (currentFrame < recordedFrames.Count && 
               Time.time - startTime >= recordedFrames[currentFrame].timestamp)
        {
            transform.position = recordedFrames[currentFrame].position;
            transform.rotation = recordedFrames[currentFrame].rotation;
            currentFrame++;
        }
    }
}