import java.util.Arrays;
import java.util.Scanner;
import java.io.*;

public class Main {
    public static long pow10(int i) {
        long base = 1;
        while (i > 0) {
            base *= 10;
            --i;
        }
        return base;
    }
    public static int smallify(int n) {
        int answ = 0;
        int base = 1;
        while (n / 10 > 0) {
            answ += (n % 10) * base;
            base *= 10;
            n /= 10;
        }
        return answ;
    }
    public static long nNumb(int numb, int n) {
        while (n > 0) {
            numb /= 10;
            --n;
        }
        return numb % 10;
    }
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        long answ = 0;
        int n, m, inp, base, len;
        n = input.nextInt();
        m = input.nextInt();
        int[] array_len = new int[10];
        int[][] array_data = new int[10][];

        for (int i = 0; i < 10; ++i) {
            array_len[i] = 0;
            array_data[i] = new int[n];
        }
        for (int k = 0; k < n; ++k) {
            inp = input.nextInt();
            base = 1;
            len = 1;
            while (inp > base * 10) {
                base *= 10;
                ++len;
            }
            array_data[len - 1][array_len[len - 1]] = inp;
            ++array_len[len - 1];
        }

        for (int i = 9; i >= 0; --i) {
            int[] temp = new int[array_len[i]];
            for (int j = 0; j < temp.length; ++j) {
                temp[j] = array_data[i][j];
            }
            Arrays.sort(temp);
            for (int j = 0; j < temp.length && m != 0; ++j) {
                if (nNumb(temp[j], i) != 9) {
                    answ += (9 - nNumb(temp[j], i)) * pow10(i);
                    --m;
                }
                if (i != 0) {
                    if (temp[j] < pow10(i)) {
                        array_data[i - 1][array_len[i - 1]] = temp[j];
                    } else {
                        array_data[i - 1][array_len[i - 1]] = smallify(temp[j]);
                    }
                    ++array_len[i - 1];
                }
            }
            if (m == 0) break;
        }
        System.out.println(answ);
    }
}