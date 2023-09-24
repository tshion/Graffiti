class View {

    private var presenter: Presenter? = nil


    init() {
        inject()
    }


    func onStart() {
        presenter?.load()
    }

    func onStop() {
        presenter?.cancelTask()
    }


    private func inject() {
        let model = Model()
        self.presenter = Presenter(model: model, viewer: self)
    }
}


extension View: ViewContract {

    func hideLoading() {
        print("Hide Loading")
    }

    func showLoading() {
        print("Show Loading")
    }

    func showResult(data: [FetchGitRepoResponseItem]) {
        print(data)
    }

    func showError(error: Error) {
        print(error)
    }
}
