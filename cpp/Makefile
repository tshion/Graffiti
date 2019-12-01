COMPILER = g++
CPP_VERSION = c++17
OUT = ./bin
SRC = ./src



main: $(SRC)/hello.o $(SRC)/main.o
	mkdir -p $(OUT)
	$(COMPILER) -std=$(CPP_VERSION) -o $(OUT)/$@ $(SRC)/hello.o $(SRC)/main.o

hello.o: $(SRC)/hello.hpp
