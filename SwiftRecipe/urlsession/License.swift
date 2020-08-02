public struct License : Decodable {
    public let key: String
    public let name: String
    public let nodeId: String
    public let spdxId: String
    public let url: String


    public enum CodingKeys : String, CodingKey {
        case key
        case name
        case nodeId = "node_id"
        case spdxId = "spdx_id"
        case url
    }
}
