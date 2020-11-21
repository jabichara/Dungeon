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
        public ObservableCollection<Tuple<string, int>> SortedTextWords { get; set; }
        public DelegateCommand SortText { get; set; }
        public DelegateCommand GenerateRandomText { get; set; }
        public DelegateCommand ClearText { get; set; }
        public int RandomTextLength { get; set; }
        public int WordsInText { get; set; }
        public int UniqueWordsInText { get; set; }
        public int BubbleSortingTime { get; set; }
        public int MergeSortingTime { get; set; }

        public VM()
        {
            SortedText = new ObservableCollection<string>();
            SortedTextWords = new ObservableCollection<Tuple<string, int>>();
            SortText = new DelegateCommand(() =>
            {
                string[] array = InputText.Split();

                BubbleSortingTime = (int)ActionTimeMeasurer.Measure(new Action(() => 
                                                   BubbleSorter.Sort(array)));

                array = InputText.Split();

                MergeSortingTime = (int)ActionTimeMeasurer.Measure(new Action(() =>
                    MergeSorter.Sort(array)));

                GC.Collect();
            });
            GenerateRandomText = new DelegateCommand(() =>
            {
                InputText = TextGenerator.GenerateText(100, 3);
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
            WordsInText = 0;
            UniqueWordsInText = 0;
            MergeSortingTime = 0;
            BubbleSortingTime = 0;
            RaisePropertyChanged("WordsInText");
            RaisePropertyChanged("UniqueWordsInText");
            RaisePropertyChanged("MergeSortingTime");
            RaisePropertyChanged("BubbleSortingTime");
        }
    }
}
