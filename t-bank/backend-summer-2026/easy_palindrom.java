import java.util.Scanner;
import java.io.*;

/*
Дана некая строка. Возможно ли сделать из неё палиндром,
если дописать в её начало n букв "a"?

Решение:
Сначала проверяем, а нужно ли нам что-либо дописывать.
Если нужно - проверяем количество букв a с конца и 
проверяем на палиндром со сдвигом.
*/

public class Main {
    public static boolean isAPalindrom(String s, int offset) {
        for (int i = offset / 2; i >= 0; --i) {
            if (s.charAt(i) != s.charAt(offset - i)) return false;
        }
        return true;
    }
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String s = input.next();
        if (isAPalindrom(s, s.length() - 1)) {
            System.out.println("Yes");
        } else {
            int a_count = 0;
            for (int i = s.length() - 1; i >= 0; --i) {
                if (s.charAt(i) != 'a') break;
                ++a_count;
            }
            if (isAPalindrom(s, s.length() - 1 - a_count)) {
                System.out.println("Yes");
            } else {
                System.out.println("No");
            }
        }
    }
}