using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class spaceWar {
    int n, m;
    int[][] battlefield;
    public spaceWar(int n, int m, string[] field) {
        this.n = n;
        this.m = m;
        battlefield = new int[n][];
        for (int i = 0; i < field.Length; ++i) {
            battlefield[i] = new int[m];
            for (int j = 0; j < field[i].Length; ++j) {
                if (field[i][j] == 'X') {
                    battlefield[i][j] = 2;
                } else {
                    battlefield[i][j] = 0;
                }
            }
        }
    }
    private bool dummyBfs(int x, int y, bool[][] steps = null) {
        if (x < 0 || x >= n || y < 0 || y >= m) return false;
        if (steps == null) {
            steps = new bool[n][];
            for (int i = 0; i < n; ++i) steps[i] = new bool[m];
        }
        if (steps[x][y] || battlefield[x][y] == 0) return false;
        if (battlefield[x][y] == 2) return true;
        steps[x][y] = true;
        return (dummyBfs(x - 1, y, steps) || dummyBfs(x, y - 1, steps)
            || dummyBfs(x + 1, y, steps) || dummyBfs(x, y + 1, steps)
            );
    }
    public int hitResult(int x, int y) {
        if (battlefield[x][y] == 0) return 0;

        battlefield[x][y] = 1;
        if (!dummyBfs(x, y)) return 2;
        return 1;
    }
}

/* Дорешить!

int[] data = toInts(Console.ReadLine());
string[] field = new string[data[0]];
for (int i = 0; i < data[0]; ++i) field[i] = Console.ReadLine();

spaceWar sol = new spaceWar(data[0], data[1], field);

for (int i = 0; i < data[2]; ++i) {
    int[] coords = toInts(Console.ReadLine());
    switch (sol.hitResult(coords[0] - 1, coords[1] - 1)) {
        case 0:
            Console.WriteLine("MISS");
            break;
        case 1:
            Console.WriteLine("HIT");
            break;
        case 2:
            Console.WriteLine("DESTROY");
            break;
    }
}

*/