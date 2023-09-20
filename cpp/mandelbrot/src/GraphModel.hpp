#ifndef CREATOR_HPP
#define CREATOR_HPP

#include <complex>

using namespace std;

/**
 * グラフ生成モデル
 */
class GraphModel
{
public:
    /**
     * 生成したグラフの消去
     *
     * size: 一辺の大きさ
     * target: 生成したグラフ
     */
    void clear(int size, int **target);

    /**
     * マンデルブロ集合を生成する
     *
     * max: 最大値
     * min: 最小値
     * size: 一辺の大きさ
     * limit: 閾値
     * maxCycle: 最大試行回数
     */
    int **makeMandelbrotSet(
        const complex<double> &max,
        const complex<double> &min,
        int size,
        int limit = 100,
        int maxCycle = 500);
};

#endif
