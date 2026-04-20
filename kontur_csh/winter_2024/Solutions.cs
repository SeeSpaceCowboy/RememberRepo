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
int toInt(string s) {
    int answ = 0;
    foreach (char c in s) {
        answ *= 10;
        answ += (c - '0');
    }
    return answ;
}
int max(int a, int b) => (a > b) ? a : b;
int blockChain(int b1, int b2) {
    if (b1 == b2) return b1 * 5;
    if (b1 > b2) return (b2 + 1) + (b2 * 2);
    return b1 + ((b1 + 1) * 2);
}
string homework(int[] values) {
    string answ = "";

    int pref_left = 0;
    int pref_right = 0;
    int pointer = values.Length - 1;

    foreach (int n in values) pref_left += n;
    while (pref_left > pref_right && pointer > 0) {
        pref_right += values[pointer];
        pref_left -= values[pointer];
        --pointer;
    }

    if (pref_left == pref_right) {
        for (int i = 0; i < pointer; ++i) {
            answ += values[i];
            answ += '+';
        }
        answ += values[pointer];
        answ += '=';
        answ += values[pointer + 1];
        for (int i = pointer + 2; i < values.Length; ++i) {
            answ += '+';
            answ += values[i];
        }
        return answ;
    }
    return (-1).ToString();
}