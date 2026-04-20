using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
public class dirtyBoy {
    private string lead_1, lead_5;
    private LinkedList<string>[] bacteries = new LinkedList<string>[5];
    private int toInt(string s) {
        int answ = 0;
        foreach (char c in s) {
            answ *= 10;
            answ += (c - '0');
        }
        return answ;
    }
    public dirtyBoy(string lead_1, string lead_5) {
        this.lead_1 = lead_1;
        this.lead_5 = lead_5;
        int count = 0;
        do {
            int n = toInt(Console.ReadLine());
            bacteries[count] = new LinkedList<string>();
            for (int i = 0; i < n; ++i) bacteries[count].AddLast(Console.ReadLine());
            ++count;
            if (bacteries[count] != null) Array.Sort(bacteries[count]);
        } while (count < 5);
    }
    private int findNearest(string target, int finger) {
        int l = 0;
        int r = bacteries[finger].Length - 1;
        int m = l + ((r - l) / 2);

        while (r - l > 1) {
            m = l + ((r - l) / 2);
            if (bacteries[finger][m].CompareTo(target) == 0) break;
            if (bacteries[finger][m].CompareTo(target) > 0) {
                l = m;
            } else {
                r = m;
            }
        }
        
        return m;
    }
    private int commonNumbers(string a, string b) {
        int answ = 0;
        for (int i = 9; i >= 0; --i) {
            if (a[i] == b[i]) ++answ;
        }
        return answ;
    }
    public string[] findPath() {
        string[] path = new string[5];
        path[0] = lead_1;
        // for (int i = 1; i < 4; ++i) path[i] = [findNearest(path[i - 1], i)];
        path[4] = lead_5;
        return path;
    }
    public int countTime(string[] path) {
        int time = 0;
        for (int i = 1; i < path.Length; ++i) time += 10 - commonNumbers(path[i], path[i - 1]);
        return time;
    }
}
*/

/*
var sol = new dirtyBoy(Console.ReadLine(), Console.ReadLine());
string[] answ = sol.findPath();

Console.Write(sol.countTime(answ));
Console.Write(' ');
Console.WriteLine(answ.Length);

foreach (string s in answ) Console.WriteLine(s);

1234567890
7987654321
7985645241
1234540000
1234540001
1234540002
7987658471
*/
