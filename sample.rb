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
replaced = []
targets.each do |t|
    replaced << t.gsub(/\d/, "?")
end

# JSON に出力する
result = { jdk: replaced }
File.open("sample.json", "w+") { |file|
    JSON.dump(result, file)
}
