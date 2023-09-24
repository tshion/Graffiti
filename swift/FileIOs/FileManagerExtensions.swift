import Foundation


extension FileManager {

    /// ディレクトリの再生成
    public func recreateDirectory(
        atPath: String,
        withIntermediateDirectories: Bool,
        attributes: [FileAttributeKey : Any]? = nil
    ) throws {
        if fileExists(atPath: atPath) {
            try! removeItem(atPath: atPath)
        }
        try! createDirectory(atPath: atPath, withIntermediateDirectories: withIntermediateDirectories, attributes: attributes)
    }
}
