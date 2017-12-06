package aoc2017.day2;

import java.util.Comparator;
import java.util.List;

public class CheckSum {

    static class Pair {
        final Integer first;
        final Integer second;

        Pair(Integer first, Integer second) {
            this.first = first;
            this.second = second;
        }

        public boolean isDivisible() {
            return ( first > second && first % second == 0);
        }

        public Integer getDivision() {
            return first/second;
        }
    }
    public static Integer calcMinMaxDifference(List<Integer> row) {
        Integer min = row.stream().min(Comparator.naturalOrder()).get();
        Integer max = row.stream().max(Comparator.naturalOrder()).get();
        return max - min;
    }

    public static Integer findDivisor(List<Integer> row) {
        return row.stream().flatMap( n -> row.stream()
                .map(m -> new Pair(n, m))).filter(pair -> pair.isDivisible())
                .findFirst().get()
                .getDivision();
    }


    public static int calcChecksum(List<List<Integer>> rows) {
        return rows.stream().mapToInt(row -> calcMinMaxDifference(row)).sum();
    }

    public static int calcChecksum2(List<List<Integer>> rows) {
        return rows.stream().mapToInt(row -> findDivisor(row)).sum();
    }
}
