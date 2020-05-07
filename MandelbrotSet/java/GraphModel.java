/**
 * グラフ生成モデル
 */
public class GraphModel {

    /**
     * マンデルブロ集合を生成する
     * 
     * @param max      最大値
     * @param min      最小値
     * @param size     一辺の大きさ
     * @param limit    閾値
     * @param maxCycle 最大試行回数
     */
    public int[][] MakeMandelbrotSet(double[] max, double[] min, int size, int limit, int maxCycle) {
        double[] scale = { (max[0] - min[0]) / (size - 1), (max[1] - min[1]) / (size - 1) };

        var table = new double[size][2];
        table[0] = min;
        for (int i = 1; i < size; i++) {
            table[i][0] = table[i - 1][0] + scale[0];
            table[i][1] = table[i - 1][1] + scale[1];
        }

        var result = new int[size][size];
        for (int row = 0; row < size; row++) {
            for (int col = 0; col < size; col++) {
                result[row][col] = 0;

                var history = new double[maxCycle][2];
                history[0][0] = 0;
                history[0][1] = 0;
                for (int cycle = 1; cycle < maxCycle; cycle++) {
                    var previous = history[cycle - 1];
                    var target = history[cycle];

                    target[0] = previous[0] * previous[0] - previous[1] * previous[1] + table[row][0];
                    target[1] = 2 * previous[0] * previous[1] + table[col][1];

                    if (limit <= Math.sqrt(target[0] * target[0] + target[1] * target[1])) {
                        result[row][col] = (cycle % 255) + 1;
                        break;
                    }
                }
            }
        }
        return result;
    }
}
