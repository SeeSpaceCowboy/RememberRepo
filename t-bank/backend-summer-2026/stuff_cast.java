import java.util.Scanner;
import java.io.*;

/*
Мы - эйчары! Нам нужно нанять а бэкенд-разрабов и b сатанистов.

Нам дано n вакансий, с баллами по программированию и сатанизму.
Как нанять людей так, чтобы сумма баллов на нанятых позициях
была максимальной?

Решение:
Храним вторые баллы как оффсет. Сортируем по баллам за программирование
Далее, выбираем максимумы (может не быть оптимальным)
*/

public class Main {
    public static void heapify(int[] arr, int[] addition, int root, int size) {
        int biggest = root;
        int l = 2 * root + 1;
        int r = 2 * root + 2;

        if (l < size && arr[l] > arr[biggest]) biggest = l;
        if (r < size && arr[r] > arr[biggest]) biggest = r;

        if (biggest != root) {
            int temp = arr[root];
            arr[root] = arr[biggest];
            arr[biggest] = temp;

            temp = addition[root];
            addition[root] = addition[biggest];
            addition[biggest] = temp;

            heapify(arr, addition, biggest, size);
        }
    }
    public static void heapSort(int[] arr, int[] addition) {
        int temp;
        for (int i = arr.length / 2 - 1; i >= 0; --i) heapify(arr, addition, i, arr.length);
        for (int i = arr.length - 1; i >= 0; --i) {
            temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            temp = addition[0];
            addition[0] = addition[i];
            addition[i] = temp;

            heapify(arr, addition, 0, i);
        }
    }
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int answ = 0;

        int backend = input.nextInt();
        int ml = input.nextInt();
        int employees = input.nextInt();

        int[] resume_backend = new int[employees];
        int[] is_better_backend = new int[employees];

        for (int i = 0; i < employees; ++i) {
            resume_backend[i] = input.nextInt();
            is_better_backend[i] = resume_backend[i] - input.nextInt();
        }
        heapSort(resume_backend, is_better_backend);

        for (int k = employees - 1; k >= 0; --k) {
            if (is_better_backend[k] <= 0 && ml > 0) {
                answ += resume_backend[k] - is_better_backend[k];
                --ml;
                // System.out.print("ML: ");
                // System.out.println(resume_backend[k] - is_better_backend[k]);
            } else if (backend > 0) {
                answ += resume_backend[k];
                --backend;
                // System.out.print("Back: ");
                // System.out.println(resume_backend[k]);
            }
        }
        System.out.print(answ);
    }
}