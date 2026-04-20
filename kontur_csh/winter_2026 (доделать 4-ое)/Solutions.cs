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
int treasures(string s) {
    int answ = 0;
    int temp = 0;
    foreach (char c in s) {
        if (c == 'M') ++temp;
        if (temp > answ) {
            ++answ;
            temp = 0;
        }
    }
    return answ;
}
string trader(string[] parts) {
    string answ = "";
    Array.Sort(parts);
    for (int i = 0; i < parts.Length ; ++i) answ = parts + answ;
    return answ;
}

int count = toInt(Console.ReadLine());
int[] temples = new int[count];
int[] bribes = new int[count];

for (int i = 0; i < count; ++i) {
    int[] temp = toInts(Console.ReadLine());
    temples[i] = temp[0];
    bribes[i] = temp[1];
}

var sol = new catBless(temples, bribes);
foreach (int res in sol.priceAndTemple()) Console.WriteLine(res);
sol.printTotal();