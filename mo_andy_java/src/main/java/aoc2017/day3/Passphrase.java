package aoc2017.day3;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

public class Passphrase {

    public static boolean isValid(List<String> strings) {
        return strings.size() == strings.stream().distinct().count();
    }

    private static String sortWord(String word){
        char[] chars = word.toCharArray();
        Arrays.sort(chars);
        return new String(chars);
    }
    public static boolean isValid2(List<String> strings) {
        return isValid(strings.stream().map(word -> sortWord(word) ).collect(Collectors.toList()));
    }
}
