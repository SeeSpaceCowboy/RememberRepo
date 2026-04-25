import java.util.Scanner;
import java.io.*;

/*
Казино... Фондовый рынок

Нам даны цены акции за n дней. Нужно найти максимально возможную прибыль,
если мы можем держать только одну акцию на руках, а также несколько раз
покупать-продавать с лагом в 1 день.

Решение:

Это нужно расписывать?
*/

public class Main {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int days = input.nextInt();
        int[] prices = new int[days];
        int[] dp = new int[days];
        int answ = 0;

        for (int i = 0; i < days; ++i) prices[i] = input.nextInt();
        for (int i = 1; i < days; ++i) {
            if (prices[i] > prices[i - 1]) answ += prices[i] - prices[i - 1];
        }
        System.out.println(answ);
    }
}