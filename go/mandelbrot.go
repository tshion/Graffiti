package main

import (
	"fmt"
	"math/cmplx"
	"os"
)

func main() {
	size := 1024

	result := makeMandelbrotSet(
		complex(0.50, 1.00),
		complex(-1.50, -1.00),
		size,
		100,
		500,
	)

	dirPath, err := os.Getwd()
	if err != nil {
		panic(err)
	}
	distDirPath := dirPath + "/go/dist"
	if _, err := os.Stat(distDirPath); os.IsNotExist(err) {
		os.Mkdir(distDirPath, 0777)
	}
	file, _ := os.Create(distDirPath + "/image.pgm")
	defer file.Close()

	file.Write(([]byte)("P2\n"))
	file.Write(([]byte)(fmt.Sprint(size) + " " + fmt.Sprint(size) + "\n"))
	file.Write(([]byte)("255\n"))
	for row := 0; row < size; row++ {
		for col := 0; col < size; col++ {
			file.Write(([]byte)(fmt.Sprint(result[row][col]) + "\t"))
		}
		file.Write(([]byte)("\n"))
	}
}

func makeMandelbrotSet(
	max complex128,
	min complex128,
	size int,
	limit float64,
	maxCycle int,
) [][]int {
	scale := complex(
		(real(max)-real(min))/float64(size-1),
		(imag(max)-imag(min))/float64(size-1),
	)

	table := make([]complex128, size)
	table[0] = min
	for index := 1; index < size; index++ {
		table[index] = complex(
			real(table[index-1])+real(scale),
			imag(table[index-1])+imag(scale),
		)
	}

	result := make([][]int, size)
	for row := range result {
		result[row] = make([]int, size)
	}

	for row := 0; row < size; row++ {
		for col := 0; col < size; col++ {
			history := make([]complex128, maxCycle)
			history[0] = complex(0, 0)
			for cycle := 1; cycle < maxCycle; cycle++ {
				add := complex(
					real(table[row]),
					imag(table[col]),
				)
				history[cycle] = cmplx.Pow(history[cycle-1], 2) + add
				if limit <= cmplx.Abs(history[cycle]) {
					result[row][col] = cycle%255 + 1
					break
				}
			}
		}
	}
	return result
}
