using System;
using System.Collections.Generic;
using System.Linq;


namespace _12ThJuneStringAlgoritham
{
    public class dynamicProgramming
    {
        public static List<string> SubSequences(string word) {
            var container = new List<string>();
            subSequences(word, word.Length, "", container);
            return container;
        }
        private static void subSequences(string word, int currentIndex, string Helper, List<string> container) {
            if (currentIndex == 0) {
                container.Add(Helper);
            }
            var currentCharacter = word[currentIndex - 1];
            // we have to choice wheather to select the current index or not

            // choice -1  selecting the current word
            subSequences(word, currentIndex - 1, currentCharacter + Helper, container);

            // choice-2  not selecting the current word
            subSequences(word, currentIndex - 1, Helper, container);
        }

        public static int longestCommonSubsequences(string word1, string word2) {
            return lcs(word1, word2, word1.Length, word2.Length);
        }

        private static int lcs(string word1, string word2, int length1, int length2)
        {
            if (length1 == 0 || length2 == 0) {
                return 0;
            }

            // selecting the currentWord 
            var character1 = word1[length1 - 1];
            var character2 = word2[length2 - 1];
            if (character1 == character2) {
                return 1 + lcs(word1, word2, length1 - 1, length2 - 1);
            }

            return Math.Max(
                        lcs(word1, word2, length1, length2 - 1),
                        lcs(word1, word2, length1 - 1, length2)
                    );
        }

        public static int longestCommonSubString(string word1, string word2) {
            return lcsubstring(word1, word2, word1.Length, word2.Length, 0);
        }

        private static int lcsubstring(string word1, string word2, int length1, int length2, int count)
        {
            if (length1 == 0 || length2 == 0) return count;

            var character1 = word1[length1 - 1];
            var character2 = word2[length2 - 1];
            if (character1 == character2)
            {
                return lcsubstring(word1, word2, length1 - 1, length2 - 1, count + 1);
            }
            else {
                var A = lcsubstring(word1,word2,length1-1,length2,0);
                var B = lcsubstring(word1, word2, length1, length2 - 1, 0);
                return Math.Max(count, Math.Max(A, B));
            }

        }
    
        public static int LongestPalindromPartition(string word1) {
            return LpsP(word1, 0, word1.Length - 1);
        }
        private static int LpsP(string word,int start,int end) {
            if (start==end) return 0;
            if (IsPalindrom(word.Substring(start, (end - start + 1)))) {
                return 0;
            }
            int minimumPalindromPartition = int.MaxValue;
            for (int k=start;k<end;k++) {
                int leftpalindrom = LpsP(word, start, k);
                int rightPalindrom = LpsP(word, k + 1, end);
                minimumPalindromPartition = Math.Min(minimumPalindromPartition, (leftpalindrom + rightPalindrom + 1));
            }
            return minimumPalindromPartition;
        }

        private static bool IsPalindrom(string word)
        {
            int i = 0;
            int j = word.Length-1;
            while (i <= j) {
                if (word[i] != word[j]) return false;
                i++;
                j--;
            }

            return true;
        }

        public static bool ScrambledString(string word1 ,string word2) {
            if (word2.Length!=word1.Length) {
                return false;
            }
            return IsScrambled(word1,word2,0,word1.Length-1,0,word2.Length-1);
        }
        private static bool IsScrambled(string word1,string word2,int start1,int end1,int start2,int end2) {
            if (start1 > end1 || start2>end2) return false;
            // base condition-1
            if (start1 == end1&&end2==start2)
                return word1[start1] == word2[start2];
            // base condition-2
            if (word1.Substring(start1, (end1 - start1)+1) == word2.Substring(start2, (end2 - start2)+1))
                return true;
            
            for(int k=start1;k<end1;k++){

                var sameComparison = IsScrambled(word1, word2, start1, k,start2,k) && IsScrambled(word1, word2, k + 1, end1,k+1,end2);
                if (sameComparison) return true;

                // doing apposite comparison
                int leftStart2 =end2-(k-start1);
                int leftend2 =end2;

                int rightStart2 = start2;
                int rightEnd2 = start2 + (end1 - (k + 1));

                var appostiteComparison = IsScrambled(word1,word2,start1,k,leftStart2,leftend2)&& 
                    IsScrambled(word1,word2,k+1,end1,rightStart2,rightEnd2);

                if (appostiteComparison) return true;
            }

            return false;
        }
        public static int MatrixChainMultiplication(int[] listofitems) {
            return McM(listofitems,1,listofitems.Length-1);
        }

        private static int McM(int[] items,int start,int end) {
            if (end == start) return 0;
            if (start > end) return 0;

            int minimumCost = int.MaxValue; 
            for (int k=start;k<end;k++) {
                var leftPartition = McM(items, start, k);
                var rightPartition = McM(items,k+1,end);
                var currentCost = items[start - 1] * items[k] * items[end];
                minimumCost = Math.Min(minimumCost, (currentCost + leftPartition + rightPartition));
            }

            return minimumCost;
        }

    }
}
