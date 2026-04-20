int toInt(string s) {
    int answ = 0;
    foreach (char c in s) {
        answ *= 10;
        answ += (c - '0');
    }
    return answ;
}
int[] toInts(string s) {
    int count = 1;
    bool is_negative = false;
    int n = 0;

    foreach (char c in s) if (c == ' ') ++count;
    int[] answ = new int[count];
    for (int i = 0;  i < answ.Length; ++i) answ[i] = 0;

    foreach (char c in s) {
        if (c == ' ') {
            if (is_negative) answ[n] = -answ[n];
            is_negative = false;
            ++n;
        } else if (c == '-') {
            is_negative = true;
        } else {
            answ[n] *= 10;
            answ[n] += (c - '0');
        }
    }

    return answ;
}
int max(int a, int b) => (a > b) ? a : b;
void fabulousString(string[] data) {
    int answ = 0;
    int unique = 0;
    int temp = 0;

    int[] letters = new int[26];

    for (int i = 0; i < data.Length; ++i) {
        temp = 0;
        for (int j = 0; j < 26; ++j) letters[j] = 0;

        foreach (char c in data[i]) ++letters[c - 'a'];
        foreach (int n in letters) {
            if (n > 0) ++temp;
        }
        if (temp > unique) {
            unique = temp;
            answ = i;
        }
    }

    Console.Write(unique);
    Console.Write(' ');
    Console.Write(data[answ]);
}
// int[] findOffset(int[][] targets, int[][] results)
int beautifulBuildings(int amount, int max_height, int offset, int[] buildings) {
    int answ = 0;
    int i = 0;
    int j = 0;
    int overheight = 0;

    while (j < buildings.Length) {
        ++j;
        if (buildings[j - 1] >= max_height) ++overheight;
        while (overheight > offset) {
            if (buildings[i] >= max_height) {
                --overheight;
            }
            ++i;
        }
        answ = max(answ, j - i);
    }

    return answ;
}