using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12ThJuneStringAlgoritham
{
   public class PatternMatching
    {
        // time complextity is 0(m*n)
        public static bool NavieMatching(string text,string pattern) {
            int i = 0;
            while (i<text.Length) {
                int j = 0;
                while (j<pattern.Length && text[i+j]==pattern[j]) {
                    j++;
                    if (j == pattern.Length) return true;
                }
                i++;
            }
            return false;
        }

        public static int[] PrefixSuffixTable(string pattern) {
            int[] lps = new int[pattern.Length];
            int j = 0;
            lps[0] = 0;
            int i = 1;
            while (i < pattern.Length) {
                if (pattern[i] == pattern[j])
                {

                    lps[i] = j + 1;
                    j++;
                    i++;
                }
                else {
                    if (j == 0)
                    {
                        lps[i] = 0;
                        i++;
                    }
                    else {
                        j = lps[j - 1];
                    }
                }
            }

            return lps;
        }

        public static bool KMP_LONGESESTprefixSuffix(string text,string pattern) {
            var lps = PrefixSuffixTable(pattern);
            int i = 0;
            int j = 0;
            while (i < text.Length) {
                if (text[i] == text[j])
                {
                    i++;
                    j++;
                    if (j == pattern.Length) return true;
                }
                else {
                    if (j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else {
                        i++;
                    }
                
                }
            }

            return false; 
        }

        public static double HashFunction(string text) {
            double hasvalue = 0;
            for (int i = 0; i < text.Length; i++) {
                hasvalue+=text[i] * Math.Pow(10, text.Length - i);
            }
            return hasvalue;
        }

        public static double RollingHashFunction(string oldtext,string newtext,double oldHashValue) {
            return (oldHashValue - oldtext[0] * Math.Pow(10, oldtext.Length) + newtext[newtext.Length - 1]) * 10;
        }

        public static bool RabinKarph_Mathcing_Algoritham(string text,string pattern) {
            double patternHashvalue = HashFunction(pattern);
            var oldHashValue = HashFunction(text.Substring(0, pattern.Length));
            var oldString = text.Substring(0, pattern.Length);
            if (oldHashValue == patternHashvalue) return true;

            for (int i = 1; i < ((text.Length - pattern.Length) + 1); i++) {
                var newStirng = text.Substring(i, pattern.Length);
                var newHashValue = RollingHashFunction(oldString,newStirng,oldHashValue);
                if (newHashValue == patternHashvalue) return true;
                oldHashValue = newHashValue;
                oldString = newStirng;
            }

            return false;
        }

        public static Dictionary<char, int> badMathcTable(string pattern) {
            
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i=0;i<pattern.Length;i++) {
                
                    map[pattern[i]] = i;
                
            }
            return map;
        }

        public static bool Booyer_mooreAlgoritham(string text,string pattern) {
            var bad_mathch_table = badMathcTable(pattern);
            int i = 0;
            while (i < (text.Length - pattern.Length) + 1) {
                // j is the last index of the pattern
                int j = pattern.Length - 1;
                while(text[i + j] == pattern[j]) {
                    j--;
                    if (j < 0) return true;
                  }

                var unMatchedCharacter = text[i + j];
                if (!bad_mathch_table.ContainsKey(unMatchedCharacter))
                {
                    i = i + j + 1;
                }
                else {
                    var unMatchdedCharacterIndex = bad_mathch_table[unMatchedCharacter];
                    i = i + j - unMatchdedCharacterIndex;
                }
            }

            return false;
        }
    }
}
