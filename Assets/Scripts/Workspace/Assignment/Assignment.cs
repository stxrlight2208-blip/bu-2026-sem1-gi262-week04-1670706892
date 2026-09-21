```csharp
using UnityEngine;
using System.Collections.Generic;

namespace Assignment
{
    public class Assignment : MonoBehaviour
    {
        public void Start()
        {
            // AS01_CountWords();
            // AS02_CountNumber();
            // AS03_CheckValidBrackets();
            // AS04_PrintReverseLinkedList();
            // AS05_FindMiddleElement();
            // AS06_MergeDictionaries();
            // AS07_RemoveDuplicatesFromLinkedList();
            // AS08_TopFrequentNumber();
            // AS09_PlayerInventory();
            // AS10_GameEventQueue();
            // AS11_PlayerStatsTracker();
        }

        #region Assignment

        [Header("AS01 - Count Words")]
        [SerializeField] private string[] as01Words;

        public void AS01_CountWords()
        {
            string[] words = as01Words;

            Dictionary<string, int> count = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (count.ContainsKey(word))
                    count[word]++;
                else
                    count.Add(word, 1);
            }

            foreach (KeyValuePair<string, int> item in count)
            {
                Debug.Log(item.Key + " : " + item.Value);
            }
        }


        [Header("AS02 - Count Number")]
        [SerializeField] private int[] as02Numbers;

        public void AS02_CountNumber()
        {
            int[] numbers = as02Numbers;

            Dictionary<int, int> count = new Dictionary<int, int>();

            foreach (int number in numbers)
            {
                if (count.ContainsKey(number))
                    count[number]++;
                else
                    count.Add(number, 1);
            }

            foreach (KeyValuePair<int, int> item in count)
            {
                Debug.Log(item.Key + " : " + item.Value);
            }
        }


        [Header("AS03 - Check Valid Brackets")]
        [SerializeField] private string as03Input;

        public void AS03_CheckValidBrackets()
        {
            string input = as03Input;

            Stack<char> stack = new Stack<char>();

            foreach (char c in input)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0)
                    {
                        Debug.Log("Invalid");
                        return;
                    }

                    char open = stack.Pop();

                    if ((c == ')' && open != '(') ||
                        (c == ']' && open != '[') ||
                        (c == '}' && open != '{'))
                    {
                        Debug.Log("Invalid");
                        return;
                    }
                }
            }

            if (stack.Count == 0)
                Debug.Log("Valid");
            else
                Debug.Log("Invalid");
        }


        [Header("AS04 - Print Reverse Linked List")]
        [SerializeField] private IntLinkedListInput as04List = new IntLinkedListInput();

        public void AS04_PrintReverseLinkedList()
        {
            LinkedList<int> list = as04List.GetLinkedList();

            LinkedListNode<int> current = list.Last;

            while (current != null)
            {
                Debug.Log(current.Value);
                current = current.Previous;
            }
        }


        [Header("AS05 - Find Middle Element")]
        [SerializeField] private StringLinkedListInput as05List = new StringLinkedListInput();

        public void AS05_FindMiddleElement()
        {
            LinkedList<string> list = as05List.GetLinkedList();

            if (list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            LinkedListNode<string> slow = list.First;
            LinkedListNode<string> fast = list.First;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            Debug.Log("Middle : " + slow.Value);
        }


        [Header("AS06 - Merge Dictionaries")]
        [SerializeField] private StringIntDictionaryInput as06FirstDictionary = new StringIntDictionaryInput();
        [SerializeField] private StringIntDictionaryInput as06SecondDictionary = new StringIntDictionaryInput();

        public void AS06_MergeDictionaries()
        {
            Dictionary<string, int> dict1 = as06FirstDictionary.GetDictionary();
            Dictionary<string, int> dict2 = as06SecondDictionary.GetDictionary();

            Dictionary<string, int> result = new Dictionary<string, int>(dict1);

            foreach (KeyValuePair<string, int> item in dict2)
            {
                if (result.ContainsKey(item.Key))
                    result[item.Key] += item.Value;
                else
                    result.Add(item.Key, item.Value);
            }

            foreach (KeyValuePair<string, int> item in result)
            {
                Debug.Log(item.Key + " : " + item.Value);
            }
        }


        [Header("AS07 - Remove Duplicates From Linked List")]
        [SerializeField] private IntLinkedListInput as07List = new IntLinkedListInput();

        public void AS07_RemoveDuplicatesFromLinkedList()
        {
            LinkedList<int> list = as07List.GetLinkedList();

            HashSet<int> seen = new HashSet<int>();

            LinkedListNode<int> current = list.First;

            while (current != null)
            {
                LinkedListNode<int> next = current.Next;

                if (seen.Contains(current.Value))
                    list.Remove(current);
                else
                    seen.Add(current.Value);

                current = next;
            }

            foreach (int number in list)
            {
                Debug.Log(number);
            }
        }


        [Header("AS08 - Top Frequent Number")]
        [SerializeField] private int[] as08Numbers;

        public void AS08_TopFrequentNumber()
        {
            int[] numbers = as08Numbers;

            if (numbers == null || numbers.Length == 0)
            {
                Debug.Log("No numbers");
                return;
            }

            Dictionary<int, int> count = new Dictionary<int, int>();

            foreach (int number in numbers)
            {
                if (count.ContainsKey(number))
                    count[number]++;
                else
                    count.Add(number, 1);
            }

            int topNumber = numbers[0];
            int maxCount = 0;

            foreach (KeyValuePair<int, int> item in count)
            {
                if (item.Value > maxCount)
                {
                    maxCount = item.Value;
                    topNumber = item.Key;
                }
            }

            Debug.Log("Top Frequent Number : " + topNumber);
            Debug.Log("Count : " + maxCount);
        }


        [Header("AS09 - Player Inventory")]
        [SerializeField] private StringIntDictionaryInput as09Inventory = new StringIntDictionaryInput();
        [SerializeField] private string as09ItemName;
        [SerializeField] private int as09Quantity;

        public void AS09_PlayerInventory()
        {
            Dictionary<string, int> inventory = as09Inventory.GetDictionary();

            string itemName = as09ItemName;
            int quantity = as09Quantity;

            if (inventory.ContainsKey(itemName))
                inventory[itemName] += quantity;
            else
                inventory.Add(itemName, quantity);

            Debug.Log(itemName + " : " + inventory[itemName]);

            foreach (KeyValuePair<string, int> item in inventory)
            {
                Debug.Log(item.Key + " : " + item.Value);
            }
        }


        [Header("AS10 - Game Event Queue")]
        [SerializeField] private GameEventLinkedListInput as10EventQueue = new GameEventLinkedListInput();

        public void AS10_GameEventQueue()
        {
            LinkedList<GameEvent> eventQueue = as10EventQueue.GetLinkedList();

            while (eventQueue.Count > 0)
            {
                GameEvent currentEvent = eventQueue.First.Value;

                Debug.Log(currentEvent);

                eventQueue.RemoveFirst();
            }

            Debug.Log("Event Queue Empty");
        }


        [Header("AS11 - Player Stats Tracker")]
        [SerializeField] private StringIntDictionaryInput as11PlayerStats = new StringIntDictionaryInput();
        [SerializeField] private string as11StatName;
        [SerializeField] private int as11Value;

        public void AS11_PlayerStatsTracker()
        {
            Dictionary<string, int> playerStats = as11PlayerStats.GetDictionary();

            string statName = as11StatName;
            int value = as11Value;

            if (playerStats.ContainsKey(statName))
                playerStats[statName] += value;
            else
                playerStats.Add(statName, value);

            Debug.Log(statName + " : " + playerStats[statName]);

            foreach (KeyValuePair<string, int> stat in playerStats)
            {
                Debug.Log(stat.Key + " : " + stat.Value);
            }
        }

        #endregion
    }
}