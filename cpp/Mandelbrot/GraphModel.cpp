#include <complex>
#include "GraphModel.hpp"

using namespace std;

/**
 * 生成したグラフの消去
 *
 * size: 一辺の大きさ
 * target: 生成したグラフ
 */
void GraphModel::clear(int size, int** target)
{
    for (int row = 0; row < size; row++)
    {
        delete[] target[row];
    }
    delete[] target;
}

/**
 * マンデルブロ集合を生成する
 *
 * max: 最大値
 * min: 最小値
 * size: 一辺の大きさ
 * limit: 閾値
 * maxCycle: 最大試行回数
 */
int** GraphModel::makeMandelbrotSet(
    const complex<double>& max,
    const complex<double>& min,
    int size,
    int limit,
    int maxCycle)
{
    int** result = new int* [size];
    for (int row = 0; row < size; row++)
    {
        result[row] = new int[size];
    }

    auto scale = complex<double>(
        (max.real() - min.real()) / (size - 1),
        (max.imag() - min.imag()) / (size - 1));

    complex<double>* table = new complex<double>[size];
    table[0] = min;
    for (int i = 1; i < size; i++)
    {
        table[i] = complex<double>(
            table[i - 1].real() + scale.real(),
            table[i - 1].imag() + scale.imag());
    }

    complex<double>* history = new complex<double>[maxCycle];
    history[0] = complex<double>(0, 0);

    for (int row = 0; row < size; row++)
    {
        for (int col = 0; col < size; col++)
        {
            for (int cycle = 1; cycle < maxCycle; cycle++)
            {
                history[cycle] = pow(history[cycle - 1], 2.0) + complex<double>(table[row].real(), table[col].imag());

                if (limit <= abs(history[cycle]))
                {
                    result[row][col] = (cycle % 255) + 1;
                    break;
                }
                else if (maxCycle - 1 <= cycle)
                {
                    result[row][col] = 0;
                    break;
                }
            }
        }
    }

    delete[] history;
    delete[] table;

    return result;
}
