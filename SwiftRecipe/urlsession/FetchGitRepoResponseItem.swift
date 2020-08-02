/**
 * FetchGitRepo のレスポンスデータ
 */
public struct FetchGitRepoResponseItem : Decodable {
    public let fullName: String
    public let id: Int
    public let license: License
    public let name: String
    public let nodeId: String
    public let `private`: Bool


    public enum CodingKeys : String, CodingKey {
        case fullName = "full_name"
        case id
        case license
        case name
        case nodeId = "node_id"
        case `private`
    }
}
