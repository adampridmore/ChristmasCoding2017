package aoc2017.day1;


import java.util.stream.IntStream;

public class Captcha {
    public static Integer generateCaptcha(String s) {
        String extended = s + s.substring(0,1);
         return IntStream.range(0, s.length())
                .filter(n -> extended.charAt(n) == extended.charAt(n + 1))
                .map(n -> Integer.valueOf("" + extended.charAt(n)))
                 .sum();
    }

    public static Integer generateCaptcha2(String s) {
        String extended = s + s.substring(0,1);
        Integer halfDistance = s.length()/2;
         return 2 * IntStream.range(0, halfDistance)
                .filter(n -> extended.charAt(n) == extended.charAt(n + halfDistance))
                .map(n -> Integer.valueOf("" + extended.charAt(n)))
                 .sum();
    }
}
