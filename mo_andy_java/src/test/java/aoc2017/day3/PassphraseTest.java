package aoc2017.day3;

import org.junit.Test;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.Arrays;
import java.util.stream.Stream;

import static org.hamcrest.core.IsEqual.equalTo;
import static org.junit.Assert.assertThat;

public class PassphraseTest {

    @Test
    public void test1() {
        assertThat(Passphrase.isValid(Arrays.asList("aa", "bb", "cc", "dd", "ee")), equalTo(true));
    }

    @Test
    public void test2() {
        assertThat(Passphrase.isValid(Arrays.asList("aa", "bb", "cc", "dd", "aa")), equalTo(false));
    }

    @Test
    public void part1() {
        System.out.println(getLines().filter(l -> Passphrase.isValid(Arrays.asList(l.split(" " )))).count());
    }

    @Test
    public void part2() {
        System.out.println(getLines().filter(l -> Passphrase.isValid2(Arrays.asList(l.split(" " )))).count());
    }

    private Stream<String> getLines() {
        BufferedReader reader =  new BufferedReader(new InputStreamReader(Passphrase.class.getClassLoader().getResourceAsStream("day3/input3.txt")));
        return reader.lines();
    }

}