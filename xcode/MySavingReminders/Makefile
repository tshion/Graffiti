.PHONY: default
default: setup-xcode


# 開発環境のセットアップ
init:
	sh Scripts/setup-command.sh
	@make setup-xcode

# Xcode プロジェクトの生成
setup-xcode:
	mint run xcodegen generate
