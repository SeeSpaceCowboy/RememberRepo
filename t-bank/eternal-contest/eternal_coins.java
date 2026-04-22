import java.util.Scanner;
import java.io.*;

// Неполное решение!

public class Main {
    public static long sumAmount(long target, int c1, int c2, int c3) {
        if (target == 0) return 0;

        long[] remainders = new long[c1];
        for (int i = 1; i < c1; ++i) remainders[i] = 0xFFFFFFF;
        remainders[0] = 0;

        for (int a = 0; a < c1; ++a) {
            for (int b = 0; b < c1; ++b) {
                int t = (a * c2) + (b * c3);
                remainders[t % c1] = Math.min(t, remainders[t % c1]);
            }
        }
        long answ = 0;
        for (int i = 0; i < c1; ++i) {
            if (remainders[i] < target) answ += (target - remainders[i]) / c1 + 1;
        }
        return answ;
    }
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int amount = input.nextInt() - 1;
        int coin1 = input.nextInt();
        int coin2 = input.nextInt();
        int coin3 = input.nextInt();

        System.out.println(sumAmount(amount - 1, coin1, coin2, coin3) + 1);
    }
}