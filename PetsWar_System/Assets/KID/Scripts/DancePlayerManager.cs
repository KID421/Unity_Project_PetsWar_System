using UnityEngine;
using System.Collections.Generic;
using KID;

public class DancePlayerManager : MonoBehaviour
{
    /// <summary>
    /// 玩家資料
    /// </summary>
    public PlayerData player;
    /// <summary>
    /// 打擊音效
    /// </summary>
    public AudioClip sounds;

    private AudioSource aud;
    private DanceManager dm;

    private KeyCode[] playerInput = new KeyCode[7];
    private DancdNodeType[] nodeType = new DancdNodeType[7];

    public int index;
    public float score;
    public Animation ani;

    private void Awake()
    {
        playerInput[0] = player.forward;
        playerInput[1] = player.backward;
        playerInput[2] = player.left;
        playerInput[3] = player.right;
        playerInput[4] = player.a;
        playerInput[5] = player.b;
        playerInput[6] = player.c;

        nodeType[0] = DancdNodeType.上;
        nodeType[1] = DancdNodeType.下;
        nodeType[2] = DancdNodeType.左;
        nodeType[3] = DancdNodeType.右;
        nodeType[4] = DancdNodeType.A;
        nodeType[5] = DancdNodeType.B;
        nodeType[6] = DancdNodeType.C;

        aud = GetComponent<AudioSource>();

        dm = FindObjectOfType<DanceManager>();

        ani["植物成長"].speed = 0;
    }

    private void Update()
    {
        CheckNode();
    }

    private void CheckNode()
    {
        if (!Input.anyKeyDown) return;

        if (Input.anyKeyDown)
        {
            
            if (Input.GetKeyDown(playerInput[index]))
            {
                List<DancdNodeType> nodes = dm.nodesPlays[index];
                List<Transform> nodeObjects = dm.nodesPlayObjects[index];

                if (nodes[dm.nodePlaysIndex[index]] == nodeType[index])
                {
                    aud.Stop();
                    print("正確");
                    nodeObjects[dm.nodePlaysIndex[index]].GetComponent<DanceNode>().speed = 0;
                    score += 0.1f;
                    ani["植物成長"].normalizedTime = score;
                }
            }
        }
    }
}
