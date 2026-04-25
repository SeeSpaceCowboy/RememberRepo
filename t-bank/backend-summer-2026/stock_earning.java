import java.util.Scanner;
import java.io.*;

/*
Казино... Фондовый рынок

Нам даны цены акции за n дней. Нужно найти максимально возможную прибыль,
если мы можем держать только одну акцию на руках, а также несколько раз
покупать-продавать с лагом в 1 день.

Решение: Это вообще не должно было пройти, но оно прошло (не внимательно
прочитал ТЗ, отправил, после перечитал и исправил на stock_earnings)
*/

public class Main {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int days = input.nextInt();
        int[] prices = new int[days];
        int min_price = 1000000000;
        int answ = 0;

        for (int i = 0; i < days; ++i) prices[i] = input.nextInt();

        for (int price : prices) {
            if (price < min_price) min_price = price;
            if (price - min_price > answ) {
                answ = price - min_price;
            }
        }
        System.out.println(answ);
    }
}