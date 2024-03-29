// swift-tools-version: 5.9
// The swift-tools-version declares the minimum version of Swift required to build this package.

import PackageDescription

let package = Package(
    name: "Graffiti",
    targets: [
        // Targets are the basic building blocks of a package, defining a module or a test suite.
        // Targets can depend on other targets in this package and products from dependencies.
        .executableTarget(
            name: "FileIOs",
            path: "swift/FileIOs"
        ),
        .target(
            name: "HelloWorld",
            path: "swift/HelloWorld/Sources"
        ),
        .testTarget(
            name: "HelloWorldTests",
            dependencies: ["HelloWorld"],
            path: "swift/HelloWorld/Tests"
        ),
        .executableTarget(
            name: "Mandelbrot",
            path: "swift/Mandelbrot"
        ),
        .executableTarget(
            name: "UrlSession",
            path: "swift/UrlSession"
        ),
    ]
)
