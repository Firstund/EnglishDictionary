using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm_Winter_3
{
    public static class Utill
    {
        public static string CharArrayToString(this char[] a)
        {
            string result = "";

            for(int i = 0; i < a.Length; i++)
            {
                result += a[i];
            }

            return result;
        }
    }
    class Word
    {
        public char[] contents = "NULL".ToCharArray();
        public char[] contents_mean = "NULL".ToCharArray();
        public int num = 0;

        public Word()
        {

        }
        public Word(char[] c, char[] cm, int n)
        {
            contents = c;
            contents_mean = cm;

            num = n;
        }
    }
    class BST
    {
        public Word value = new Word();

        private BST leftNode = null;
        private BST rightNode = null;

        public BST(Word v)
        {
            value = v;
        }
        public void SetNode(BST v)
        {
            if(v.value.contents.Length <= value.contents.Length)
            {
                SetLeftNode(v);
            }
            else
            {
                SetRightNode(v);
            }
        }
        public BST GetNode(char[] v)
        {
            if(v.Length <= value.contents.Length)
            {
                return GetLeftNode();
            }
            else
            {
                return GetRightNode();
            }
        }
        private void SetLeftNode(BST v)
        {
            if(leftNode == null)
            {
                leftNode = v;
            }
            else
            {
                leftNode.SetNode(v);
            }
        }
        public BST GetLeftNode()
        {
            return leftNode;
        }
        private void SetRightNode(BST v)
        {
            if(rightNode == null)
            {
                rightNode = v;
            }
            else
            {
                rightNode.SetNode(v);
            }
        }
        public BST GetRightNode()
        {
            return rightNode;
        }
        public void ClearNode()
        {
            leftNode = null;
            rightNode = null;
        }
    }
    class Program
    {
        static BST rootNode = null;
        static List<BST> nodeList = new List<BST>();

        static int wordNum = 0;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                bool isEnd = false;
                Console.WriteLine("1: 입력, 2: 삭제, 3: 탐색, 4: 출력, 5: 정렬, 6: 종료");

                string answer = Console.ReadLine();

                switch(answer)
                {
                    case "1":
                        Input();
                        break;
                    case "2":
                        Delete();
                        break;
                    case "3":
                        Search();
                        break;
                    case "4":
                        OutPut();
                        break;
                    case "5":
                        SortWords();
                        break;
                    case "6":
                        isEnd = true;
                        break;
                    default:
                        Console.WriteLine("올바른 값을 입력하십시오.");
                        Console.ReadKey();
                        break;
                }

                if(isEnd)
                {
                    break;
                }
            }
        }
        static void SetNode(BST value)
        {
            if (rootNode == null)
            {
                rootNode = value;
            }
            else
            {
                rootNode.SetNode(value);
            }
        }
        static void Input()
        {
            Console.WriteLine("삽입할 영어 단어를 입력하십시오.");

            string words = Console.ReadLine();

            Console.WriteLine("삽입할 영어단어의 뜻을 입력하십시오.");

            string words_mean = Console.ReadLine();

            BST value = new BST(new Word(words.ToCharArray(), words_mean.ToCharArray(), ++wordNum));

            bool isSame = false;

            foreach(BST item in nodeList)
            {
                if (item.value.contents.CharArrayToString() == words)
                {
                    isSame = true;
                    break;
                }
            }

            if (!isSame)
            {
                nodeList.Add(value);

                SetNode(value);
            }
            else
            {
                Console.WriteLine("단어'" + words + "'는 중복된 단어입니다.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("삽입을 완료했습니다.");
            Console.ReadKey();
        }
        static void Search()
        {
            if (rootNode == null)
            {
                Console.WriteLine("찾을 수 있는 단어가 없습니다.");
                Console.ReadKey();

                return;
            }

            Console.WriteLine("찾을 단어를 입력하십시오.");

            char[] words = Console.ReadLine().ToCharArray();

            List<Word> list = new List<Word>();

            SetSearchList(words, rootNode, list);

            BST node = rootNode;

            while(true)
            {
                if(node.value.contents.CharArrayToString() == words.CharArrayToString())
                {
                    Console.WriteLine("찾으시려던 단어는 " + node.value.num + "번째 단어인 '" + node.value.contents.CharArrayToString() + "'입니다.");

                    break;
                }

                if (node != rootNode)
                {
                    SetSearchList(words, node, list);
                }

                if (node.GetLeftNode() != null || node.GetRightNode() != null)
                {
                    node = node.GetNode(words);

                    if(node != null)
                    {
                        continue;
                    }
                }

                Console.WriteLine("'" + words.CharArrayToString() + "'단어를 찾을 수 없습니다.");

                if(list.Count > 0)
                {
                    Console.WriteLine("비슷한 단어들은, ");

                    for(int i = 0; i < list.Count; i++)
                    {
                        if (i == list.Count - 1)
                        {
                            Console.WriteLine(list[i].num + "번째 단어인 '" + list[i].contents.CharArrayToString() + "'입니다.");
                        }
                        else
                        {
                            Console.WriteLine(list[i].num + "번째 단어인 '" + list[i].contents.CharArrayToString() +"', ");
                        }
                    }
                }

                break;
            }

            Console.ReadKey();
        }
        static void SetSearchList(char[] words, BST target, List<Word> list)
        {
            int searchOffset = 2;
            if (words.Length <= target.value.contents.Length)
            {
                int num = 0;

                searchOffset = words.Length / 2;

                //for(int i = 0; i < words.Length; i++)
                //{
                //    if(words[i] == target.value.contents[i])
                //    {
                //        num++;
                //    }
                //}

                bool isBreak = false;

                for(int i = 0; i < words.Length; i++)
                {
                    for (int j = 0; j < target.value.contents.Length; j++)
                    {
                        if (words[i] == target.value.contents[j])
                        {
                            //Console.WriteLine(words[Limit(i, 0, words.Length - 1)]);
                            num++;

                            if (num >= words.Length - searchOffset)
                            {
                                isBreak = true;
                                break;
                            }
                        }
                    }

                    if(isBreak)
                    {
                        break;
                    }
                }
                
                if (num >= words.Length - searchOffset)
                {
                    list.Add(target.value);
                }
            }
        }
        static void Delete()
        {
            if(wordNum <= 0)
            {
                Console.WriteLine("삭제할 단어가 없습니다.");
                Console.ReadKey();

                return;
            }

            int deleteNum = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("삭제할 단어의 번호를 입력하십시오. (최소: 1, 최대: " + wordNum + ")");

                string answer = Console.ReadLine();

                if(int.TryParse(answer, out deleteNum) && deleteNum > 0 && deleteNum <= wordNum)
                {
                    bool changeNum = deleteNum == nodeList.Count;

                    nodeList.RemoveAt(deleteNum - 1);

                    for (int i = deleteNum - 1; i < nodeList.Count; i++) // 삭제로인해 변경된 순서를 맞춰줌
                    {
                        nodeList[i].value.num--;  
                    }

                    wordNum--;

                    ResetNode();

                    Console.WriteLine(deleteNum + "번째 단어를 삭제했습니다.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("올바른 값을 입력하십시오.");
                    Console.ReadKey();
                }
            }
        }
        static void ResetNode() // 노드를 새로고침해줌 
        {
            foreach (BST item in nodeList) // 모든 노드들의 연결을 끊어줌
            {
                item.ClearNode(); 
            }

            foreach(BST item in nodeList)
            {
                if (item != rootNode) // 루트 노드를 제외한 모든 노드들 재배치
                {
                    SetNode(item);
                }
            }
        }
        static void OutPut()
        {
            Console.WriteLine("단어장의 모든 단어들을 출력합니다. \n");

            for(int i = 0; i < nodeList.Count; i++)
            {
                Console.WriteLine((i + 1) + ": '" + nodeList[i].value.contents.CharArrayToString() + "', '" + nodeList[i].value.contents_mean.CharArrayToString() + "'");
            }

            Console.WriteLine("\n출력을 완료했습니다.");
            Console.ReadKey();
        }
        static void SortWords()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("단어를 정렬합니다. 영어 단어 기준으로 정렬하시겠습니까, 단어 뜻 기준으로 정렬하시겠습니까?");
                Console.WriteLine("1: 영어 단어 기준, 2: 한국어 뜻 기준");

                bool isEnd = false;

                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        Sort(true);

                        isEnd = true;
                        break;
                    case "2":
                        Sort(false);

                        isEnd = true;
                        break;
                    default:
                        Console.WriteLine("올바른 값을 입력하십시오.");
                        Console.ReadKey();
                        break;
                }

                if(isEnd)
                {
                    break;
                }
            }
        }
        static void Sort(bool byEng) // 정렬
        {
            while (true)
            {
                bool orderByASC = false;

                Console.WriteLine("오름차순으로 정렬하시겠습니까 내림차순으로 정렬하시겠습니까");
                Console.WriteLine("1: 오름차순, 2: 내림차순");

                string answer = Console.ReadLine();

                if(!(answer == "1" || answer == "2"))
                {
                    Console.WriteLine("올바른 값을 입력하십시오.");
                    Console.ReadKey();
                    Console.Clear();

                    continue;
                }

                orderByASC = (answer == "1");

                if (byEng)
                {
                    if (orderByASC)
                    {
                        var value = from x in nodeList orderby x.value.contents.CharArrayToString() select x;
                        nodeList = value.ToList();
                    }
                    else
                    {
                        var value = from x in nodeList orderby x.value.contents.CharArrayToString() descending select x;

                        nodeList = value.ToList();
                    }
                }
                else
                {
                    if (orderByASC)
                    {
                        var value = from x in nodeList orderby x.value.contents_mean.CharArrayToString() select x;

                        nodeList = value.ToList();
                    }
                    else
                    {
                        var value = from x in nodeList orderby x.value.contents_mean.CharArrayToString() descending select x;

                        nodeList = value.ToList();
                    }
                }

                ResetListNum();

                Console.WriteLine("정렬을 완료했습니다.");
                Console.ReadKey();
                break;
            }
        }
        static void ResetListNum()
        {
            for(int i = 0; i < nodeList.Count; i++)
            {
                nodeList[i].value.num = i + 1;
            }
        }
        static int Limit(int value, int min, int max)
        {
            if (min > max)
            {
                Console.WriteLine("옳지 않은 min 또는 max의 값");

                return -1;
            }

            if (value < min)
            {
                return Limit(max - (min - value - 1), min, max);
            }
            else if (value > max)
            {
                return Limit(min + (value - max - 1), min, max);
            }
            else
            {
                return value;
            }
        }
    }
}
