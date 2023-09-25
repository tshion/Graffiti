#include <stdio.h>

int main(int argc, char* argv[])
{
    char* path = 0 < argc ? argv[0] : "unknown";
    printf("Hello C World from %s!\n", path);
}
