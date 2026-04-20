using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class catBless {
    private int[][] temples;
    private int[] result;
    // 0 - индекс; 1 - кол-во кошек; 2 - размер взятки

    public catBless(int[] cats, int[] bribes) {
        this.temples = new int[temples.Length][];
        result = new int[temples.Length];

        for (int i = 0; i <  temples.Length; i++) {
            this.temples[i] = new int[3];

            this.temples[i][0] = i;
            this.temples[i][1] = cats[i];
            this.temples[i][2] = bribes[i];
        } 
    }
    public int[] priceAndTemple() {
        int[] answ = new int[2];
        float[] price_per_cat = new float[temples.Length];
        for (int i = 0; i < temples.Length; ++i) {
            if (temples[i][2] != -1) {
                price_per_cat[i] = (float)temples[i][2] / (float)temples[i][1];
            } else {
                price_per_cat[i] = float.MaxValue;
            }
        }

        return answ;
    }
    public void printTotal() {
        foreach (int[] temple in temples) result[temple[0]] = temple[1];
        foreach (int n in result) {
            Console.Write(n);
            Console.Write(' ');
        }
    }
}