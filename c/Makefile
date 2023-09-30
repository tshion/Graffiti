COMPILER = gcc
OUT = bin


# 逆ポーランド記法で入力された文字列の計算
run-calculator: $(wildcard ./Calculator/*.c)
	mkdir -p ./Calculator/$(OUT)
	$(COMPILER) -o ./Calculator/$(OUT)/$@ $^
	cd ./Calculator/$(OUT) ; ./$@

# Hello World
run-hello-world: $(wildcard ./HelloWorld/*.c)
	mkdir -p ./HelloWorld/$(OUT)
	$(COMPILER) -o ./HelloWorld/$(OUT)/$@ $^
	cd ./HelloWorld/$(OUT) ; ./$@
