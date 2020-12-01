using System.Collections.Generic;
using UnityEngine;

public class DanceNode : MonoBehaviour
{
    /// <summary>
    /// 節點類型
    /// </summary>
    public DancdNodeType node;
    /// <summary>
    /// 速度
    /// </summary>
    public float speed;
    /// <summary>
    /// 屬於哪位玩家的節點
    /// </summary>
    public int indexPlayer;

    private bool outOfLine;

    private DanceManager dm;

    public List<DancdNodeType> nodes = new List<DancdNodeType>();

    private void Awake()
    {
        dm = FindObjectOfType<DanceManager>();
    }

    private void Update()
    {
        //transform.Translate(-speed * Time.deltaTime, 0, 0);
        transform.Translate(0, -speed * Time.deltaTime, 0);

        RectTransform check = dm.dPlayerManager[indexPlayer].check;
        print(Vector2.Distance(GetComponent<RectTransform>().anchoredPosition, check.anchoredPosition));

        float dis = Vector2.Distance(GetComponent<RectTransform>().anchoredPosition, check.anchoredPosition);

        //if (dis < 20)
        //{
        //    dm.nodePlaysIndex[indexPlayer]++;
        //}
        //else
        //{
        //    nodes = dm.nodesPlays[indexPlayer];
        //    if (dm.nodePlaysIndex[indexPlayer] - 1 >= 0) nodes[dm.nodePlaysIndex[indexPlayer] - 1] = DancdNodeType.無;
        //}
        if (GetComponent<RectTransform>().anchoredPosition.x <= -280 && !outOfLine)
        {
            outOfLine = true;
            dm.nodePlaysIndex[indexPlayer]++;
        }
        if (outOfLine && GetComponent<RectTransform>().anchoredPosition.x <= -300)
        {
            nodes = dm.nodesPlays[indexPlayer];
            if (dm.nodePlaysIndex[indexPlayer] - 1 >= 0) nodes[dm.nodePlaysIndex[indexPlayer] - 1] = DancdNodeType.無;
        }
    }
}
