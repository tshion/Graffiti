#!/usr/bin/env ruby

# YAML を読み込んで、文字列置換して、JSON に出力するサンプル

require 'json'
require 'yaml'

# ファイル読み込み
text = ""
File.open("jitpack.yml", "r") { |file|
    text = file.read
}

# YAML 変換
yaml = YAML.load(text)

# 対象データ
targets = yaml["jdk"]

# 文字列中の数字を"?" に置換する
# NOTE: 今回は処理の流れを分解するために、説明変数に代入する
replaced = targets.map { _1.gsub(/\d/, "?") }

# JSON に出力する
result = { jdk: replaced }
File.open("sample.json", "w+") { |file|
    JSON.dump(result, file)
}
