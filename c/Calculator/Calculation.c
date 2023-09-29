/* 入力値を計算する関数群の実装 */
#include <stdio.h>
#include <stdlib.h>
#include "Calculation.h"



#pragma region ローカル関数の定義

enum St_Op { push, pop, end };
static void Stack(enum St_Op op, int* value);

#pragma endregion



/// <summary>
/// 逆ポーランド記法を用いて、入力値を計算する
/// </summary>
/// <param name="sPos">改行あるいはヌル文字の出現位置(string Position)</param>
/// <param name="str">逆ポーランド記法で書かれた文字列(string)</param>
/// <returns>計算結果</returns>
extern int Calculation(const int* sPos, char str[]) {
    char* buf, * tmp;
    // 入力、右辺値、左辺値、ループ変数
    int in, o_r, o_l, i, j;
    int add, size;

    // 計算部
    for (i = 0; i < *sPos; i++) {
        // 数値
        if ('1' <= str[i] && str[i] <= '9') {
            // 結合子がある場合
            if (str[i + 1] == '$') {
                // 文字列を結合させて、一塊の数値として取り出す
                buf = (char*)malloc(sizeof(char) * 20);
                size = 20;
                if (buf == NULL) {
                    fprintf(stderr, "Filename: %s, line: %d malloc error\n", __FILE__, __LINE__);
                    exit(EXIT_FAILURE);
                }

                buf[0] = str[i + 0];
                buf[1] = str[i + 2];

                j = 2;
                add = 2;
                while (str[i + add + 1] == '$') {
                    if (j == size) {
                        tmp = (char*)realloc(buf, sizeof(char) * (size + 10));
                        size += 10;
                        if (tmp == NULL) {
                            fprintf(stderr, "Filename: %s, line: %d malloc error\n", __FILE__, __LINE__);
                            exit(EXIT_FAILURE);
                        }
                        buf = tmp;
                    }
                    buf[j] = str[i + add + 2];
                    j++;
                    add += 2;
                }

                in = atoi(buf);
                Stack(push, &in);
                i += add;

                free(buf);
                continue;
            }

            // 結合子がない場合
            in = str[i] - 48;
            Stack(push, &in);
            continue;
        }

        // 演算子
        // 順番に注意
        Stack(pop, &o_r);
        Stack(pop, &o_l);
        switch (str[i])
        {
        case '+':
            in = o_l + o_r;
            Stack(push, &in);
            break;
        case '-':
            in = o_l - o_r;
            Stack(push, &in);
            break;
        case '*':
            in = o_l * o_r;
            Stack(push, &in);
            break;
        case '/':
            in = o_l / o_r;
            Stack(push, &in);
            break;
        }
    }
    // 答えを取り出す
    Stack(pop, &o_l);
    Stack(end, NULL);
    return o_l;
}

/// <summary>
/// スタック操作
/// </summary>
static void Stack(enum St_Op op, int* value) {
    static int* stack, flag = 0, next, size;
    int* tmp;

    // メモリの確保
    if (!flag) {
        next = 0, size = 20;
        stack = (int*)malloc(sizeof(int) * size);
        if (stack == NULL) {
            fprintf(stderr, "Filename: %s, line: %d malloc error\n", __FILE__, __LINE__);
            exit(EXIT_FAILURE);
        }
        flag++;
    }
    // メモリの拡張
    if (next == size) {
        size += 10;
        tmp = (int*)realloc(stack, sizeof(int) * size);
        if (tmp == NULL) {
            fprintf(stderr, "Filename: %s, line: %d malloc error\n", __FILE__, __LINE__);
            exit(EXIT_FAILURE);
        }
        stack = tmp;
    }

    // スタックの操作
    if (op == push) {
        stack[next] = *value;
        next++;
    }
    else if (op == pop) {
        next--;
        if (next < 0)
            puts("Stack is already empty");
        else
            *value = stack[next];
    }
    else if (op == end) {
        flag = 0;
        free(stack);
    }
    else {
        fprintf(stderr, "Filename: %s, line: %d operate error\n", __FILE__, __LINE__);
        exit(EXIT_FAILURE);
    }
}
