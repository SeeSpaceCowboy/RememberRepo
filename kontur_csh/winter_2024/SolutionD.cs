using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class mobileGame {
    private int offset;
    private string s;
    public mobileGame(int offset, string s) {
        this.offset = offset;
        this.s = s;
    }
    int max(int a, int b) => (a > b) ? a : b;
    private int countSymbStrike(char c) {
        int temp = 0;
        int answ = 0;
        foreach (char ch in s) {
            if (ch == c) {
                ++temp;
            } else {
                answ = max(answ, temp);
                temp = 0;
            }
        }
        answ = max(answ, temp);
        return answ;
    }
    private int maxSymbCount(char c) {
        int answ = 0;
        int i = 0;
        int j = 0;
        int unused_offset = offset;
        while (j < s.Length) {
            answ = max(answ, j - i);
            if (s[j] != c) --unused_offset;
            while (unused_offset < 0) {
                if (s[i] != c) ++unused_offset;
                ++i;
            }
            ++j;
        }
        return answ;
    }
    public int result() {
        int answ = 0;

        if (offset != 0) {
            answ = max(maxSymbCount('R'), maxSymbCount('G'));
            answ = max(answ, maxSymbCount('B'));
        } else {
            answ = max(countSymbStrike('B'), countSymbStrike('G'));
            answ = max(answ, countSymbStrike('B'));
        }

        return answ;
    }
}

/*
int[] vars = toInts(Console.ReadLine());
var sol = new mobileGame(vars[1], Console.ReadLine());
Console.WriteLine(sol.result());
*/