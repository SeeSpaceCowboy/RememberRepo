using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class machineLearning {
    private string increase_seq = "";
    private string[] data;

    private Dictionary<char, LinkedList<char>> relation = new Dictionary<char, LinkedList<char>>();
    private Dictionary<char, bool> is_lead = new Dictionary<char, bool>();
    public machineLearning(int n) {
        data = new string[n];
        for (int i = 0; i < n; ++i) data[i] = Console.ReadLine();
    }
    bool contains(char c, string s) {
        foreach (char cs in s) if (cs == c) return true;
        return false;
    }
    public bool isPossible() {
        int j = 0;

        for (int i = 1; i < data.Length; ++i) {
            if (data[i].Length == data[i - 1].Length) {
                for (j = 0; j < data[i].Length; ++j) {
                    if (data[i][j] != data[i - 1][j]) break;
                }

                if (j == data[i].Length) return false;
                if (j == 0) is_lead[data[i][j]] = true;

                if (!contains(data[i - 1][j], increase_seq)) increase_seq += data[i - 1][j];
                if (!contains(data[i][j], increase_seq)) increase_seq += data[i][j];
                if (!relation.ContainsKey(data[i][j])) relation[data[i][j]] = new LinkedList<char>();

                relation[data[i][j]].AddLast(data[i - 1][j]);
            }
        }
        return true;
    }
    public int[] reconstructOrder() {
        int[] answ = new int[10];
        string order = "@!$&%#^*()";

        bool flag;
        int skip = 0;
        int exist = 9;
        
        for (int i = 0; i < 10; ++i) {
            flag = false;
            foreach (char c in increase_seq) {
                if (c == order[i]) {
                    flag = true;
                    break;
                }
            }
            if (flag) {
                answ[i] = exist;
                --exist;
            } else {
                answ[i] = skip;
                ++skip;
            }
        }
        return answ;
    }
}

/*
var sol = new machineLearning(toInt(Console.ReadLine()));
if (sol.isPossible()) {
    Console.WriteLine("YES");
    foreach (int n in sol.reconstructOrder()) {
        Console.Write(n);
        Console.Write(' ');
    }
} else {
    Console.WriteLine("NO");
}
*/