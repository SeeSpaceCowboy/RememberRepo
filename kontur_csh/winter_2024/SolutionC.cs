using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class nonJapaneseSudoku {
    int[][] table;
    public nonJapaneseSudoku(int n, int m) {
        table = new int[n][];
        for (int i = 0; i < n; ++i) {
            table[i] = new int[m];
            for (int j = 0; j < m; ++j) table[i][j] = 0;
        }
    }
    public void computeRequests(int[][] req) {
        int t;
        bool[] painted_x = new bool[table.Length];
        bool[] painted_y = new bool[table[0].Length];
        
        for (int r = req.Length - 1; r >= 0; --r) {
            if (!painted_x[req[r][0]]) {
                t = req[r][0];
                painted_x[t] = true;
                for (int j = 0; j < table[0].Length; ++j) {
                    if (table[t][j] == 0) table[t][j] = req[r][2];
                }
            }
            if (!painted_y[req[r][1]]) {
                t = req[r][1];
                painted_y[t] = true;
                for (int i = 0; i < table.Length; ++i) {
                    if (table[i][t] == 0) table[i][t] = req[r][2];
                }
            }
        }
    }
    public void print() {
        for (int i = 0; i < table.Length; ++i) {
            for (int j = 0;j < table[i].Length; ++j) {
                Console.Write(table[i][j]);
                Console.Write(' ');
            }
            Console.Write('\n');
        }
     }
}

/*
int[] size = toInts(Console.ReadLine());
var sol = new nonJapaneseSudoku(size[0], size[1]);
int r = toInt(Console.ReadLine());

int[][] requests = new int[r][];
for (int i = 0; i < r; ++i) {
    requests[i] = toInts(Console.ReadLine());
    --requests[i][0];
    --requests[i][1];
}

sol.computeRequests(requests);
sol.print();
*/