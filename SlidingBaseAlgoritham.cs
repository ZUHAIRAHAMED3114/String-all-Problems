using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12ThJuneStringAlgoritham
{
    public class SlidingBaseAlgoritham
    {
        public static string LongestSubstringWithKlength(string word,int k) {
            Dictionary<char, int> map = new Dictionary<char, int>();
            int startIndex = 0;
            int endINdex = 0;
            int optimalStartIndex = 0;
            int substringLenth = 0;
            while (endINdex<word.Length) {
                if (map.Count >=k) {
                    while (map.Count >= k) {
                        if (map.Count == k) {
                            var currentLength = endINdex - startIndex + 1;
                            if (currentLength > substringLenth) {
                                optimalStartIndex = startIndex;
                                substringLenth = currentLength;
                            }
                        }
                        map[word[startIndex]]--;
                        if (map[word[startIndex]]==0){
                            map.Remove(word[startIndex]);
                         }
                        startIndex++;
                    }

                 }
                if (map.ContainsKey(word[endINdex]))
                {
                    map[word[endINdex]]++;
                }
                else {
                    map[word[endINdex]] = 1;
                }

                endINdex++;
            }

            return word.Substring(optimalStartIndex,substringLenth);
        }

        // time complexity is 0(m*n)
        public static List<string> findAllSubstringthatarePermutationOfAnotherString(string text,string pattern) {
            Dictionary<char, int> patternDictionary = new Dictionary<char, int>();
            int i = 0;
            while (i < pattern.Length) {
                if (patternDictionary.ContainsKey(pattern[i]))
                {
                    patternDictionary[pattern[i]]++;
                }
                else {
                    patternDictionary[pattern[i]] = 1;
                }

                i++;
            }
            List<string> allAnagaram = new List<string>();
            Dictionary<char, int> textDictionary = new Dictionary<char, int>();
            int startWindow=0;
            int endwindow=0;
            while (endwindow < text.Length) {
                if (textDictionary.Count >= patternDictionary.Count) {
                    while (textDictionary.Count >= patternDictionary.Count) {
                        if (textDictionary.Count == patternDictionary.Count) {
                            if (bothDictionaryAreValid(patternDictionary, textDictionary,pattern)) {
                                allAnagaram.Add(text.Substring(startWindow, patternDictionary.Count));
                            }
                            
                        }
                        textDictionary[text[startWindow]]--;
                        if (textDictionary[text[startWindow]] == 0)
                            textDictionary.Remove(text[startWindow]);    
                            
                            startWindow++;
                    }
                
                }

                if (textDictionary.ContainsKey(text[endwindow]))
                {
                    textDictionary[text[endwindow]]++;
                }
                else {
                    textDictionary[text[endwindow]] = 1;
                }

               
                endwindow++;
            }

            return allAnagaram;
        }

        private static bool bothDictionaryAreValid(Dictionary<char, int> patternDictionary, Dictionary<char, int> textDictionary,string pattern)
        {
            int i = 0;
            while (i < pattern.Length) {
                if (patternDictionary[pattern[i]] != textDictionary[pattern[i]]) {
                    return false;
                }
                i++;
            }

            return true;
        }

        //time complexity is 0(m+n);
        public static List<string> findAllAnagram(string text,string patter){
            Dictionary<char, int> map = new Dictionary<char, int>();
            int i = 0;
            while (i<patter.Length) {
                if (map.ContainsKey(patter[i]))
                {
                    map[patter[i]]++;
                }
                else {

                    map[patter[i]] = 1;
                }
                i++;
            }
            int count = map.Count;
            int endWindow = 0;
            int startWindow = 0;
            List<string> allAnagram = new List<string>();
            while (endWindow < text.Length) {
                if (count == 0) {
                    while (count == 0 & (endWindow-startWindow+1)>=patter.Length) {
                          if (endWindow - startWindow == patter.Length) {
                            allAnagram.Add(text.Substring(startWindow, patter.Length));
                           }

                            if (map.ContainsKey(text[startWindow]))
                                {
                                    map[text[startWindow]]++;
                                     if (map[text[startWindow]] > 0)
                                        {
                                 count++;
                                    }
                                }

                        startWindow++;

                    }
                    
                }

                if (map.ContainsKey(text[endWindow])) {
                    map[text[endWindow]]--;
                    if (map[text[endWindow]] == 0) {
                        count--;
                    }
                 }

                endWindow++;
            
            }

            return allAnagram;
        }

        public static string FindLongestSubstringContainDistinctCharacter(string word) {
            int startWindow = 0;
            int endWindow = 0;
            int optimalStartWindow = 0;
            int length = 0;
            Dictionary<char, int> map = new Dictionary<char, int>();
            while (endWindow < word.Length) {
                if (map.ContainsKey(word[endWindow])) {
                    while (map.ContainsKey(word[endWindow])){
                        map[word[startWindow]]--;
                        if (map[word[startWindow]] == 0)
                        {
                            map.Remove(word[startWindow]);
                        }
                        startWindow++;
                    }
                }

                map[word[endWindow]] = 1;
                if (map.Count > length) {
                    optimalStartWindow = startWindow;
                    length = map.Count;
                }

                endWindow++;
            }

            return word.Substring(optimalStartWindow,length);
        }
    
        // time complexity is 0(m+n)
        public static string MinimumWindowSubstring(string text,string pattern) {
            Dictionary<char, int> map = new Dictionary<char, int>();
            int i = 0;
            while (i < pattern.Length) { 
              var character= pattern[i];
                if (map.ContainsKey(character))
                {
                    map[character]++;
                }
                else {
                    map[character] = 1;
                }
                i++;
            }

            int count = map.Count;
            int endwindow = 0;
            int startWindow = 0;
            int optimalStartWindow = 0;
            int length = int.MaxValue;
            
            while (endwindow<=text.Length){
                
                if (count == 0) {
                    while (count==0) {
                        int currentWindowLenght = (endwindow-startWindow);
                        if ((currentWindowLenght < length)) {
                            optimalStartWindow = startWindow;
                            length = currentWindowLenght;
                        }

                        var character = text[startWindow];
                        if (map.ContainsKey(character)) {
                            map[character]++;
                            if (map[character] > 0) {
                                count++;
                            }
                        }

                        startWindow++;
                    }
                }
                if (endwindow != text.Length)
                {
                    if (map.ContainsKey(text[endwindow]))
                    {
                        map[text[endwindow]]--;
                        if (map[text[endwindow]] == 0)
                        {
                            count--;
                        }
                    }
                }
                endwindow++;
            
            }
            return text.Substring(optimalStartWindow,length);
        }    

    }
}
