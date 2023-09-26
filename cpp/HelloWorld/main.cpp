#include <iostream>

int main(int argc, char* argv[])
{
    const char* path = 0 < argc ? argv[0] : "unknown";
    std::cout << "Hello C++ World from " << path << "!" << std::endl;
}
