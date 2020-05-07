var http = require("http")
http.createServer(function (req, res) {
  // Set CORS headers
  res.setHeader("Access-Control-Allow-Origin", "*")
  res.setHeader("Access-Control-Request-Method", "*")
  res.setHeader("Access-Control-Allow-Methods", "OPTIONS, GET, POST, PUT")
  res.setHeader("Access-Control-Allow-Headers", "*")
  if (req.method === "OPTIONS") {
    res.writeHead(200)
    res.end()
    return
  }



  switch (req.url) {
    case "/endpoint1.json":
      res.writeHead(200, { "Content-Type": "application/json" })
      res.end(JSON.stringify({
        data: "data by endpoint1",
        id: 1
      }))
      return
    case "/endpoint2/1.json":
      res.writeHead(200, { "Content-Type": "application/json" })
      res.end(JSON.stringify({
        data: "data by endpoint2-1"
      }))
      return
    case "/secret1":
      if (req.headers.authorization === "abcde") {
        res.writeHead(200, { "Content-Type": "application/json" })
        res.end(JSON.stringify({
          data: "data by secret1"
        }))
      } else {
        res.writeHead(401)
        res.end()
      }
      return
    case "/secret2":
      if (req.headers.authorization === "12345") {
        res.writeHead(200, { "Content-Type": "application/json" })
        res.end(JSON.stringify({
          data: "data by secret2"
        }))
      } else {
        res.writeHead(401)
        res.end()
      }
      return
    case "/token":
      if (req.method === "POST") {
        // ログイン
        res.writeHead(200, { "Content-Type": "application/json" })
        res.end(JSON.stringify({
          access_token: "abcde",
          refresh_token: "12345"
        }))
        return
      } else if (req.method === "PUT") {
        // リフレッシュ
        if (req.headers.authorization === "12345") {
          res.writeHead(200, { "Content-Type": "application/json" })
          res.end(JSON.stringify({
            access_token: "12345",
            refresh_token: "abcde"
          }))
        } else if (req.headers.authorization === "abcde") {
          res.writeHead(200, { "Content-Type": "application/json" })
          res.end(JSON.stringify({
            access_token: "abcde",
            refresh_token: "12345"
          }))
        } else {
          res.writeHead(401)
          res.end()
        }
        return
      }
    default:
      res.writeHead(404, { "Content-Type": "text/plain" })
      res.end("Not Found")
  }
}).listen(8887, "0.0.0.0")
