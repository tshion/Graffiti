import Foundation

print("aaaa")

let model = Model()
let task = model.fetchGitRepo(
    organization: "apple",
    onSuccess: { json in
        DispatchQueue.global().async {
            print(json)
        }
    },
    onError: { error in
        DispatchQueue.global().async {
            print(error)
        }
    }
)
task.resume()
Thread.sleep(forTimeInterval: 1)

print("bbbb")
