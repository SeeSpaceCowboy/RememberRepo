import java.util.Arrays;
import java.util.Scanner;
import java.io.*;

public class Main {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int last_odd = 0, last_even = 0;
        int odd = 0, even = 0;
        int len = input.nextInt();

        int[] students = new int[len];
        for (int i = 0; i < len; ++i) {
            students[i] = input.nextInt();
            if (i % 2 == 0 && students[i] % 2 == 0) {
                last_odd = i;
                ++odd;
            }
            if (i % 2 == 1 && students[i] % 2 == 1) {
                last_even = i;
                ++even;
            }
        }

        if (odd != 1 || even != 1) {
            System.out.println("-1 -1");
        } else {
            System.out.print(last_odd + 1);
            System.out.print(' ');
            System.out.print(last_even + 1);
        }
    }
}