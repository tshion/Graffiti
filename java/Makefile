OUT = bin


# マンデルブロ集合の算出
run-mandelbrot: $(wildcard ./mandelbrot/src/*.java)
	mkdir -p ./mandelbrot/$(OUT)
	javac -d ./mandelbrot/$(OUT) $^
	cd ./mandelbrot ; java --class-path ./$(OUT) ./src/Program.java
