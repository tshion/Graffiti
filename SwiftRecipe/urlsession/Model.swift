import Foundation
import FoundationNetworking

/**
 * ビジネスロジック
 */
class Model {

    private let baseUrl: URL


    init(baseUrl: String = "https://api.github.com") {
        self.baseUrl = URL(string: baseUrl)!
    }


    /**
     Git リポジトリからデータ取得する

     - parameters:
        - organization: 組織の指定
        - onSuccess: 通信成功時
        - onError: 通信失敗時

     - returns:
        - task
     */
    func fetchGitRepo(
        organization: String,
        onSuccess: @escaping ([[String: Any]]) -> Void,
        onError: @escaping (Error) -> Void
    ) -> URLSessionDataTask {
        let url = baseUrl.appendingPathComponent("orgs")
                    .appendingPathComponent("\(organization)")
                    .appendingPathComponent("repos")
        let request = URLRequest(url: url)

        let session = URLSession.shared
        return session.dataTask(with: request) { data, _, error in
            // TODO: エラーパターンをenum 定義したい
            do {
                if let error = error {
                    onError(error)
                    return
                }

                // TODO: Decodable を使って分解したい
                let json = try JSONSerialization.jsonObject(with: data!)
                let result = json as! [[String: Any]]
                onSuccess(result)
            } catch {
                onError(error)
            }
        }
    }
}
