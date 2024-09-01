using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectMap : MonoBehaviour
{
    [SerializeField] GameObject buttonPrefabs;
    [SerializeField] Transform panelButton;
    private int _totalMap = 10;

    public GameObject playerPrefab; // Prefab cho player
    public GameObject enemyPrefab; // Prefab cho enemy
    private Transform _playerSpawnPoint; // Điểm spawn của player
    private Transform _enemySpawnPoint; // Điểm spawn của enemy

    private GameObject _playerInstance; // Instance của player
    private GameObject _enemyInstance; // Instance của enemy

    // Start is called before the first frame update
    void Start()
    {
        CreateMapButtons();
    }

    void CreateMapButtons()
    {
        for (int i = 1; i <= _totalMap; i++)
        {
            // Tạo mới một nút từ prefab
            GameObject button = Instantiate(buttonPrefabs, panelButton);

            // Tìm component Text từ prefab (nằm trên nút hoặc con của nút)
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();

            if(buttonText != null)
            {
                buttonText.text = "Mục " + i.ToString();
            }

            // Gán sự kiện bấm nút với delegate
            int stageIndex = i; // Lưu lại chỉ số để tránh lỗi closure
            button.GetComponent<Button>().onClick.AddListener(() => OnStageButtonClicked(stageIndex));
        }
    }

    void OnStageButtonClicked(int stageIndex)
    {
        Debug.Log("Mục được chọn: " + stageIndex);
        // Chuyển đến map tương ứng với mục đã chọn
        LoadMap(stageIndex);
    }

    void LoadMap(int stageIndex)
    {
        // Code tải map tương ứng với mục được chọn
        Debug.Log("Đang tải map cho mục: " + stageIndex);

        string sceneName = "Map" + stageIndex; // Ví dụ: Map1, Map2, Map3...
        Debug.Log("Đang tải map cho mục: " + sceneName);

        // Tải scene không đồng bộ để tránh giật lag
  /*      AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        asyncLoad.completed += OnMapLoaded;*/

        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive).completed += (AsyncOperation operation) =>
        {
            Debug.Log("Map đã tải xong, bắt đầu spawn player và enemy.");
            SetupSpawnPoints(stageIndex); // Thiết lập vị trí spawn dựa trên map
            SpawnCharacters(); // Gọi hàm spawn sau khi map đã tải
        };
    }

    void SetupSpawnPoints(int stageIndex)
    {
        // Tìm các điểm spawn trong scene đã tải (sử dụng tag hoặc đặt tên cụ thể để tìm)
        // Ví dụ: tìm các vị trí spawn bằng cách sử dụng tag
        _playerSpawnPoint = GameObject.FindWithTag("PlayerSpawnPoint").transform;
        _enemySpawnPoint = GameObject.FindWithTag("EnemySpawnPoint").transform;

        // Kiểm tra nếu không tìm thấy, có thể sử dụng các vị trí mặc định hoặc log lỗi
        if (_playerSpawnPoint == null || _enemySpawnPoint == null)
        {
            Debug.LogError("Không tìm thấy điểm spawn trên map! Sử dụng vị trí mặc định.");
            // Cài đặt vị trí mặc định nếu cần
        }
    }

/*    void OnMapLoaded(AsyncOperation obj)
    {
        Debug.Log("Map đã tải xong, bắt đầu spawn player và enemy.");
        SpawnCharacters(); // Gọi hàm để spawn player và enemy
    }*/
    void SpawnCharacters()
    {
        // Kiểm tra xem đã có instance nào tồn tại chưa, nếu có thì tái sử dụng hoặc xóa bỏ
        if (_playerInstance != null)
        {
            Destroy(_playerInstance); // Có thể thay thế bằng tái sử dụng với Object Pooling
        }

        if (_enemyInstance != null)
        {
            Destroy(_enemyInstance); // Có thể thay thế bằng tái sử dụng với Object Pooling
        }

        // Tạo player tại vị trí spawn xác định
        _playerInstance = Instantiate(playerPrefab, _playerSpawnPoint.position, _playerSpawnPoint.rotation);

        // Tạo enemy tại vị trí spawn xác định
        _enemyInstance = Instantiate(enemyPrefab, _enemySpawnPoint.position, _enemySpawnPoint.rotation);

        // Thiết lập các thuộc tính cần thiết cho player và enemy nếu cần
        //SetupPlayer(playerInstance);
        //SetupEnemy(enemyInstance);
    }
}
