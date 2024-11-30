using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject timeEchoPrefab;
    
    [Header("Spawn Points")]
    [SerializeField] private Transform playerSpawnPoint;
    
    private void Awake()
    {
        SetupPhysics2D();
        CreateRequiredObjects();
    }
    
    private void SetupPhysics2D()
    {
        // 配置2D物理设置
        Physics2D.gravity = new Vector2(0, -9.81f);
        Physics2D.defaultContactOffset = 0.01f;
    }
    
    private void CreateRequiredObjects()
    {
        // 生成玩家
        if (playerSpawnPoint != null)
        {
            Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("No player spawn point set!");
        }
        
        // 确保场景中有TimeManager
        if (FindObjectOfType<TimeManager>() == null)
        {
            GameObject timeManagerObj = new GameObject("TimeManager");
            TimeManager timeManager = timeManagerObj.AddComponent<TimeManager>();
            timeManager.SetTimeEchoPrefab(timeEchoPrefab);
        }
    }
}