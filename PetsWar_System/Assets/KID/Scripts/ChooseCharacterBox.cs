using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace KID
{
    public class ChooseCharacterBox : MonoBehaviour
    {
        [Header("玩家資料：玩家 1 - 玩家 4")]
        /// <summary>
        /// 玩家資料：玩家 1 - 玩家 4
        /// </summary>
        public PlayerData[] players;
        [Header("選取角色盒子")]
        public Image[] imgBoxes;
        [Header("角色")]
        public Transform[] characters;

        /// <summary>
        /// 選取角色方塊的四個座標
        /// </summary>
        public List<float> posCharacters = new List<float> { -450, -150, 150, 450 };

        public List<int> indexCharacters = new List<int> { 0, 1, 2, 3 };

        private void Update()
        {
            MoveBox();
        }

        /// <summary>
        /// 移動選取角色盒子
        /// </summary>
        private void MoveBox()
        {
            if (Input.anyKeyDown)
            {
                for (int i = 0; i < players.Length; i++)
                {
                    if (Input.GetKeyDown(players[i].right))
                    {
                        int index = indexCharacters[i];
                        index++;

                        if (index >= posCharacters.Count) index = 0;

                        indexCharacters[i] = index;

                        imgBoxes[i].rectTransform.anchoredPosition = new Vector2(posCharacters[index], imgBoxes[i].rectTransform.anchoredPosition.y);
                        imgBoxes[i].transform.SetParent(characters[index]);
                        imgBoxes[i].transform.SetAsFirstSibling();
                    }

                    if (Input.GetKeyDown(players[i].left))
                    {
                        int index = indexCharacters[i];
                        index--;

                        if (index <= -1) index = posCharacters.Count - 1;

                        indexCharacters[i] = index;

                        imgBoxes[i].rectTransform.anchoredPosition = new Vector2(posCharacters[index], imgBoxes[i].rectTransform.anchoredPosition.y);
                        imgBoxes[i].transform.SetParent(characters[index]);
                        imgBoxes[i].transform.SetAsFirstSibling();
                    }
                }
            }
        }
    }
}

