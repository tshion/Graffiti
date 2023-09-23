protocol ViewContract: AnyObject {

    func hideLoading()

    func showLoading()

    func showResult(data: [FetchGitRepoResponseItem])

    func showError(error: Error)
}
