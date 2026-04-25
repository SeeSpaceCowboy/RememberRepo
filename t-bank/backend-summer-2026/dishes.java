import java.util.Scanner;
import java.io.*;

/*
Есть 2n людей, высаженных в 2 линии и m блюд. 
Сколько существует вариантов расположения блюд 
у людей так, что соседи имеют разные блюда?
*/

public class Main {
    public static long pow(long base, long exp) {
        if (exp == 0) return 1;
        if (exp == 1) return base;
        if (exp % 2 == 0) return pow(base * base, exp / 2);
        return pow(base * base, exp / 2) * base;
    }
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        long visitors = input.nextInt();
        long food = input.nextInt();
        long answ;

        if (food == 1) answ = 0;
        else if (food == 2) answ = 2;
        else answ = food * (food - 1) * pow(food * (food - 3) + 3, visitors - 1);

        System.out.println(answ);
    }
}