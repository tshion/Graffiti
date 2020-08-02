import Foundation


print("start")

let view = View()
view.onStart()
Thread.sleep(forTimeInterval: 1)
view.onStop()

print("finish")
