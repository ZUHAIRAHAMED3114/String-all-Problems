using System;
using System.Collections.Generic;
using System.Linq;
namespace _12ThJuneStringAlgoritham
{
    public class depthFirstSearch{

        public static List<string> PermutateString(string word) {
            List<string> listOFitems = new List<string>();
            bool[] selected = new bool[word.Length];
            
            for (int i=0;i<word.Length;i++){
                if (!selected[i]) {
                    selected[i] = true;
                    PermutateString(word,""+word[i],selected,listOFitems,1);
                    selected[i] = false;
                }
            }
            return listOFitems;
        }

        private static void PermutateString(string word, string helper, bool[] selected, List<string> listOFitems, int level)
        {
            if (level == word.Length) {
                listOFitems.Add(helper);
                return;
            }

            for (int i = 0; i < word.Length; i++)
            {
                if (!selected[i])
                {
                    selected[i] = true;
                    PermutateString(word, helper+word[i], selected, listOFitems, level+1);
                    selected[i] = false;
                }
            }

        }

        //
        public static bool WordSearch(char[,] board,string word) {
            bool[,] visited = new bool[board.GetLength(0), board.GetLength(1)];
            int[] xLocation = { 0,0,1,1,1,-1,-1,-1};
            int[] ylocation = { 1, -1, 0, 1, -1, 0, 1, -1 };
            for (int x=0;x<board.GetLength(0);x++) {
                for (int y = 0; y < board.GetLength(1); y++) {
                    visited[x, y] = true;
                    if (wordSearch(board, word, visited, 0, board[x,y].ToString(), x, y, xLocation, ylocation)) {
                        return true;
                    }
                    visited[x, y] = false;
                }
            }

            return false;
        }

        private static bool wordSearch(char[,] board,string word, bool[,] visited, int length, string helper,int x,int y,int[] xlocation,int[] ylocation) {
            if (helper == word) return true;
            if (length >= board.Length-1) return false;

            for (int i=0;i<xlocation.Length;i++) {
                int new_x = x + xlocation[i];
                int new_y = y + ylocation[i];

                if (isValid(new_x, new_y, visited)) {
                    visited[new_x, new_y] = true;

                    if (wordSearch(board, word, visited, length + 1, helper + board[new_x, new_y], new_x, new_y, xlocation, ylocation)) {
                        return true;
                    }

                    visited[new_x, new_y] = false;
                }
            }

            return false;
        }
        private static bool isValid(int x,int y,bool[,] selected){
            if (x >=0 && x < selected.GetLength(0) && y >= 0 && y < selected.GetLength(0) && !selected[x, y]) return true; 
            else return false;
        }
    
        //palindrome partion leetcode 131 problem solver after i.e upload all string algoritham in the github...
    }
    
    
}
