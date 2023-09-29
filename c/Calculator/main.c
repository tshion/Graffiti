#include <stdio.h>
#include <stdlib.h>
#include "Calculation.h"
#include "InputString.h"


// 入力可能文字数
const int isLim = 100;


int main(void)
{
    // 変数制限
    int sPos, ans;
    char* str;

    // メモリ確保
    str = (char*)malloc(sizeof(char) * (isLim + 1));
    if (str == NULL) {
        fprintf(stderr, "Filename: %s, line: %d malloc error\n", __FILE__, __LINE__);
        exit(EXIT_FAILURE);
    }

    // キーボードからの入力を受け付ける
    Input(isLim + 1, str, &sPos);

    // 入力を計算する
    ans = Calculation(&sPos, str);
    printf("Answer:%d\n", ans);

    // 終了処理
    free(str);
    exit(EXIT_SUCCESS);
}
