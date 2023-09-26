COMPILER = g++
CPP_VERSION = c++17
OUT = ./bin


# Hello World
run-hello-world: $(wildcard ./HelloWorld/*.cpp)
	mkdir -p $(OUT)
	$(COMPILER) -std=$(CPP_VERSION) -o $(OUT)/$@ $^
	cd $(OUT) ; ./$@

# マンデルブロ集合の算出
run-mandelbrot: $(wildcard ./Mandelbrot/*.cpp)
	mkdir -p $(OUT)
	$(COMPILER) -std=$(CPP_VERSION) -o $(OUT)/$@ $^
	cd $(OUT) ; ./$@
