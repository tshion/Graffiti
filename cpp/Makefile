COMPILER = g++
CPP_VERSION = c++17
OUT = bin


# Hello World
run-hello-world: $(wildcard ./HelloWorld/*.cpp)
	mkdir -p ./HelloWorld/$(OUT)
	$(COMPILER) -std=$(CPP_VERSION) -o ./HelloWorld/$(OUT)/$@ $^
	cd ./HelloWorld/$(OUT) ; ./$@

# マンデルブロ集合の算出
run-mandelbrot: $(wildcard ./Mandelbrot/*.cpp)
	mkdir -p ./Mandelbrot/$(OUT)
	$(COMPILER) -std=$(CPP_VERSION) -o ./Mandelbrot/$(OUT)/$@ $^
	cd ./Mandelbrot/$(OUT) ; ./$@
