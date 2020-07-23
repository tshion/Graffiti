import Foundation
import FoundationNetworking

/**
 * ビジネスロジック
 */
class Model {

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
        do {
            let url = URL(string: "https://api.github.com/orgs/\(organization)/repos")!
            let request = URLRequest(url: url)
            return URLSession.shared.dataTask(with: request) { data, _, error in
                if let error = error {
                    onError(error)
                    return
                }

                let json = try! JSONSerialization.jsonObject(with: data!)
                let result = json as! [[String: Any]]
                onSuccess(result)
            }
        } catch {
            onError(error)
        }
    }
}
