/* キーボードからの入力を処理する関数群の実装 */
#include <stdio.h>
#include <stdlib.h>
#include "InputString.h"



#pragma region ローカル関数の宣言

enum St_Op { push, pop, end };
static void inString(const int*, char[], int*);
static int JudgeRPN(const int*, char[]);
static void Trans_IN2RPN(int*, char[]);
static void cStack(enum St_Op op, char* value);

#pragma endregion



/// <summary>
/// キーボードからの入力を文字列に変換する
/// </summary>
/// <param name="isLim">入力文字列の最大文字数(input string Limit)</param>
/// <param name="str"> 文字列を格納する配列(string)</param>
/// <param name="sPos">入力文字列を格納する変数(string Position)</param>
extern void Input(int isLim, char str[], int* sPos)
{
    int flag;
    puts("数式を半角英数字で入力してください。");
    puts("２桁以上の場合は数字と数字の間に＄を書いてください。");

    // 入力を文字列として受け取り、さらに不備がないか判定する
    inString(&isLim, str, sPos);

    // 逆ポーランド法で記述されているかどうかを判定する
    flag = JudgeRPN(sPos, str);

    // 逆ポーランド法に変換する
    if (flag) Trans_IN2RPN(sPos, str);
}

/// <summary>
/// 入力を文字列として受け取り、さらに不備がないか判定する
/// </summary>
static void inString(const int* isLim, char str[], int* sPos)
{
    typedef enum { No, Yes } Flag;
    Flag repeat = Yes;
    Flag skip = No;
    // 数値の結合、括弧の数、演算子の数、数値の数
    int combo, lf, rf, ope, num;

    do {
        // 入力を配列に格納
        rewind(stdin);
        printf("計算式を入力してください: ");
        fgets(str, (*isLim + 1), stdin);

        // 不備があるかを判定する
        skip = No;
        lf = 0, rf = 0;
        combo = -5;
        ope = 0, num = 0;
        for (*sPos = 0; ; (*sPos)++)
        {
            // 数値？
            if ('1' <= str[*sPos] && str[*sPos] <= '9') {
                num++;
                continue;
            }
            // 演算子？
            switch (str[*sPos])
            {
                // 終端？
            case '\n':
                str[*sPos] = '\0';
            case '\0':
                // 数値と演算子の数が合っているか？
                if (ope == num - 1 && 0 < num && 0 < ope)
                    repeat = No;
                else
                    puts("数式に不備があります");
                skip = Yes;
                break;
                // 演算子？
            case '+':
            case '-':
            case '*':
            case '/':
                ope++;
                break;
                // '('、')'の数は合っている？
                // for文後に判定
            case '(':
                lf++;
                break;
            case ')':
                rf++;
                break;
                // 結合子は正しく使われている？
            case '$':
                combo = *sPos;
                // 前後に数字が来ているか？
                if (str[combo - 1] < '0' || '9' < str[combo - 1] || str[combo + 1] < '0' || '9' < str[combo + 1]) {
                    skip = Yes;
                    puts("'$'の使い方を間違えています");
                }
                num--;
                break;
                // ０の位置は大丈夫？
            case '0':
                num++;
                if (combo == (*sPos) - 1) break;
                // 例外＝やり直し
            default:
                skip = Yes;
                puts("数式に不備があります");
            }
            // for文を抜ける
            if (skip)
                break;
        }
        // 括弧の判定
        if (lf != rf) {
            puts("'('と')'の数が合いません");
            repeat = Yes;
        }
        // 再入力かどうかの判定
    } while (repeat);
}

/// <summary>
/// 逆ポーランド法で記述されているかどうかを判定する
/// </summary>
static int JudgeRPN(const int* sPos, char str[]) {
    // RPN  Reverse Polish Notation
    // In   infix notation
    enum { RPN, IN };
    int i;

    // 判定
    // 入力の最後尾に演算子があればRPN
    for (i = (*sPos - 1); i > 0; i--) {
        switch (str[i])
        {
        case '\0':
            break;
        case '+':
        case '-':
        case '*':
        case '/':
            return RPN;
        default:
            return IN;
        }
    }

    fprintf(stderr, "Filename: %s, line: %d function error\n", __FILE__, __LINE__);
    exit(EXIT_FAILURE);
}

/// <summary>
/// 逆ポーランド法に変換する
/// </summary>
static void Trans_IN2RPN(int* sPos, char str[]) {
    char tmp, * RPN;
    int i, St = 0, rp = 0;

    // メモリ確保
    RPN = (char*)malloc(sizeof(char) * (*sPos));
    if (RPN == NULL) {
        fprintf(stderr, "Filename: %s, line: %d malloc error\n", __FILE__, __LINE__);
        exit(EXIT_FAILURE);
    }

    // 逆ポーランド法に変換
    for (i = 0; i <= *sPos; i++) {

        // 終端文字
        if (str[i] == '\0') {
            while (0 < St) {
                cStack(pop, &tmp);
                if (tmp != ')') {
                    RPN[rp] = tmp;
                    rp++;
                }
                St--;
            }
            RPN[rp] = '\0';
            cStack(end, NULL);
            break;
        }
        // 数値
        else if ('0' <= str[i] && str[i] <= '9' || str[i] == '$') {
            RPN[rp] = str[i];
            rp++;
            continue;
        }
        // 括弧
        else if (str[i] == ')') {
            while (1) {
                cStack(pop, &tmp);
                St--;

                if (tmp == '(')
                    break;
                else {
                    if (tmp != ')') {
                        RPN[rp] = tmp;
                        rp++;
                    }
                }
            }
        }
        else if (str[i] == '(') {
            cStack(push, &str[i]);
            St++;
            continue;
        }
        // 演算子
        while (1) {
            if (St == 0) {
                cStack(push, &str[i]);
                St++;
                break;
            }
            else {
                cStack(pop, &tmp);
                if (tmp == '(') {
                    cStack(push, &tmp);
                    cStack(push, &str[i]);
                    St++;
                    break;
                }
                else if (tmp == '*' || tmp == '/') {
                    St--;
                    RPN[rp] = tmp;
                    rp++;
                    continue;
                }
                else {
                    cStack(push, &tmp);
                    cStack(push, &str[i]);
                    St++;
                    break;
                }
            }

        }
    }

    *sPos = rp;
    for (rp = 0; rp <= *sPos; rp++) {
        str[rp] == RPN[rp];
    }
    // free(RPN);
}

/// <summary>
/// スタック操作
/// </summary>
static void cStack(enum St_Op op, char* value) {
    static char* stack;
    static int flag = 0, next, size;
    char* tmp;

    // メモリの確保
    if (!flag) {
        next = 0, size = 20;
        stack = (char*)malloc(sizeof(char) * size);
        if (stack == NULL) {
            fprintf(stderr, "Filename: %s, line: %d malloc error\n", __FILE__, __LINE__);
            exit(EXIT_FAILURE);
        }
        flag++;
    }
    // メモリの拡張
    if (next == size) {
        size += 10;
        tmp = (char*)realloc(stack, sizeof(char) * size);
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
