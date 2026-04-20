using System.Collections;
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
bool isNumber(char c) => ('0' <= c) && (c <= '9');
bool isLetter(char c) => (('a' <= c) && (c <= 'z')) || (('A' <= c) && (c <= 'Z'));
int find(int target, int[] arr) {
    for (int i = 0; i < arr.Length; ++i) {
        if (arr[i] == target) return i;
    }
    return -1;
}

int mathTable(char color) {
    int temp;
    int r = 0;
    int g = 0;
    int b = 0;
    for (int x = 1; x < 10; ++x) {
        for (int y = 1; y < 10; ++y) {
            temp = x * y;
            if (temp % 2 == 0) ++r;
            if (temp % 3 == 0 && temp % 2 != 0) ++g;
            if (temp % 5 == 0 && temp % 2 != 0 && temp % 3 != 0) ++b;
        }
    }
    return color switch {
        'r' => r,
        'g' => g,
        'b' => b,
        'y' => 81 - r - g - b,
        _ => 0
    };
}
bool checkDatingPassword(string s) {
    if (s.Length >= 7) {
        int numbers = 0;
        int letters = 0;
        foreach (char c in s) {
            if (isNumber(c)) ++numbers;
            if (isLetter(c)) ++letters;
        }
        return (numbers >= 2) && (letters >= 2) && ((s.Length - numbers - letters) > 0);
    }
    return false;
}
int[] findZeroSum(int[] nums) {
    HashSet<int> seen = new HashSet<int>();
    foreach (int n in nums) { 
        if (seen.Contains(-n)) {
            return new int[2]{find(n, nums), find(-n, nums)};
        }
        seen.Add(n);
    }
    return new int[2]{-1, -1};
}
int[] findIntersection(int cities, int[] route_1, int[] route_2) {
    int[] answ = new int[2]{-1, -1};
    var ways = new Dictionary<int, LinkedList<int>>();

    for (int i = 1; i < route_1.Length; ++i) {
        if (!ways.ContainsKey(route_1[i])) ways[route_1[i]] = new LinkedList<int>();
        if (!ways.ContainsKey(route_1[i - 1])) ways[route_1[i - 1]] = new LinkedList<int>();
        ways[route_1[i]].AddLast(route_1[i - 1]);
        ways[route_1[i - 1]].AddLast(route_1[i]);
    }
    ways[route_1[0]].AddLast(route_1[route_1.Length - 1]);
    ways[route_1[route_1.Length - 1]].AddLast(route_1[0]);

    for (int i = 1; i < route_2.Length; ++i) {
        if (ways.ContainsKey(route_2[i])) {
            foreach (int n in ways[route_2[i]]) {
                if (n == route_2[i - 1]) return new int[2]{n, route_2[i]};
            }
        }
    }
    if (ways.ContainsKey(route_2[0])) {
        foreach (int n in ways[route_2[0]]) {
            if (n == route_2[route_2.Length - 1]) return new int[2]{n, route_2[0]};
        }
    }
    return answ;
}
int[] findCells(int m, int n, int h, int v, int[] black_rows, int[] black_cols) {
    int g = 0;
    int b = 0;
    int g_rows = 0;
    int g_cols = 0;

    for (int i = 1; i < black_rows.Length; ++i) {
        if (black_rows[i] - black_rows[i - 1] == 1) {
            ++g_rows;
        } else {
            g_rows += 2;
        }
    }
    for (int j = 1; j < black_cols.Length; ++j) {
        if (black_cols[j] - black_cols[j - 1] == 1) {
            ++g_cols;
        } else {
            g_cols += 2;
        }
    }
    
    b = v * m + h * n - (h * v);
    g = (g_rows * n) + (g_cols * m);
    g -= (g_rows * g_cols) + (g_rows * v) + (g_cols * h);

    return new int[]{g, m * n - g - b, b};
}