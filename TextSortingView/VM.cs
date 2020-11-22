using ClassLibrary.Algorithms;
using ClassLibrary.Generators;
using ClassLibrary.Measurers;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSortingView
{
    public class VM : BindableBase
    {
        public string InputText { get; set; }
        public ObservableCollection<string> SortedText { get; set; }
        public ObservableCollection<El> SortedTextWords { get; set; }
        public DelegateCommand SortText { get; set; }
        public DelegateCommand GenerateRandomText { get; set; }
        public DelegateCommand ClearText { get; set; }
        public int RandomTextLength { get; set; }
        public int WordsInText { get; set; }
        public int UniqueWordsInText { get; set; }
        public int BubbleSortingTime { get; set; }
        public int MergeSortingTime { get; set; }
        public string SortTextLabel { get; set; }

        public VM()
        {
            SortedText = new ObservableCollection<string>();
            SortedTextWords = new ObservableCollection<El>();
            SortTextLabel = "Sort text";
            InputText = "Place a text here";
            SortText = new DelegateCommand(() =>
            {
                ClearInfo();
                SortTextLabel = "Sorting...";
                RaisePropertyChanged("SortTextLabel");
                Sort();
            });
            GenerateRandomText = new DelegateCommand(() =>
            {
                InputText = TextGenerator.GenerateText(RandomTextLength, 3);
                RaisePropertyChanged("InputText");
            });
            ClearText = new DelegateCommand(() =>
            {
                InputText = "";
                RaisePropertyChanged("InputText");
                ClearInfo();
            });
        }
        public void ClearInfo()
        {
            SortedTextWords.Clear();
            SortedText.Clear();
            WordsInText = 0;
            UniqueWordsInText = 0;
            MergeSortingTime = 0;
            BubbleSortingTime = 0;
            UpdateInfo();
        }
        public void UpdateInfo()
        {
            RaisePropertyChanged("WordsInText");
            RaisePropertyChanged("UniqueWordsInText");
            RaisePropertyChanged("MergeSortingTime");
            RaisePropertyChanged("BubbleSortingTime");
            RaisePropertyChanged("SortedText");
            RaisePropertyChanged("SortedTextWords");
        }
        public async void Sort()
        {
            string[] arr = await Task.Run(() => 
            {
                InputText = InputText.Trim();
                string[] array = Split(InputText);
                if (array.Length > 0)
                {
                    GC.Collect();
                    BubbleSortingTime = (int)ActionTimeMeasurer.Measure(new Action(() =>
                                                       BubbleSorter.Sort(array)));
                    array = Split(InputText);
                    if (array.Length > 0)
                    {
                        GC.Collect();
                        MergeSortingTime = (int)ActionTimeMeasurer.Measure(new Action(() =>
                                                            MergeSorter.Sort(array)));
                    }
                    WordsInText = array.Length;
                }
                return array;
            });
            ArrToObsColl(arr);
            CalcWords(arr);
            SortTextLabel = "Sort Text";
            UniqueWordsInText = SortedTextWords.Count();
            RaisePropertyChanged("SortTextLabel");
            UpdateInfo();
        }
        public void ArrToObsColl(string[] arr)
        {
            foreach(string str in arr)
            {
                SortedText.Add(str);
            }
        }
        public void CalcWords(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                string str = arr[i];
                int count = 0;
                while (i < arr.Length && arr[i] == str)
                {
                    if (i < arr.Length) count++;
                    i++;
                }
                i--;
                SortedTextWords.Add(new El(str, count));
            }
        }
        public class El
        {
            public string Word { get; set; }
            public int Count { get; set; }
            public El(string str, int count)
            {
                Word = str;
                Count = count;
            }
        }
        public static string[] Split(string text)
        {
            if (text == null)
            {
                return new string[0];
            }
            char[] separators = new char[] { ' ', ',', ':', ';', '?', '.', '(', ')',
                '"', '-', '‘', '’', '—', '\n', '\r', '"', '!', '[', ']' };
            List<string> wordsToRemove = new List<string>();
            List<string> output = text.ToLower()
                .Split(separators)
                .ToList();
            foreach (string word in output)
            {
                char ch = ' ';
                bool flag = false;
                foreach (char symbol in word)
                {
                    if (symbol != ch)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag) wordsToRemove.Add(word);
            }
            foreach (string word in wordsToRemove)
            {
                output.Remove(word);
            }
            return output.ToArray();
        }
    }
}
