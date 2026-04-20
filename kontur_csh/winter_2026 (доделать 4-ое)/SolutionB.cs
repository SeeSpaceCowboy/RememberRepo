string trader(string[] parts) {
    string answ = "";
    Array.Sort(parts);
    for (int i = 0; i < parts.Length ; ++i) answ = parts + answ;
    return answ;
}