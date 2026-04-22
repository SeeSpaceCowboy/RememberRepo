import java.util.Arrays;
import java.util.Scanner;
import java.io.*;

// Неполное решение!

public class Main {
    public static int findAmount(long n) {
        int answ = 0;
        long temp = 1;
        while (n > temp * 10 + 1) {
            answ += 9;
            temp *= 10;
            ++temp;
        }
        if (n == 10) return 9;
        return answ + (int)(n / temp);
    }
    public static int isCorrectNumber(long n) {
        long prev = n % 10;
        n /= 10;
        while (n > 0) {
            if (prev != n % 10) return 0;
            prev = n % 10;
            n /= 10;
        }
        return 1;
    }
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        long l, r;
        l = input.nextLong();
        r = input.nextLong();
        System.out.println(findAmount(r) - findAmount(l) + isCorrectNumber(l));
    }
}