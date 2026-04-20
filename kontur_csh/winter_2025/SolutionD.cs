using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class tripBureau {
    private int n, m, u, v;
    private int[] region_rows;
    private int[] region_cols;
    public tripBureau(int n, int m, int[] x, int[] y) {
        this.n = n;
        this.m = m;
        u = x.Length;
        v = y.Length;

        region_rows = new int[u];
        for (int i = 0; i < u; i++) region_rows[i] = x[i];
        System.Array.Sort(region_rows);

        region_cols = new int[v];
        for (int i = 0; i < v; i++) region_cols[i] = y[i];
        System.Array.Sort(region_cols);
    }
    int[] getBoundsOY(int x) {
        for (int i = 1; i < u; ++i) {
            if (region_rows[i - 1] <= x && x <= region_rows[i]) {
                return new int[]{region_rows[i - 1], region_rows[i]};
            }
        }
        return new int[]{-1, -1};
    }
    int[] getBoundsOX(int y) {
        for (int i = 1; i < v; ++i) {
            if (region_cols[i - 1] <= y && y <= region_cols[i]) {
                return new int[]{region_cols[i - 1], region_cols[i]};
            }
        }
        return new int[]{-1, -1};
    }
    public bool checkRegions(int x1, int y1, int x2, int y2) {
        bool answ = true;

        int[] bounds_x1 = getBoundsOY(x1);
        int[] bounds_y1 = getBoundsOX(y1);
        int[] bounds_x2 = getBoundsOY(x2);
        int[] bounds_y2 = getBoundsOX(y2);

        answ &= (bounds_x1[0] == bounds_x2[0] && bounds_x1[1] == bounds_x2[1]);
        answ &= (bounds_y1[0] == bounds_y2[0] && bounds_y1[1] == bounds_y2[1]);
        return answ;
    }
}

/*
int[] field = toInts(Console.ReadLine());
int[] uv = toInts(Console.ReadLine());

int[] rows = toInts(Console.ReadLine());
int[] cols = toInts(Console.ReadLine());

tripBureau sol = new tripBureau(field[0], field[1], rows, cols);
for (int i = toInt(Console.ReadLine()); i > 0; --i) {
    int[] coords = toInts(Console.ReadLine());
    Console.WriteLine(sol.checkRegions(coords[0], coords[1], coords[2], coords[3]));
} 
*/