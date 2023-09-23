import Foundation
#if os(Linux)
    import FoundationNetworking
#endif


class Presenter {

    private let model: Model
    private var task: URLSessionDataTask? = nil
    private weak var viewer: ViewContract?


    init(model: Model, viewer: ViewContract) {
        self.model = model
        self.viewer = viewer
    }
}


extension Presenter: PresenterContract {

    func cancelTask() {
        task?.cancel()
        task = nil
    }

    func load() {
        viewer?.showLoading()

        task?.cancel()
        task = model.fetchGitRepo(
            organization: "apple",
            onSuccess: { json in
                DispatchQueue.global().async {
                    self.viewer?.hideLoading()
                    self.viewer?.showResult(data: json)
                }
            },
            onError: { error in
                DispatchQueue.global().async {
                    self.viewer?.hideLoading()
                    self.viewer?.showError(error: error)
                }
            }
        )
        task?.resume()
    }
}
