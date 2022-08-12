using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public StrongBrick StrongBrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    private bool m_Started = false;

    private bool m_GameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        SetBricks();
    }

    //Abstraction
    void SetBricks()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                if (i == LineCount - 1)
                {
                    var brick = Instantiate(StrongBrickPrefab, position, Quaternion.identity);
                }
                else
                {
                    var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                }


            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void GameOver()
    {
        m_GameOver = true;
    }
}
