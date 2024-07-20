#!/usr/bin/env ruby

# YAML を読み込んで、文字列置換して、JSON に出力するサンプル

require 'json'
require 'pathname'
require 'yaml'

PATH_ROOT = Pathname.new(__dir__).join("..")

# ファイル読み込み
text = ""
File.open(Pathname.new(PATH_ROOT).join("ruby/assets/jitpack.yml"), "r") { |file|
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
distPath = Pathname.new(PATH_ROOT).join("ruby/dist")
result = { jdk: replaced }
if !Dir.exist?(distPath) then
    Dir.mkdir(distPath)
end
File.open("#{distPath}/yaml_to.json", "w+") { |file|
    JSON.dump(result, file)
}
