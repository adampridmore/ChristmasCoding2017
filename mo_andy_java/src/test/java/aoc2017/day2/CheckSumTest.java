package aoc2017.day2;

import org.junit.Test;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import static org.hamcrest.core.IsEqual.equalTo;
import static org.junit.Assert.*;

public class CheckSumTest {
    @Test
    public void getMinMaxDifference(){
        List<Integer> row = Arrays.asList(5, 1, 9, 5);
        assertThat(CheckSum.calcMinMaxDifference(row), equalTo(8));
    }

    @Test
    public void getChecksum(){
        List<List<Integer>> rows = new ArrayList<>();
        rows.add(Arrays.asList(5, 1, 9, 5));
        rows.add(Arrays.asList(7,5,3));
        rows.add(Arrays.asList(2,4,6,8));
        assertThat(CheckSum.calcChecksum(rows), equalTo(18));
    }

    @Test
    public void part1(){
        List<List<Integer>> rows = getTestData();
        System.out.println(CheckSum.calcChecksum(rows));

    }

    @Test
    public void part2(){
        List<List<Integer>> rows = getTestData();
        System.out.println(CheckSum.calcChecksum2(rows));

    }

    private List<List<Integer>> getTestData() {
        List<List<Integer>> rows = new ArrayList<>();
        rows.add(Arrays.asList(6046 ,6349 ,208 ,276 ,4643 ,1085 ,1539 ,4986 ,7006 ,5374 ,252 ,4751 ,226 ,6757 ,7495 ,2923));
        rows.add(Arrays.asList(1432 ,1538 ,1761 ,1658 ,104 ,826 ,806 ,109 ,939 ,886 ,1497 ,280 ,1412 ,127 ,1651 ,156));
        rows.add(Arrays.asList(244 ,1048 ,133 ,232 ,226 ,1072 ,883 ,1045 ,1130 ,252 ,1038 ,1022 ,471 ,70 ,1222 ,957));
        rows.add(Arrays.asList(87 ,172 ,93 ,73 ,67 ,192 ,249 ,239 ,155 ,23 ,189 ,106 ,55 ,174 ,181 ,116));
        rows.add(Arrays.asList(5871 ,204 ,6466 ,6437 ,5716 ,232 ,1513 ,7079 ,6140 ,268 ,350 ,6264 ,6420 ,3904 ,272 ,5565));
        rows.add(Arrays.asList(1093 ,838 ,90 ,1447 ,1224 ,744 ,1551 ,59 ,328 ,1575 ,1544 ,1360 ,71 ,1583 ,75 ,370));
        rows.add(Arrays.asList(213 ,166 ,7601 ,6261 ,247 ,210 ,4809 ,6201 ,6690 ,6816 ,7776 ,2522 ,5618 ,580 ,2236 ,3598));
        rows.add(Arrays.asList(92 ,168 ,96 ,132 ,196 ,157 ,116 ,94 ,253 ,128 ,60 ,167 ,192 ,156 ,76 ,148));
        rows.add(Arrays.asList(187 ,111 ,141 ,143 ,45 ,132 ,140 ,402 ,134 ,227 ,342 ,276 ,449 ,148 ,170 ,348));
        rows.add(Arrays.asList(1894 ,1298 ,1531 ,1354 ,1801 ,974 ,85 ,93 ,1712 ,130 ,1705 ,110 ,314 ,107 ,449 ,350));
        rows.add(Arrays.asList(1662 ,1529 ,784 ,1704 ,1187 ,83 ,422 ,146 ,147 ,1869 ,1941 ,110 ,525 ,1293 ,158 ,1752));
        rows.add(Arrays.asList(162 ,1135 ,3278 ,1149 ,3546 ,3686 ,182 ,149 ,119 ,1755 ,3656 ,2126 ,244 ,3347 ,157 ,865));
        rows.add(Arrays.asList(2049 ,6396 ,4111 ,6702 ,251 ,669 ,1491 ,245 ,210 ,4314 ,6265 ,694 ,5131 ,228 ,6195 ,6090));
        rows.add(Arrays.asList(458 ,448 ,324 ,235 ,69 ,79 ,94 ,78 ,515 ,68 ,380 ,64 ,440 ,508 ,503 ,452));
        rows.add(Arrays.asList(198 ,216 ,5700 ,4212 ,2370 ,143 ,5140 ,190 ,4934 ,539 ,5054 ,3707 ,6121 ,5211 ,549 ,2790));
        rows.add(Arrays.asList(3021 ,3407 ,218 ,1043 ,449 ,214 ,1594 ,3244 ,3097 ,286 ,114 ,223 ,1214 ,3102 ,257 ,3345));
        return rows;
    }
}