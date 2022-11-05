import Foundation

do {
    let fm = FileManager.default
    let pathDir = "tmp_by_swift"
    try fm.recreateDirectory(atPath: pathDir, withIntermediateDirectories: true)

    let pathFile = "\(pathDir)/sample.json"

    // JSON ファイル出力
    let encoder = JSONEncoder()
    encoder.dateEncodingStrategy = .iso8601
    let output = try encoder.encode(Entity(
        date: Date(),
        title: "test"
    ))
    fm.createFile(atPath: pathFile, contents: output)
    print("Success: Save")

    // JSON ファイル読み取り
    let format = ISO8601DateFormatter()
    let decoder = JSONDecoder()
    decoder.dateDecodingStrategy = .custom({ (decoder) -> Date in
        let container = try decoder.singleValueContainer()
        let dateStr = try container.decode(String.self)
        return format.date(from: dateStr)!
    })
    let json = try Data(contentsOf: URL(fileURLWithPath: pathFile))
    let data = try decoder.decode(Entity.self, from: json)
    print(data)
    print("Success: Load")
} catch {
    print("Failure: \(error)")
}
