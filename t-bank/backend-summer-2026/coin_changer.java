import java.util.Scanner;
import java.io.*;

/*
Дано n номиналов монет и сумма некой вещи. Найти минимальное количество монет,
которым может расплатиться покупатель, плюс, дать сдачу продавец.

Уточнения:
- каждый больший номинал кратен предыдущему
- сумма вещи - минимальная сумма, которую покупатель может дать продавцу

Решение:
Т.к., все номиналы кратные, мы можем воспользоваться жадным алгоритмом
и он будет корректен.

Далее, про перебор сумм - нам нет смысла условно добавлять по одной монете
минимального номинала. Достаточно набирать максимально близкую сумму всё
большими и большими номиналами, а после считать с неё сдачу.
*/

public class Main {
    public static long countCoins(long amount, long[] nominals) {
        if (amount == 0) return 0;
        long answ = 0;
        for (int i = nominals.length - 1; i >= 0 && amount > 0; --i) {
            answ += amount / nominals[i];
            amount %= nominals[i];
        }
        return answ;
    }
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int coins = input.nextInt();
        long price = input.nextLong();
        long[] nominals = new long[coins];

        for (int i = 0; i < coins; ++i) nominals[i] = input.nextLong();

        long answ = price / nominals[0];
        for (int i = 0; i < coins; ++i) {
            long temp_price = price / nominals[i];
            if (price % nominals[i] > 0) ++temp_price;
            temp_price *= nominals[i];

            answ = Math.min(answ, countCoins(temp_price, nominals) + countCoins(temp_price - price, nominals));
        }
        System.out.println(answ);
    }
}