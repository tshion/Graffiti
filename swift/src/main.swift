import Foundation



func makeMandelbrotSet(
    max: (Double, Double),
    min: (Double, Double),
    size: Int,
    limit: Double = 100.0,
    maxCycle: Int = 500
) -> [[Int]] {
    let scale = (
        (max.0 - min.0) / Double(size - 1),
        (max.1 - min.1) / Double(size - 1)
    )
    var table = [(Double, Double)]()
    table.append(min)
    for i in 1 ..< size {
        table.append((
            table[i - 1].0 + scale.0,
            table[i - 1].1 + scale.1
        ))
    }
    var history = [(Double, Double)](repeating: (0, 0), count: size)

    var result = [[Int]](repeating: [Int](repeating: 0, count: size), count: size)
    for row in 0 ..< size {
        for col in 0 ..< size {
            for cycle in 1 ..< maxCycle {
                let previous = history[cycle - 1]
                history[cycle] = (
                    previous.0 * previous.0 - previous.1 * previous.1 + table[row].0,
                    2 * previous.0 * previous.1 + table[col].1
                )

                if (limit <= sqrt(history[cycle].0 * history[cycle].0 + history[cycle].1 * history[cycle].1)) {
                    result[row][col] = (cycle % 255) + 1
                    break
                }
            }
        }
    }

    return result
}



let size = 1024
let min = (-1.50,  -1.00)
let max = ( 0.50,   1.00)

let graph = makeMandelbrotSet(max: max, min: min, size: size)
print("created graph")

let fileData: String = """
P2
\(size) \(size)
255
\(graph.map{(row: [Int]) -> String in
    "\(row.map{ String($0) }.joined(separator: "\t")))"
}.joined(separator: "\n"))
"""
FileManager.default.createFile(atPath: "image.pgm", contents: fileData.data(using: String.Encoding.utf8), attributes: nil)

print("finish")
