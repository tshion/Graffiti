import Foundation



print("start")

let size = 1024
let min = (-1.50,  -1.00)
let max = ( 0.50,   1.00)

let graph = Model().makeMandelbrotSet(max: max, min: min, size: size)
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
