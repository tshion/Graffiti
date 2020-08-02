protocol ViewContract: class {

    func hideLoading()

    func showLoading()

    func showResult(data: [FetchGitRepoResponseItem])

    func showError(error: Error)
}
