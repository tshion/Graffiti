#include <complex>
#include <fstream>
#include <iostream>
#include "GraphModel.hpp"

using namespace std;

int main()
{
    cout << "start" << endl;

    const int size = 1024;
    const auto model = new GraphModel();

    complex<double> min = complex<double>(-1.50, -1.00);
    complex<double> max = complex<double>(0.50, 1.00);
    const auto map = model->makeMandelbrotSet(max, min, size);

    ofstream outputfile("image.pgm");
    outputfile << "P2" << endl;
    outputfile << size << ' ' << size << endl;
    outputfile << 255 << endl;
    for (int row = 0; row < size; row++)
    {
        for (int col = 0; col < size; col++)
        {
            outputfile << map[row][col] << '\t';
        }
        outputfile << endl;
    }
    outputfile.close();

    model->clear(size, map);
    cout << "finish" << endl;
}
