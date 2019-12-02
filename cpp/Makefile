COMPILER = g++
CPP_VERSION = c++17
OUT = ./bin
SRC = ./src



main: $(SRC)/GraphModel.o $(SRC)/main.o
	mkdir -p $(OUT)
	$(COMPILER) -std=$(CPP_VERSION) -o $(OUT)/$@ $(SRC)/GraphModel.o $(SRC)/main.o

GraphModel.o: $(SRC)/GraphModel.hpp
