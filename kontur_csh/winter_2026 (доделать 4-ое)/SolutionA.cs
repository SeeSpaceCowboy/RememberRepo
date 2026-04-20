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