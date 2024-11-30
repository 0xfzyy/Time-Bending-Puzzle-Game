using UnityEngine;
using System.Collections.Generic;

public class PlayerRecorder : MonoBehaviour
{
    public class TimeFrame
    {
        public Vector3 position;
        public Quaternion rotation;
        public bool isJumping;
        public float timestamp;
    }
    
    private List<TimeFrame> recordedFrames = new List<TimeFrame>();
    private bool isRecording = true;
    
    private void FixedUpdate()
    {
        if (isRecording)
        {
            RecordFrame();
        }
    }
    
    private void RecordFrame()
    {
        TimeFrame frame = new TimeFrame
        {
            position = transform.position,
            rotation = transform.rotation,
            isJumping = GetComponent<PlayerController>().IsJumping,
            timestamp = Time.time
        };
        
        recordedFrames.Add(frame);
    }
    
    public List<TimeFrame> GetRecording()
    {
        return new List<TimeFrame>(recordedFrames);
    }
    
    public void StopRecording()
    {
        isRecording = false;
    }
    
    public void ClearRecording()
    {
        recordedFrames.Clear();
        isRecording = true;
    }
} 